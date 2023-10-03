using Marketplace.API.Models;
using Npgsql;

namespace Marketplace.API.DAO
{
    public class ProdutoDAO : PostgreConn
    {
        public List<Produto> Get()
        {
            List<Produto> list = new();
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand(
                    $"SELECT idproduto, preco, categoria, condicao, nome, descricao, foto, dimensoes, vendedor_idvendedor " +
                    $"FROM public.produto;", conn);

                DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    Produto produto = new();

                    produto.IdProduto = DataReader.GetInt32(0);
                    produto.Preco = DataReader.GetDouble(1);
                    produto.Categoria = DataReader.GetString(2);
                    produto.Condicao = DataReader.GetString(3);
                    produto.Nome = DataReader.GetString(4);
                    produto.Descricao = DataReader.GetString(5);
                    produto.Foto = DataReader.GetFieldValue<byte[]>(6);
                    produto.Dimensoes = DataReader.GetString(7);
                    produto.Vendedor_IdVendedor = DataReader.GetInt32(8);

                    list.Add(produto);
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
        }
        public Produto Get(int id)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand(
                    $"SELECT idproduto, preco, categoria, condicao, nome, descricao, foto, dimensoes, vendedor_idvendedor " +
                    $"FROM public.produto " +
                    $"WHERE idproduto = @id ;", conn);

                Command.Parameters.AddWithValue("@id", id);

                DataReader = Command.ExecuteReader();

                Produto produto = null;
                if (DataReader.Read())
                {
                    produto = new();

                    produto.IdProduto = DataReader.GetInt32(0);
                    produto.Preco = DataReader.GetDouble(1);
                    produto.Categoria = DataReader.GetString(2);
                    produto.Condicao = DataReader.GetString(3);
                    produto.Nome = DataReader.GetString(4);
                    produto.Descricao = DataReader.GetString(5);
                    produto.Foto = DataReader.GetFieldValue<byte[]>(6);
                    produto.Dimensoes = DataReader.GetString(7);
                    produto.Vendedor_IdVendedor = DataReader.GetInt32(8);
                }
                return produto;
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

        public object Post(Produto value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                Command = new NpgsqlCommand(
                    $"INSERT INTO public.produto( " +
                    $"idproduto, preco, categoria, condicao, nome, descricao, foto, dimensoes, vendedor_idvendedor) " +
                    $"VALUES (@idproduto, @preco, @categoria, @condicao, @nome, @descricao, @foto, @dimensoes, @vendedor_idvendedor);", conn);

                Command.Parameters.AddWithValue("@idproduto", value.IdProduto);
                Command.Parameters.AddWithValue("@preco", value.Preco);
                Command.Parameters.AddWithValue("@categoria", value.Categoria);
                Command.Parameters.AddWithValue("@condicao", value.Condicao);
                Command.Parameters.AddWithValue("@nome", value.Nome);
                Command.Parameters.AddWithValue("@descricao", value.Descricao);
                Command.Parameters.AddWithValue("@foto", value.Foto);
                Command.Parameters.AddWithValue("@dimensoes", value.Dimensoes);
                Command.Parameters.AddWithValue("@vendedor_idvendedor", value.Vendedor_IdVendedor);

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


        public string Put(int id, Produto value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                Command = new NpgsqlCommand(
                    $"UPDATE public.produto " +
                    $"SET idproduto=@idproduto, preco=@preco, categoria=@categoria, condicao=@condicao, nome=@nome, " +
                    $"descricao=@descricao, foto=@foto, dimensoes=@dimensoes, vendedor_idvendedor=@vendedor_idvendedor " +
                    $"WHERE idproduto = @id ;", conn);

                Command.Parameters.AddWithValue("@idproduto", value.IdProduto);
                Command.Parameters.AddWithValue("@preco", value.Preco);
                Command.Parameters.AddWithValue("@categoria", value.Categoria);
                Command.Parameters.AddWithValue("@condicao", value.Condicao);
                Command.Parameters.AddWithValue("@nome", value.Nome);
                Command.Parameters.AddWithValue("@descricao", value.Descricao);
                Command.Parameters.AddWithValue("@foto", value.Foto);
                Command.Parameters.AddWithValue("@dimensoes", value.Dimensoes);
                Command.Parameters.AddWithValue("@vendedor_idvendedor", value.Vendedor_IdVendedor);
                
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
                      $"DELETE FROM public.produto " +
                      $"WHERE idproduto = @id ;", conn);

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
