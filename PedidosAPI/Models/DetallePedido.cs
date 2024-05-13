using System;
using System.Collections.Generic;

namespace PedidosAPI.Models
{
    public partial class DetallePedido
    {
        public int IddetallePedido { get; set; }
        public int Idpedido { get; set; }
        public int Idarticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Articulo IdarticuloNavigation { get; set; } = null!;
        public virtual Pedido IdpedidoNavigation { get; set; } = null!;
    }
}
