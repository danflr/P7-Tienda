using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.DataAccess
{
    class Producto
    {
        private string SKU, nombre, descripcion, categoria;
        private decimal precio;

        public Producto()
        {

        }

        public Producto(string SKU, string nombre, string descripcion, string categoria, decimal precio)
        {
            this.SKU = SKU;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
        }

    }
}
