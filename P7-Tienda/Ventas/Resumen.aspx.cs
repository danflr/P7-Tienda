using P5_ConSQL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P7_Tienda.Ventas
{
    public partial class Resumen : System.Web.UI.Page
    {

        Sale venta;
        DataRow cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            //1000216149
            if (Session["Venta"] != null)
            {
                txtFecha.Text = DateTime.Now.Date.ToString();
                venta = (Sale)Session["Venta"];
                cliente = new P5_ConSQL.DataAccess.ClientsDataHandler().FetchClients().Select("ID = " + venta.cliente)[0];
                txtCliente.Text = venta.cliente + " - " + cliente["APaterno"] + cliente["AMaterno"] + ", " + cliente["Nombre"];
                txtProductos.Text = venta.productos.ToString();
                txtTotal.Text = venta.montoTotal.ToString();
                DataTable Detalle = P5_ConSQL.DataAccess.SalesDataHandler.GetSalesDetail(venta.folio);
                dgDetalle.DataSource = Detalle;
                dgDetalle.DataBind();
            }
        }
    }
}