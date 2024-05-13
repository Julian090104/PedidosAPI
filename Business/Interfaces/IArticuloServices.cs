using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ModelsView;
using Infrastructure.Models;

namespace Business.Interfaces
{
    public interface IArticuloServices
    {
            List<ArticuloView> ConsultarServicios();
            ArticuloView Buscar(int id);        
            Articulo Agregar(int id, string descripcion, decimal precio, int stock);
            ArticuloView Actualizar(int id, ArticuloView articulo);
            int Eliminar(int id);
    }
}
