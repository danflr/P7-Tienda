using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Clientes
{
    public partial class Listado : System.Web.UI.Page
    {

        private ClientsDataHandler clientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            clientes = new ClientsDataHandler();
            dgClientes.DataSource = clientes.FetchClients();
            dgClientes.DataBind();
        }
    }
}