using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.Classes;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Ventas
{
    public partial class Realizar : System.Web.UI.Page
    {

        SalesDataHandler sales;
        Sale venta;
        ProductsDataHandler products;
        P5_ConSQL.Classes.Producto p;
        ClientsDataHandler clients;

        DataTable dtSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            dtSource = new DataTable();
            products = new ProductsDataHandler();
            dtSource.Columns.Add("SKU", typeof(string));
            dtSource.Columns.Add("Nombre", typeof(string));
            dtSource.Columns.Add("Precio", typeof(decimal));
            dtSource.Columns.Add("Cantidad", typeof(int));
            dtSource.Columns.Add("Monto", typeof(decimal));
            dgDetalle.DataSource = dtSource;
            dgDetalle.DataBind();
            sales = new SalesDataHandler();
            clients = new ClientsDataHandler();
            if (Session["Venta"] == null) Session["Venta"] = new Sale();
            venta = (Sale)Session["Venta"];
            //venta.cliente = int.Parse(ddClientes.SelectedValue);
            venta.fecha = DateTime.Now;
            venta.productos = 0;
            venta.montoTotal = 0;
            ddClientes.Items.Clear();
            foreach (DataRow cliente in clients.FetchClients().Rows) ddClientes.Items.Add(new ListItem(cliente["Nombre"].ToString() + " " + cliente["APaterno"].ToString() + " " + cliente["AMaterno"].ToString(), cliente["ID"].ToString()));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtProducto.Text.Length > 0 && txtCant.Text.Length > 0)
            {
                try
                {
                    p = products.FetchProduct(txtProducto.Text);
                    int disponibles = new InventoryDataHandler().RetrieveStocks(p);
                    if (disponibles >= int.Parse(txtCant.Text))
                    {
                        ItemEntry entry = new ItemEntry(p, int.Parse(txtCant.Text));
                        venta.AddItem(entry);
                        venta.montoTotal += entry.monto;
                        venta.productos += entry.cantidad;
                        Session["Venta"] = venta;
                        UpdateGrid();
                    }
                    else
                    {
                        //Alertar existencias insuficientes
                    }
                } catch(Exception ex)
                {
                    Debug.Write(ex.Message);
                }
            }
        }

        public void UpdateGrid()
        {
            //dtSource.Rows.Clear();
            foreach (ItemEntry entry in venta.GetProducts())
            {
                dtSource.Rows.Add(entry.producto.SKU, entry.producto.nombre, entry.producto.precio, entry.cantidad, entry.monto);
            }
            dgDetalle.DataSource = dtSource;
            dgDetalle.DataBind();
        }

        protected void ddClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //venta.cliente = int.Parse(ddClientes.SelectedValue);
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //if(dtSource.Rows.Count > 0)
            //{
                venta.fecha = DateTime.Now;
                venta.cliente = int.Parse(ddClientes.SelectedValue);
                venta.folio = SalesDataHandler.GetSaleID();
                Session["Venta"] = venta;
                if (SalesDataHandler.AddSale(venta))
                {
                    Response.Redirect("Resumen.aspx");
                    //Alertar venta realizada y redirigir al resumen
                } else
                {
                ClientScript.RegisterStartupScript(this.GetType(), "ScriptName", "<script type=text/javascript>alert('Ocurrió un error al finalizar la venta, intente de nuevo')</script>");
                //Alertar que hubo error al completar la venta
            }
            //}
        }

        protected void txtProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                p = products.FetchProduct(txtProducto.Text);
            } catch(Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}