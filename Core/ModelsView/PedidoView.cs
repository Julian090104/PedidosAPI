using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelsView
{
    public class PedidoView
    {
        public int Idpedido { get; set; }
        public DateTime Fecha { get; set; }
        public int Idcliente { get; set; }
        public string Estado { get; set; }
    }
}
