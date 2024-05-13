 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Implementations
{
    public class PedidoServices : IPedidoServices 
    {
        private readonly GestionPedidosContext _bcontext;

        public PedidoServices() { }

        public PedidoServices(GestionPedidosContext bcontext)
        {
            _bcontext = bcontext;
        }

        public List<PedidoView> ConsultarServicios()

        {
            List<PedidoView> listaPedidoView = new List<PedidoView>();
            var listServicios = _bcontext.Pedidos.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    PedidoView pedidoView = new PedidoView()
                    {
                        Idcliente = item.Idcliente,
                        Idpedido = item.Idpedido,
                        Estado = item.Estado,
                        Fecha = item.Fecha,

                    };
                    listaPedidoView.Add(pedidoView);
                }
            }
            return listaPedidoView;
        }


    }
}
