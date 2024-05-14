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

        public PedidoView Buscar(int id)
        {
            var pedidosSearch = _bcontext.Pedidos.Find(id);
            if (pedidosSearch == null)
            {
                return null;
            }
            var pedidoSearchView = new PedidoView
            {

                Idcliente = pedidosSearch.Idcliente,
                Idpedido = pedidosSearch.Idpedido,
                Fecha = pedidosSearch.Fecha,
                Estado = pedidosSearch.Estado,
            };

            return pedidoSearchView;
        }

        public Pedido Agregar(int idP, int idC, String estado, DateTime fecha)
        {
            // Verificar si el ID ya existe en la base de datos
            var existePedido = _bcontext.Pedidos.Any(a => a.Idpedido == idP);
            if (existePedido)
            {
                throw new Exception("El ID del Pedido ya existe en la base de datos.");
            }

            // Agregar el nuevo Pedido
            var nuevoPedido = new Pedido
            {
                Idpedido = idP,
                Fecha = fecha,
                Idcliente = idC,
                Estado = estado
            };

            _bcontext.Pedidos.Add(nuevoPedido);
            _bcontext.SaveChanges();

            return nuevoPedido;
        }

        public PedidoView Actualizar(int id, PedidoView pedido)
        {
            // Buscar el artículo por su ID
            var pedidoExistente = _bcontext.Pedidos.Find(id);
            if (pedidoExistente == null)
            {
                throw new Exception("El pedido no existe.");
            }

            // Actualizar los datos del artículo con los valores proporcionados
            pedidoExistente.Fecha = pedido.Fecha;
            pedidoExistente.Estado = pedido.Estado;
            pedidoExistente.Idcliente = pedido.Idcliente;

            // Guardar los cambios en la base de datos
            _bcontext.SaveChanges();

            // Devolver el artículo actualizado
            return new PedidoView
            {
                Idpedido = pedidoExistente.Idpedido,
                Fecha = pedidoExistente.Fecha,
                Estado = pedidoExistente.Estado,
                Idcliente = pedidoExistente.Idcliente
            };
        }
        public int Eliminar(int id)
        {
            var pedidoEliminar = _bcontext.Pedidos.Find(id);
            _bcontext.Pedidos.Remove(pedidoEliminar);
            _bcontext.SaveChanges();
            return id;
        }


    }
}
