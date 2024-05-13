using System;
using System.Collections.Generic;

namespace PedidosAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Idcliente { get; set; }
        public string Nombre { get; set; } 
        public string Direccion { get; set; } 
        public string Telefono { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
