using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P7_Tienda.Categorias
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Length > 0 && txtNombre.Text.Length > 0)
            {
                if (new P5_ConSQL.DataAccess.CategoriesDataHandler().AddCategory(new P5_ConSQL.Classes.Categoria(txtID.Text, txtNombre.Text)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Categoría agregada correctamente')</script>");
                } else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Hubo un error al ingresar la categoría, intente de nuevo')</script>");
                }
            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", "<script type=text/javascript>alert('Uno o más datos requeridos están incompletos, favor de especificarlos')</script>");
            }
        }
    }
}