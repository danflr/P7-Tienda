using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    public class Proveedor
    {
        public int ID;
        public string nombre, domicilio, telefono, correo, path;

        public Proveedor()
        {

        }

        public Proveedor(int ID, string nombre, string domicilio, string telefono, string correo, string path)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.correo = correo;
            this.path = path;
        }

    }
}
