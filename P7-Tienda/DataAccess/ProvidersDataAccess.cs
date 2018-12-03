using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace P5_ConSQL.DataAccess
{
    class ProvidersDataAccess
    {

        private static SqlConnection con;
        private static SqlCommand com;
        private static SqlDataReader rdr;

        public static bool RegisterProvider(Classes.Proveedor proveedor)
        {
            OpenConnection();
            string query = String.Format(@"INSERT INTO Proveedores(Nombre, Domicilio, Telefono, Correo, ImgPath) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", proveedor.nombre, proveedor.domicilio, proveedor.telefono, proveedor.correo, proveedor.path);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                CloseConnection();
                return true;
            } catch(Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al ingresar el proveedor en la base de datos: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable RetrieveProviders()
        {
            OpenConnection();
            DataTable dtProviders = new DataTable();
            dtProviders.Columns.Add("IDProveedor", typeof(int));
            dtProviders.Columns.Add("Nombre", typeof(string));
            dtProviders.Columns.Add("Domicilio", typeof(string));
            dtProviders.Columns.Add("Telefono", typeof(string));
            dtProviders.Columns.Add("Correo", typeof(string));
            dtProviders.Columns.Add("ImgPath", typeof(string));
            string query = "SELECT * FROM Proveedores";
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    dtProviders.Rows.Add(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
                }
            } catch(Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al obtener los datos de los proveedores: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
            }
            CloseConnection();
            return dtProviders;
        }

        public static Classes.Proveedor RetrieveProvider(int ID)
        {
            OpenConnection();
            Classes.Proveedor proveedor = new Classes.Proveedor();
            string query = "SELECT * FROM Proveedores WHERE IDProveedor = " + ID;
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    proveedor = new Classes.Proveedor(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
                }
            }
            catch (Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al obtener los datos de los proveedores: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
            }
            CloseConnection();
            return proveedor;
        }

        public static bool UpdateProvider(Classes.Proveedor proveedor)
        {
            OpenConnection();
            string query = string.Format("UPDATE Proveedores SET Nombre = '{0}', Domicilio = '{1}', Telefono = '{2}', Correo = '{3}', ImgPath = '{4}' WHERE IDProveedor = {5}", proveedor.nombre, proveedor.domicilio, proveedor.telefono, proveedor.correo, proveedor.path, proveedor.ID);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                CloseConnection();
                return true;
            } catch(Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al actualizar el proveedor: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteProvider(Classes.Proveedor proveedor)
        {
            OpenConnection();
            string query = string.Format("DELETE FROM Proveedores WHERE IDProveedor = {0}", proveedor.ID);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al actualizar el proveedor: " + ex.Message, "Error inesperado", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(@"Data Source=DANFLR-LAPTOP\SQL2017;Initial Catalog=Productos;Integrated Security=True");
                con.Open();
                return true;
            } catch(Exception ex)
            {
                ////System.Windows.Forms.MessageBox.Show("Ocurrió un error al abrir la conexión con la base de datos: " + ex.Message, "Error al conectar", //System.Windows.Forms.MessageBoxButtons.OK, //System.Windows.Forms.MessageBoxIcon.Error);
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
            }catch (Exception ex)
            {
                return false;
            }
        }

    }
}
