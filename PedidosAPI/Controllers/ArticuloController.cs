using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloServices _services;

        public ArticuloController(IArticuloServices services)
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var document = _services.Buscar(id);
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


        // POST api/<ArticuloController>
        [HttpPost]
        public async Task<ActionResult> Post(int id, string descripcion, decimal precio, int stock)
        {
            try
            {
                // Pasar los parámetros al servicio para agregar el artículo
                var nuevoArticulo = _services.Agregar(id, descripcion, precio, stock);

                // Devolver una respuesta indicando la creación exitosa del artículo
                return CreatedAtAction(nameof(GetById), new { id = nuevoArticulo.Idarticulo }, nuevoArticulo);
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error si ocurre una excepción
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArticuloView articulo)
        {
            try
            {
                // Llamar a una función de servicio para actualizar el artículo
                var articuloActualizado = _services.Actualizar(id, articulo);

                // Devolver una respuesta indicando la actualización exitosa
                return Ok(articuloActualizado);
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error si ocurre una excepción
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<ArticuloController>/5
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
