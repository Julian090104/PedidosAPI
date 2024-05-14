using Core.ModelsView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
 