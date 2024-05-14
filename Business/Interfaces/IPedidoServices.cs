using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ModelsView;
using Infrastructure.Models;

namespace Business.Interfaces
{
    public interface IPedidoServices
    {
        List<PedidoView> ConsultarServicios();
        PedidoView Buscar(int id);
        Pedido Agregar(int idP, int idC, String estado, DateTime fecha);

        PedidoView Actualizar(int id, PedidoView pedido);

        int Eliminar(int id);
    }
}
