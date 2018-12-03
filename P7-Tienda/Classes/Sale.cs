using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_ConSQL.Classes
{
    public class Sale
    {

        public int cliente, productos, folio;
        public decimal montoTotal;
        public DateTime fecha;
        public List<ItemEntry> Detalle;

        public Sale()
        {
            this.folio = 0;
            this.cliente = 0;
            this.productos = 0;
            this.montoTotal = 0;
            this.fecha = DateTime.Now;
            this.Detalle = new List<ItemEntry>();
        }


        public Sale(int cliente, decimal montoTotal, int productos, DateTime fecha)
        {
            this.cliente = cliente;
            this.montoTotal = montoTotal;
            this.productos = productos;
            this.fecha = fecha;
            this.Detalle = new List<ItemEntry>();
        }

        public Sale(int folio, int cliente, decimal montoTotal, int productos, DateTime fecha)
        {
            this.cliente = cliente;
            this.montoTotal = montoTotal;
            this.productos = productos;
            this.fecha = fecha;
            this.Detalle = new List<ItemEntry>();
        }

        public void AddItem(ItemEntry item)
        {
            this.Detalle.Add(item);
        }

        public List<ItemEntry> GetProducts()
        {
            return this.Detalle;
        }
        
    }
}
