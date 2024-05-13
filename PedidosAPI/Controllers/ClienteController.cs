using Business.Interfaces;
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


        //// GET: api/<ClienteController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        // GET api/<ClienteController>/5


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
