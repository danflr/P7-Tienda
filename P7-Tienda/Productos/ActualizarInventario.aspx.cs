using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.Classes;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Productos
{
    public partial class ActualizarInventario : System.Web.UI.Page
    {

        P5_ConSQL.Classes.Producto p;
        ProductsDataHandler products;
        InventoryDataHandler stocks;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            products = new ProductsDataHandler();
            stocks = new InventoryDataHandler();
            ddProductos.Items.Clear();
            foreach(DataRow producto in products.FetchProducts().Rows)
            {
                ddProductos.Items.Add(new ListItem(producto["Nombre"].ToString(), producto["SKU"].ToString()));
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (stocks.UpdateStocks(p, int.Parse(txtNueva.Text)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Producto actualizado correctamente')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Hubo un error al actualizar la disponibilidad, intente de nuevo más tarde')</script>");
                }
            } catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('La nueva disponibilidad no fue especificada, favor de comprobarla')</script>");
            }
        }

        protected void ddProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = ddProductos.SelectedIndex;
            DataRow producto = products.FetchProductsView().Rows[Index];
            p = products.FetchProduct(producto["SKU"].ToString());
            lblProducto.Text = p.nombre;
            txtDisp.Text = producto["Disponibles"].ToString();
        }
    }
}