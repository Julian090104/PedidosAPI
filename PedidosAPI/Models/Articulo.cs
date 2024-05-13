using System;
using System.Collections.Generic;

namespace PedidosAPI.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int Idarticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
