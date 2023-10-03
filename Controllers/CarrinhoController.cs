using Marketplace.API.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private NpgsqlCommand Command;
        private NpgsqlDataReader DataReader;
        private NpgsqlConnection conn = new NpgsqlConnection("Server=database-1.c3tyn5siqwcx.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;User Id=professor;Password=professor;");
        // GET: api/<CarrinhoController>
        [HttpGet]
        public IEnumerable<Carrinho> Get()
        {
            return new Carrinho[] { };
        }

        // GET api/<CarrinhoController>/5
        [HttpGet("{id}")]
        public Carrinho Get(int id)
        {
            return null;
        }

        // POST api/<CarrinhoController>
        [HttpPost]
        public void Post([FromBody] Carrinho value)
        {
        }

        // PUT api/<CarrinhoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Carrinho value)
        {
        }

        // DELETE api/<CarrinhoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
