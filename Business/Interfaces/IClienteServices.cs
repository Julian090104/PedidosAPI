using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ModelsView;

namespace Business.Interfaces
{
    public interface IClienteServices
    {  
        List<ClienteView> ConsultarServicios();

        ClienteView Buscar(int id);
    }
}
