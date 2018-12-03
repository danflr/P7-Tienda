using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.DataAccess
{
    public class SalesDataHandler
    {

        private static SqlConnection con;
        private static SqlCommand com;
        private static SqlDataReader rdr;

        public static bool AddSale(Classes.Sale sale)
        {
            OpenConnection();
            string query = String.Format("INSERT INTO VentasCabecera(Cliente, MontoTotal, Productos) VALUES({0}, {1}, {2})", sale.cliente, sale.montoTotal, sale.productos);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                foreach(Classes.ItemEntry entry in sale.Detalle)
                {
                    query = String.Format("INSERT INTO VentasDetalle(NoVenta, SKU, Cantidad, Monto) VALUES({0}, '{1}', {2}, {3})", sale.folio, entry.producto.SKU, entry.cantidad, entry.monto);
                    com = new SqlCommand(query, con);
                    com.ExecuteNonQuery();
                    new DataAccess.InventoryDataHandler().UpdateStocks(entry.producto, new DataAccess.InventoryDataHandler().RetrieveStocks(entry.producto) - entry.cantidad);
                }
                CloseConnection();
                return true;
            } catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Ocurrió un error al ingresar los datos de la venta en la base de datos: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }


        public static Classes.Sale GetSale(int SaleID)
        {
            Classes.Sale sale = new Classes.Sale();

            string headerQuery = string.Format("SELECT * FROM VentasCabecera WHERE NoVenta = {0}", SaleID);
            string detailQuery = string.Format("SELECT * FROM VentasDetalle WHERE NoVenta = {0}", SaleID);

            DataTable dtCab = new DataTable();
            DataTable dtLin = new DataTable();

            dtCab.Columns.Add("NoVenta", typeof(int));
            dtCab.Columns.Add("Cliente", typeof(int));
            dtCab.Columns.Add("MontoTotal", typeof(decimal));
            dtCab.Columns.Add("Productos", typeof(int));
            dtCab.Columns.Add("Fecha", typeof(DateTime));

            dtLin.Columns.Add("NoLinea", typeof(int));
            dtLin.Columns.Add("NoVenta", typeof(int));
            dtLin.Columns.Add("SKU", typeof(string));
            dtLin.Columns.Add("Cantidad", typeof(int));
            dtLin.Columns.Add("Monto", typeof(decimal));

            OpenConnection();
            try
            {
                com = new SqlCommand(headerQuery, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    dtCab.Rows.Add(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), decimal.Parse(rdr[2].ToString()), int.Parse(rdr[3].ToString()), Convert.ToDateTime(rdr[4].ToString()));
                }
                rdr.Close();
                com = new SqlCommand(detailQuery, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    dtLin.Rows.Add(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), rdr[2].ToString(), int.Parse(rdr[3].ToString()), decimal.Parse(rdr[4].ToString()));
                }

                sale.cliente = (int) dtCab.Rows[0]["Cliente"];
                sale.fecha = (DateTime)dtCab.Rows[0]["Fecha"];
                sale.folio = (int) dtCab.Rows[0]["NoVenta"];
                sale.montoTotal = (decimal)dtCab.Rows[0]["MontoTotal"];
                sale.productos = (int)dtCab.Rows[0]["Productos"];

                foreach(DataRow row in dtLin.Rows)
                {
                    Classes.Producto producto = new DataAccess.ProductsDataHandler().FetchProduct(row[2].ToString());
                    sale.AddItem(new Classes.ItemEntry(producto, int.Parse(row["cantidad"].ToString())));
                }
            } catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Hubo un error al extraer los datos de la venta de la base de datos, intente nuevamente.", "Error al consultar venta", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return new Classes.Sale();
            }
            return sale;
        }

        public static DataTable FetchSales()
        {
            DataTable dtVentas = new DataTable();
            dtVentas.Columns.Add("Folio", typeof(int));
            dtVentas.Columns.Add("IDCliente", typeof(int));
            dtVentas.Columns.Add("Nombre", typeof(string));
            dtVentas.Columns.Add("RFC", typeof(string));
            dtVentas.Columns.Add("MontoTotal", typeof(decimal));
            dtVentas.Columns.Add("Productos", typeof(int));
            dtVentas.Columns.Add("Fecha", typeof(DateTime));

            string query = "SELECT * FROM vVentasCabecera";

            OpenConnection();
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    dtVentas.Rows.Add(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), String.Concat(rdr[2].ToString(), " ", rdr[3].ToString(), " ", rdr[4].ToString()), rdr[5].ToString(), decimal.Parse(rdr[6].ToString()), int.Parse(rdr[7].ToString()), Convert.ToDateTime(rdr[8].ToString()));
                }
            }catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Hubo un error al recuperar la información de las ventas de la base de datos, intente de nuevo más tarde.", "Error en la conexión", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
            return dtVentas;
        }

        public static int GetSaleID()
        {
            int ID = 0;
            OpenConnection();
            string query = "SELECT * FROM VentasCabecera";
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    ID = int.Parse(rdr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Ocurrió un error al obtener los datos de los proveedores: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
            }
            CloseConnection();
            return ID + 1;
        }

        public static DataTable GetSalesHeader(int SaleID)
        {
            DataTable VentasCabecera = new DataTable();
            VentasCabecera.Columns.Add("NoVenta", typeof(int));
            VentasCabecera.Columns.Add("Cliente", typeof(int));
            VentasCabecera.Columns.Add("MontoTotal", typeof(decimal));
            VentasCabecera.Columns.Add("Productos", typeof(int));
            VentasCabecera.Columns.Add("Fecha", typeof(DateTime));

            string query = "SELECT * FROM VentasCabecera WHERE NoVenta = " + SaleID;

            OpenConnection();

            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    VentasCabecera.Rows.Add(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), decimal.Parse(rdr[2].ToString()), int.Parse(rdr[3].ToString()), DateTime.Parse(rdr[4].ToString()));
                }
                rdr.Close();
                CloseConnection();
            } catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Ocurrió un error al intentar recuperar los datos de la venta, intente nuevamente", "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
            return VentasCabecera;
        }

        public static DataTable GetSalesDetail(int SaleID)
        {
            DataTable VentasDetalle = new DataTable();
            VentasDetalle.Columns.Add("NoLinea", typeof(int));
            VentasDetalle.Columns.Add("NoVenta", typeof(int));
            VentasDetalle.Columns.Add("SKU", typeof(string));
            VentasDetalle.Columns.Add("Cantidad", typeof(int));
            VentasDetalle.Columns.Add("Monto", typeof(decimal));
            

            string query = "SELECT * FROM VentasDetalle WHERE NoVenta = " + SaleID;

            OpenConnection();

            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    VentasDetalle.Rows.Add(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), rdr[2].ToString(), int.Parse(rdr[3].ToString()), decimal.Parse(rdr[4].ToString()));
                }
                rdr.Close();
                CloseConnection();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Ocurrió un error al intentar recuperar los datos de la venta, intente nuevamente", "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
            return VentasDetalle;
        }
        
        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(@"Data Source=DANFLR-LAPTOP\SQL2017;Initial Catalog=Productos;Integrated Security=True");
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Ocurrió un error al abrir la conexión con la base de datos: " + ex.Message, "Error al conectar", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                con.Close();
                return false;
            }
        }

        public static bool CloseConnection()
        {
            try
            {
                if (con != null) con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
