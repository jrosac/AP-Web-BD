using Npgsql;

namespace Marketplace.API.DAO
{
    public class PostgreConn
    {
        protected NpgsqlCommand Command;
        protected NpgsqlDataReader DataReader;
        protected NpgsqlConnection conn;
        const string connectionString = "Server=database-1.c3tyn5siqwcx.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;User Id=professor;Password=professor;";
        protected void OpenConnection() //conexão...
        {
            conn.ConnectionString = connectionString;
            conn.Open(); //conexão aberta!
        }

        protected void CloseConnection() //desconectar...
        {
            conn.Close(); //conexão fechada!
        }
    }
}
