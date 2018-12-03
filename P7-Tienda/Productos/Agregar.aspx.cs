using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P5_ConSQL.DataAccess;
using P5_ConSQL.Classes;
using System.Diagnostics;

namespace P7_Tienda.Productos
{
    public partial class Agregar : System.Web.UI.Page
    {

        P5_ConSQL.Classes.Producto p;
        ProductsDataHandler da;
        CategoriesDataHandler cat;

        protected void Page_Load(object sender, EventArgs e)
        {
            da = new ProductsDataHandler();
            cat = new CategoriesDataHandler();
            List<Categoria> list = cat.GetCategoryList();
            foreach(Categoria c in list)
            {
                ddCategorias.Items.Add(new ListItem(c.Nombre, c.ID));
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtSKU.Text.Length > 0 && txtDesc.Text.Length > 0 && txtNombre.Text.Length > 0 && txtprecio.Text.Length > 0)
            {
                p = new P5_ConSQL.Classes.Producto(txtSKU.Text, txtNombre.Text, txtDesc.Text, ddCategorias.SelectedValue.ToString(), decimal.Parse(txtprecio.Text));
                if (da.AddProduct(p))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Producto registrado correctamente')</script>");
                    txtNombre.Text = String.Empty;
                    txtDesc.Text = String.Empty;
                    txtprecio.Text = String.Empty;
                    txtSKU.Text = String.Empty;
                } else {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Hubo un error al registrar el producto, intente nuevamente más tarde')</script>");
                }
            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Uno o más campos requeridos están vacíos, favor de comprobarlos')</script>");
            }
        }
    }
}