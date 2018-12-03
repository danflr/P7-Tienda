using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.Classes;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Proveedores
{
    public partial class Registrar : System.Web.UI.Page
    {

        Proveedor proveedor;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length > 0 && txtDomicilio.Text.Length > 0 && txtMail.Text.Length > 0 && txtTelefono.Text.Length > 0)
            {
                proveedor = new Proveedor(0, txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtMail.Text, String.Empty);
                if (ProvidersDataAccess.RegisterProvider(proveedor))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Proveedor registrado correctamente')</script>");
                    txtDomicilio.Text = String.Empty;
                    txtMail.Text = String.Empty; ;
                    txtNombre.Text = String.Empty;
                    txtTelefono.Text = String.Empty;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Hubo un error al registrar el proveedor, intente de nuevo')</script>");
                }
            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Uno o más campos requeridos están vacíos, favor de llenarlos')</script>");
            }
        }
    }
}