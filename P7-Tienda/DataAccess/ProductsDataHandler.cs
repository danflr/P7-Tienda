using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace P5_ConSQL.DataAccess  
{
    class ProductsDataHandler
    {

        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader rdr;

        public ProductsDataHandler()
        {

        }

        public bool AddProduct(Classes.Producto producto)
        {
            if (OpenConnection())
            {
                string query = String.Format(@"INSERT INTO Productos VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}')", producto.SKU, producto.nombre, producto.descripcion, producto.precio, producto.categoria, producto.imageData);
                try
                {
                    if (con == null) this.OpenConnection();
                    com = new SqlCommand(query, con);
                    com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Debug.Write(ex.Message);
                    return false;
                }

                try
                {
                    query = String.Format(@"INSERT INTO Inventarios VALUES('{0}', 0, '', 1)", producto.SKU);
                    com = new SqlCommand(query, con);
                    com.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }catch(SqlException ex)
                {
                    Debug.Write(ex.Message);
                    return false;
                }
            }
            else return false;
        }

        public DataTable FetchProducts()
        {
            DataTable productos = new DataTable();
            productos.Columns.Add("SKU", typeof(string));
            productos.Columns.Add("Nombre", typeof(string));
            productos.Columns.Add("Descripcion", typeof(string));
            productos.Columns.Add("Precio", typeof(double));
            productos.Columns.Add("Categoria", typeof(string));
            productos.Columns.Add("Imagen", typeof(string));
            string query = String.Format("SELECT * FROM Productos");
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    productos.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                rdr.Close();
            }catch(SqlException ex)
            {
                Debug.Write(ex.Message);
                rdr.Close();
            }
            this.CloseConnection();
            return productos;
        }

        public DataTable FetchProductsView()
        {
            /*DataTable productos = new DataTable();
            productos.Columns.Add("SKU", typeof(string));
            productos.Columns.Add("Nombre", typeof(string));
            productos.Columns.Add("Descripcion", typeof(string));
            productos.Columns.Add("Precio", typeof(double));
            productos.Columns.Add("Categoria", typeof(string));
            productos.Columns.Add("Disponibles", typeof(int));
            productos.Columns.Add("Imagen", typeof(string));
            string query = String.Format("SELECT * FROM vProductos");
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    productos.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                rdr.Close();
            }
            this.CloseConnection();*/
            DataTable productos = new DataTable();
            string query = String.Format("SELECT * FROM vProductos");
            if (con == null) this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(productos);
            return productos;
        }

        public Classes.Producto FetchProduct(string SKU)
        {
            Classes.Producto producto = new Classes.Producto();
            string query = string.Format("SELECT * FROM Productos WHERE SKU = '{0}'", SKU);
            try
            {
                OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    producto.categoria = rdr["Categoria"].ToString();
                    producto.descripcion = rdr["Descripcion"].ToString();
                    producto.imageData = rdr["RutaImagen"].ToString();
                    producto.nombre = rdr["Nombre"].ToString();
                    producto.precio = decimal.Parse(rdr["Precio"].ToString());
                    producto.SKU = rdr["SKU"].ToString();
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                rdr.Close();
            }
            this.CloseConnection();
            return producto;
        }


        public DataTable FetchProducts(string whereFilter)
        {
            DataTable productos = new DataTable();
            productos.Columns.Add("SKU", typeof(string));
            productos.Columns.Add("Nombre", typeof(string));
            productos.Columns.Add("Descripcion", typeof(string));
            productos.Columns.Add("Precio", typeof(double));
            productos.Columns.Add("Categoria", typeof(string));
            productos.Columns.Add("Imagen", typeof(string));
            string query = String.Format("SELECT * FROM Productos WHERE " + whereFilter);
            if (con == null)
            {
                if (this.OpenConnection())
                {
                    if (com == null) com = new SqlCommand(query, con);
                    if (rdr == null) rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        productos.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                    }
                    rdr.Close();
                }
            }
            this.CloseConnection();
            return productos;
        }

        public bool UpdateProduct(Classes.Producto producto)
        {
            string query = String.Format("UPDATE Productos SET SKU = '{0}', Nombre = '{1}', Descripcion = '{2}', Precio = {3}, Categoria = '{4}', RutaImagen = '{5}' WHERE SKU = '{0}'", producto.SKU, producto.nombre, producto.descripcion, producto.precio, producto.categoria, producto.imageData);
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                rdr.Close();
                this.CloseConnection();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteProduct(Classes.Producto producto)
        {
            string query = String.Format("DELETE FROM Productos WHERE SKU = '{0}'", producto.SKU);
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                rdr.Close();
                this.CloseConnection();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(@"Data Source=DANFLR-LAPTOP\SQL2017;Initial Catalog=Productos;Integrated Security=True");
                con.Open();
                return true;
            } catch(SqlException ex)
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
