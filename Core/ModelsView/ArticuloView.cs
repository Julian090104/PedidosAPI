using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelsView
{
    public class ArticuloView
    {
        public int Idarticulo { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
