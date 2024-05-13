using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;

namespace Business.Implementations
{
    public class ClienteServices : IClienteServices
    {
        private readonly GestionPedidosContext _bcontext;

        public ClienteServices() { }

        public ClienteServices(GestionPedidosContext bcontext)
        {
            _bcontext = bcontext;
        }

        public List<ClienteView> ConsultarServicios()

        {
            List<ClienteView> listaClienteView = new List<ClienteView>();
            var listServicios = _bcontext.Clientes.ToList();
            if (listServicios != null)
            {
                foreach (var item in listServicios)
                {
                    ClienteView ClienteView = new ClienteView()
                    {
                        Idcliente = item.Idcliente,
                        Nombre = item.Nombre,
                        Direccion = item.Direccion,
                        Telefono = item.Telefono,

                    };
                    listaClienteView.Add(ClienteView);
                }
            }
            return listaClienteView;
        }

        public ClienteView Buscar(int id)
        {
            var clienteSearch = _bcontext.Clientes.Find(id);
            if (clienteSearch == null)
            {
                return null;
            }
            var clienteSearchView = new ClienteView
            {
                Idcliente = clienteSearch.Idcliente,
                Nombre = clienteSearch.Nombre, 
                Direccion= clienteSearch.Direccion,
                Telefono= clienteSearch.Telefono,
            };

            return clienteSearchView;
        }



    }
}
