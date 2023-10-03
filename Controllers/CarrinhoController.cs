using Marketplace.API.DAO;
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
        public object Get()
        {
            CarrinhoDAO DAO = new();
            return DAO.Get();
        }

        // GET api/<CarrinhoController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            CarrinhoDAO DAO = new();
            return DAO.Get(id);
        }

        // POST api/<CarrinhoController>
        [HttpPost]
        public object Post([FromBody] Carrinho value)
        {
            CarrinhoDAO DAO = new();
            return DAO.Post(value);
        }

        // PUT api/<CarrinhoController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Carrinho value)
        {
            CarrinhoDAO DAO = new();
            return DAO.Put(id, value);
        }

        // DELETE api/<CarrinhoController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            CarrinhoDAO DAO = new();
            return DAO.Delete(id);
        }
    }
}
