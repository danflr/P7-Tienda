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
    class InventoryDataHandler
    {

        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader rdr;

        public InventoryDataHandler()
        {

        }

        public int RetrieveStocks(Classes.Producto producto)
        {
            int available = 0;
            string query = String.Format("SELECT Disponibles FROM Inventarios WHERE SKU = '{0}'", producto.SKU);
            if (con == null) this.OpenConnection();
            com = new SqlCommand(query, con);
            rdr = com.ExecuteReader();
            while (rdr.Read()) available = int.Parse(rdr[0].ToString());
            rdr.Close();
            return available;
        }

        public bool UpdateStocks(Classes.Producto producto, int newAmount)
        {
            string query = String.Format("UPDATE Inventarios SET Disponibles = {0} WHERE SKU = '{1}'", newAmount, producto.SKU);
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                rdr.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteEntry(Classes.Producto producto)
        {
            string query = String.Format("DELETE FROM Inventarios WHERE SKU = '{0}'", producto.SKU);
            try
            {
                if (con == null) OpenConnection();
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                rdr.Close();
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
