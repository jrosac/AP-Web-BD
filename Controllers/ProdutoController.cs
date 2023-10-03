using Marketplace.API.DAO;
using Marketplace.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        
        // GET: api/<ProdutoController>
        [HttpGet]
        public object Get()
        {
            ProdutoDAO DAO = new();
            return DAO.Get();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            ProdutoDAO DAO = new();
            return DAO.Get(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public object Post([FromBody] Produto value)
        {
            ProdutoDAO DAO = new();
            return DAO.Post(value);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Produto value)
        {
            ProdutoDAO DAO = new();
            return DAO.Put(id,value);
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            ProdutoDAO DAO = new();
            return DAO.Delete(id);
        }
    }
}
