using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.DataAccess;

namespace P7_Tienda.Productos
{
    public partial class ListadoProductos : System.Web.UI.Page
    {

        private ProductsDataHandler productos = new ProductsDataHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
        }

        protected void FillGrid()
        {
            dgProductos.DataSource = productos.FetchProductsView();
            dgProductos.DataBind();
        }
    }
}