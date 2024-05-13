using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ModelsView;
using Infrastructure.Models;

namespace Business.Interfaces
{
    public interface IClienteServices
    {  
        List<ClienteView> ConsultarServicios();

        ClienteView Buscar(int id);

        Cliente Agregar(int id, string nombre, string direccion, string telefono);

        ClienteView Actualizar(int id, ClienteView cliente);
    }
}
