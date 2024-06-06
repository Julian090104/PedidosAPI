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
                Direccion = clienteSearch.Direccion,
                Telefono = clienteSearch.Telefono,
            };

            return clienteSearchView;
        }

        public Cliente Agregar(int id, string nombre, string direccion, string telefono)
        {
            // Verificar si el ID ya existe en la base de datos
            var existeCliente = _bcontext.Clientes.Any(a => a.Idcliente == id);
            if (existeCliente)
            {
                throw new Exception("El ID del cliente ya existe en la base de datos.");
            }

            // Validar otros campos si es necesario
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("El nombre del cliente es obligatoria.");
            }
            // Agregar el nuevo cliente
            var nuevoCliente = new Cliente
            {
                Idcliente = id,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
            };

            _bcontext.Clientes.Add(nuevoCliente);
            _bcontext.SaveChanges();

            return nuevoCliente;
        }

        public ClienteView Actualizar(int id, ClienteView cliente)
        {
            // Buscar el artículo por su ID
            var clienteExistente = _bcontext.Clientes.Find(id);
            if (clienteExistente == null)
            {
                throw new Exception("El cliente no existe.");
            }

            // Actualizar los datos del cliente con los valores proporcionados
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.Telefono = cliente.Telefono;

            // Guardar los cambios en la base de datos
            _bcontext.SaveChanges();

            // Devolver el cliente actualizado
            return new ClienteView
            {
                Idcliente = clienteExistente.Idcliente,
                Nombre = clienteExistente.Nombre,
                Direccion = clienteExistente.Direccion,
                Telefono = clienteExistente.Telefono,
            };
        }

        //public int Eliminar(int id)
        //{
        //    var clienteEliminar = _bcontext.Clientes.Find(id);
        //    _bcontext.Clientes.Remove(clienteEliminar);
        //    _bcontext.SaveChanges();
        //    return id;

        //}

        public int Eliminar(int id)
        {
            try
            {
                var clienteEliminar = _bcontext.Clientes.Find(id);
                if (clienteEliminar != null)
                {
                    _bcontext.Clientes.Remove(clienteEliminar);
                    _bcontext.SaveChanges();
                }
                return id;
            }
            catch (DbUpdateException ex)
            {
                // Captura la excepción interna para obtener más detalles
                throw new Exception("Error al eliminar el cliente. Detalles: " + ex.InnerException?.Message, ex);
            }
        }


    }
}
