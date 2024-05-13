using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelsView
{
    public class DetallePedidoView
    {
        public int IddetallePedido { get; set; }
        public int Idpedido { get; set; }
        public int Idarticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
