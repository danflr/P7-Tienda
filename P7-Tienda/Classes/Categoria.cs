using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    class Categoria
    {

        public string ID, Nombre;

        public Categoria()
        {

        }

        public Categoria(string ID, string Nombre) {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
