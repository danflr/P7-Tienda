using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    public class Producto
    {
        public string SKU, nombre, descripcion, categoria;
        public string imageData;
        public decimal precio;

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
            this.imageData = null;
        }

        public Producto(string SKU, string nombre, string descripcion, string categoria, decimal precio, string imageData)
        {
            this.SKU = SKU;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
            this.imageData = imageData;
        }

        public void setImage(string imageData)
        {
            try
            {
                this.imageData = imageData;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
