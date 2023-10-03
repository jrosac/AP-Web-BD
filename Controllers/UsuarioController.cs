using Marketplace.API.DAO;
using Marketplace.API.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using NpgsqlTypes;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private NpgsqlCommand Command;
        private NpgsqlDataReader DataReader;
        private NpgsqlConnection conn;
        const string connectionString = "Server=database-1.c3tyn5siqwcx.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;User Id=professor;Password=professor;";
        private void OpenConnection(string strConnect) //conexão...
        {
            conn.ConnectionString = strConnect;
            conn.Open(); //conexão aberta!
        }

        private void CloseConnection() //desconectar...
        {
            conn.Close(); //conexão fechada!
        }
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
        public void Post([FromBody] Usuario value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

