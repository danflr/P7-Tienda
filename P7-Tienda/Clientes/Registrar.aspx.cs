using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.Classes;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Clientes
{
    public partial class Registrar : System.Web.UI.Page
    {

        Cliente cliente;
        ClientsDataHandler ClientDA;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientDA = new ClientsDataHandler();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length > 0 && txtPaterno.Text.Length > 0 && txtMaterno.Text.Length > 0 && txtMail.Text.Length > 0 && txtDomicilio.Text.Length > 0 && txtTelefono.Text.Length > 0)
            {
                cliente = new Cliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtMail.Text, txtRFC.Text, txtDomicilio.Text, txtTelefono.Text);
                if (ClientDA.AddClient(cliente))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Cliente registrado correctamente')</script>");
                    txtDomicilio.Text = String.Empty;
                    txtMail.Text = String.Empty; ;
                    txtMaterno.Text = String.Empty;
                    txtNombre.Text = String.Empty;
                    txtPaterno.Text = String.Empty;
                    txtRFC.Text = String.Empty;
                    txtTelefono.Text = String.Empty;
                } else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ScriptName", "<script type=text/javascript>alert('Ocurrió un error al registrar el cliente, intente de nuevo')</script>");
                }
            }
        }
    }
}