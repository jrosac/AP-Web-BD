using Marketplace.API.DAO;
using Marketplace.API.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            UsuarioDAO DAO = new();
            return DAO.Get();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            UsuarioDAO DAO = new();
            return DAO.Get(id);
        }


        // POST api/<UsuarioController>
        [HttpPost]
        public object Post([FromBody] Usuario value)
        {
            UsuarioDAO DAO = new();
            return DAO.Post(value);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Usuario value)
        {
            UsuarioDAO DAO = new();
            return DAO.Put(id, value);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            UsuarioDAO DAO = new();
            return DAO.Delete(id);
        }
    }
}

