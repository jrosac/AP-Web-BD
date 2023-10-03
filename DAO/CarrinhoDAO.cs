using Marketplace.API.Models;
using Npgsql;

namespace Marketplace.API.DAO
{
    public class CarrinhoDAO : PostgreConn
    {
        public List<Carrinho> Get()
        {
            List<Carrinho> list = new();
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand(
                    $"SELECT idcarrinho, quantidade, preco, comprador_idcomprador " +
                    $"FROM public.carrinho;", conn);

                DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    Carrinho carrinho = new();
                    //NpgsqlArray enderecoArray = new();
                    carrinho.Idcarrinho = DataReader.GetInt32(0);
                    carrinho.Quantidade = DataReader.GetInt32(1);
                    carrinho.Preco = DataReader.GetDouble(2);
                    carrinho.Comprador_IdComprador = DataReader.GetInt32(3);

                    list.Add(carrinho);
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }
        public Carrinho Get(int id)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand(
                    $"SELECT idcarrinho, quantidade, preco, comprador_idcomprador " +
                    $"FROM public.carrinho " +
                    $"WHERE idcarrinho = @id ;", conn);

                Command.Parameters.AddWithValue("@id", id);

                DataReader = Command.ExecuteReader();

                Carrinho carrinho = null;
                if (DataReader.Read())
                {
                    carrinho = new();
                    carrinho.Idcarrinho = DataReader.GetInt32(0);
                    carrinho.Quantidade = DataReader.GetInt32(1);
                    carrinho.Preco = DataReader.GetDouble(2);
                    carrinho.Comprador_IdComprador = DataReader.GetInt32(3);

                }
                else
                {
                    // exce
                }
                return carrinho;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

        }

        public string Post(Carrinho value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                Command = new NpgsqlCommand(
                    $"INSERT INTO public.carrinho( " +
                    $"idcarrinho, quantidade, preco, comprador_idcomprador) " +
                    $"VALUES(@idcarrinho, @quantidade, @preco, @comprador_idcomprador); ", conn);

                Command.Parameters.AddWithValue("@idcarrinho", value.Idcarrinho);
                Command.Parameters.AddWithValue("@quantidade", value.Quantidade);
                Command.Parameters.AddWithValue("@preco", value.Preco);
                Command.Parameters.AddWithValue("@comprador_idcomprador", value.Comprador_IdComprador);



                if (Command.ExecuteNonQuery() > 0)
                {
                    return "Inserido";
                }
                return "Não Inserido";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }


        public string Put(int id, Carrinho value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                Command = new NpgsqlCommand(
                    $"UPDATE public.carrinho " +
                    $"SET idcarrinho=@idcarrinho, quantidade=@quantidade, preco=@preco, comprador_idcomprador=@comprador_idcomprador " +
                    $"WHERE idcarrinho = @id;", conn);

                Command.Parameters.AddWithValue("@idcarrinho", value.Idcarrinho);
                Command.Parameters.AddWithValue("@quantidade", value.Quantidade);
                Command.Parameters.AddWithValue("@preco", value.Preco);
                Command.Parameters.AddWithValue("@comprador_idcomprador", value.Comprador_IdComprador);
                Command.Parameters.AddWithValue("@id", id);

                if (Command.ExecuteNonQuery() > 0)
                {
                    return "Atualizado";
                }
                return "Não Atualizado";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }


        public string Delete(int id)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand(
                      $"DELETE FROM public.carrinho " +
                         $"WHERE idcarrinho = @id;", conn);

                Command.Parameters.AddWithValue("@id", id);


                if (Command.ExecuteNonQuery() > 0)
                {
                    return "deletado com sucesso";
                }
                else
                {
                    return "Erro ao deletar";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();

            }
        }
    }
}
