using Business.Interfaces;
using Core.ModelsView;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _services;

        public ClienteController(IClienteServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicios = _services.ConsultarServicios();
                return Ok(listaServicios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var document = _services.Buscar(id);
                if (document == null)
                {
                    return NotFound("documento nulo");
                }
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClienteController>
        //[HttpPost]
        //public async Task<ActionResult> Post(int id, string nombre, string direccion, string telefono)
        //{
        //    try
        //    {
        //        // Pasar los parámetros al servicio para agregar el Cliente
        //        var nuevoCliente = _services.Agregar(id, nombre, direccion, telefono);

        //        // Devolver una respuesta indicando la creación exitosa del Cliente
        //        return Ok(new { message = "egregado con exito" });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Devolver una respuesta de error si ocurre una excepción
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteView cliente)
        {
            try
            {
                var nuevoCliente = _services.Agregar(cliente.Idcliente, cliente.Nombre, cliente.Direccion, cliente.Telefono);
                return Ok(new { message = "Agregado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteView cliente)
        {
            try
            {
                // Llamar a una función de servicio para actualizar el cliente
                var clienteActualizado = _services.Actualizar(id, cliente);

                // Devolver una respuesta indicando la actualización exitosa
                return Ok(clienteActualizado);
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error si ocurre una excepción
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                int document = 0;
                document = _services.Eliminar(id);
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
