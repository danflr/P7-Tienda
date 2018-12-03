using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace P5_ConSQL.DataAccess
{
    class CategoriesDataHandler
    {
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader rdr;

        public CategoriesDataHandler()
        {

        }

        public bool AddCategory(Classes.Categoria categoria)
        {
            if (OpenConnection())
            {
                string query = String.Format(@"INSERT INTO Categorias VALUES('{0}', '{1}')", categoria.ID, categoria.Nombre);
                try
                {
                    com = new SqlCommand(query, con);
                    com.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.Write(ex.Message);
                    return false;
                }
            }
            else return false;
        }

        public DataTable FetchCategories()
        {
            DataTable dtCategorias = new DataTable();
            string query = String.Format("SELECT * FROM Categorias");
            if (con == null) this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dtCategorias);
            this.CloseConnection();
            return dtCategorias;
        }

        public DataTable FetchCategories(string whereFilter)
        {
            DataTable dtCategorias = new DataTable();
            string query = String.Format("SELECT * FROM Categorias WHERE " + whereFilter);
            if (con == null) this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dtCategorias);
            this.CloseConnection();
            return dtCategorias;
        }

        public List<Classes.Categoria> GetCategoryList()
        {
            DataTable dtCategorias = this.FetchCategories();
            List<Classes.Categoria> categories = new List<Classes.Categoria>();
            foreach(DataRow row in dtCategorias.Rows){
                categories.Add(new Classes.Categoria(row[0].ToString(), row[1].ToString()));
            }
            return categories;
        }

        public bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(@"Data Source=DANFLR-LAPTOP\SQL2017;Initial Catalog=Productos;Integrated Security=True");
                con.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
