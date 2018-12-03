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
    class ClientsDataHandler
    {

        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader rdr;

        public ClientsDataHandler()
        {

        }

        public bool AddClient(Classes.Cliente cliente)
        {
            if (con == null) this.OpenConnection();
            string query = String.Format(@"INSERT INTO Clientes(Nombre, APaterno, AMaterno, Correo, RFC, Domicilio, Telefono, ImgPath) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", cliente.Nombre, cliente.APaterno, cliente.AMaterno, cliente.Correo, cliente.RFC, cliente.Domicilio, cliente.Telefono, cliente.Path);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                this.CloseConnection();
                return true;
            } catch(Exception ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public Classes.Cliente RetrieveClient(int ID)
        {
            Classes.Cliente cliente = new Classes.Cliente();
            if (con == null) this.OpenConnection();
            string query = String.Format(@"SELECT * FROM Clientes WHERE IDCliente = {0}", ID);
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    cliente = new Classes.Cliente(ID, rdr["Nombre"].ToString(), rdr["APaterno"].ToString(), rdr["AMaterno"].ToString(), rdr["Correo"].ToString(), rdr["RFC"].ToString(), rdr["Domicilio"].ToString(), rdr["Telefono"].ToString(), rdr["ImgPath"].ToString());
                }
                this.CloseConnection();
            } catch(Exception ex)
            {
                Debug.Write(ex.Message);
                this.CloseConnection();
            }
            return cliente;
        }

        public DataTable FetchClients()
        {
            DataTable dtClientes = new DataTable();
            dtClientes.Columns.Add("ID", typeof(int));
            dtClientes.Columns.Add("Nombre", typeof(string));
            dtClientes.Columns.Add("APaterno", typeof(string));
            dtClientes.Columns.Add("AMaterno", typeof(string));
            dtClientes.Columns.Add("Correo", typeof(string));
            dtClientes.Columns.Add("RFC", typeof(string));
            dtClientes.Columns.Add("Domicilio", typeof(string));
            dtClientes.Columns.Add("Telefono", typeof(string));
            dtClientes.Columns.Add("FechaRegistro", typeof(DateTime));
            dtClientes.Columns.Add("ImgPath", typeof(string));

            if (con == null) this.OpenConnection();
            string query = String.Format(@"SELECT * FROM Clientes");
            try
            {
                com = new SqlCommand(query, con);
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    dtClientes.Rows.Add(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), Convert.ToDateTime(rdr[8].ToString()), rdr[9].ToString());
                }
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                this.CloseConnection();
            }
            return dtClientes;
        }

        public bool UpdateClient(Classes.Cliente cliente)
        {
            if (con == null) this.OpenConnection();
            string query = String.Format(@"UPDATE Clientes SET Nombre = '{0}', APaterno = '{1}', AMaterno = '{2}', Correo = '{3}', RFC = '{4}', Domicilio = '{5}', Telefono = '{6}', ImgPath = '{7}' WHERE IDCliente = {8}", cliente.Nombre, cliente.APaterno, cliente.AMaterno, cliente.Correo, cliente.RFC, cliente.Domicilio, cliente.Telefono, cliente.Path, cliente.ID);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                this.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteClient(Classes.Cliente cliente)
        {
            if (con == null) this.OpenConnection();
            string query = String.Format(@"DELETE FROM Clientes WHERE IDCliente = {0}", cliente.ID);
            try
            {
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                this.CloseConnection();
                return true;
            }
            catch (Exception ex)
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
