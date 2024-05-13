using System;
using System.Collections.Generic;

namespace PedidosAPI.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int Idpedido { get; set; }
        public DateTime Fecha { get; set; }
        public int Idcliente { get; set; }
        public string Estado { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
