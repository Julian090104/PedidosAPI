using Business.Interfaces;
using Core.ModelsView;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServices _ipedido;

        public PedidoController(IPedidoServices ipedido)
        {
            _ipedido = ipedido;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicios = _ipedido.ConsultarServicios();
                return Ok(listaServicios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var document = _ipedido.Buscar(id);
                if (document == null)
                {
                    return NotFound();
                }
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        public async Task<ActionResult> Post(int idP, int idC, String estado, DateTime fecha)
        {
            try
            {
                // Pasar los parámetros al servicio para agregar el artículo
                var nuevoPedido = _ipedido.Agregar(idP, idC, estado, fecha);

                // Devolver una respuesta indicando la creación exitosa del artículo
                return CreatedAtAction(nameof(GetById), new { id = nuevoPedido.Idpedido }, nuevoPedido);
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error si ocurre una excepción
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PedidoView pedido)
        {
            try
            {
                // Llamar a una función de servicio para actualizar el pedido
                var PedidoActualizado = _ipedido.Actualizar(id, pedido);

                // Devolver una respuesta indicando la actualización exitosa
                return Ok(PedidoActualizado);
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error si ocurre una excepción
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                int document = 0;
                document = _ipedido.Eliminar(id);
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
