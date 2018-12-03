using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    public class ItemEntry
    {
        public Producto producto;
        public int cantidad;
        public decimal monto;


        public ItemEntry()
        {

        }

        public ItemEntry(Producto producto)
        {
            this.producto = producto;
        }

        public ItemEntry(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.monto = producto.precio * cantidad;
        }

        public void UpdateAmount(int newAmount)
        {
            cantidad = newAmount;
            monto = cantidad * producto.precio;
        }

    }
}
