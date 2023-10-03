using Marketplace.API.Models;
using Npgsql;

namespace Marketplace.API.DAO
{
    public class UsuarioDAO : PostgreConn
    {

       public UsuarioDAO()
    {
        NpgsqlConnection.GlobalTypeMapper.MapComposite<endereco_type>("endereco_type");
    }    
        
        public List<Usuario> Get()
        {
            List<Usuario> list = new();
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand("SELECT id_usuario, email, senha, conta_bancaria, nome, u.endereco, telefone FROM public.usuario u;", conn);


                DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {

                            Usuario usuario = new Usuario
                            {
                                id_usuario = DataReader.GetInt32(0),
                                email = DataReader.GetString(1),
                                senha = DataReader.GetString(2),
                                conta_bancaria = DataReader.GetString(3),
                                nome = DataReader.GetString(4),
                                endereco = DataReader.GetFieldValue<endereco_type>(5),
                                telefone = DataReader.GetFieldValue<int[]>(6)
                            };
                            list.Add(usuario);
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
        public Usuario Get(int id)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand($"SELECT id_usuario, email, senha, conta_bancaria, nome, endereco, telefone" +
                    $" FROM public.usuario" +
                    $" WHERE id_usuario = {id};", conn);

                DataReader = Command.ExecuteReader();

                Usuario usuario = new(); ;
                if (DataReader.Read())
                {
                    // NpgsqlArray enderecoArray = new();
                    usuario.id_usuario = DataReader.GetInt32(0);
                    usuario.email = DataReader.GetString(1);
                    usuario.senha = DataReader.GetString(2);
                    usuario.conta_bancaria = DataReader.GetString(3);
                    usuario.nome = DataReader.GetString(4);
                    usuario.endereco = DataReader.GetFieldValue<endereco_type>(5);
                    usuario.telefone = DataReader.GetFieldValue<int[]>(6);
                }
                else
                {
                    // exce
                }
                return usuario;
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

        public string Post(Usuario value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                var end = value.endereco;
                string telefoneSTR = "'{";
                for (int i = 0; i < value.telefone.Length; i++)
                {
                    telefoneSTR += value.telefone[i].ToString();
                    if (i != 0 && i != value.telefone.Length - 1) telefoneSTR += ",";
                }
                telefoneSTR += "}'";

                string enderecoSTR = $"({end.cep},'{end.logradouro}','{end.bairro}',{end.numero},'{end.cidade}','{end.estado}')";

                Command = new NpgsqlCommand(
                    $"INSERT INTO public.usuario " +
                    $"( id_usuario, email, senha, conta_bancaria, nome, endereco, telefone) " +
                    $"VALUES (@id_usuario, @email, @senha, @conta_bancaria, @nome, {enderecoSTR}, {telefoneSTR});", conn);

                Command.Parameters.AddWithValue("@id_usuario", value.id_usuario);
                Command.Parameters.AddWithValue("@email", value.email);
                Command.Parameters.AddWithValue("@senha", value.senha);
                Command.Parameters.AddWithValue("@conta_bancaria", value.conta_bancaria);
                Command.Parameters.AddWithValue("@nome", value.nome);
                //       Command.Parameters.AddWithValue("@endereco", enderecoSTR);
                //  Command.Parameters.AddWithValue("@telefone", telefoneSTR);


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


        public string Put(int id, Usuario value)
        {
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();

                var end = value.endereco;
                string telefoneSTR = "'{";
                for (int i = 0; i < value.telefone.Length; i++)
                {
                    telefoneSTR += value.telefone[i].ToString();
                    if (i != 0 && i != value.telefone.Length - 1) telefoneSTR += ",";
                }
                telefoneSTR += "}'";

                string enderecoSTR = $"({end.cep} ,'{end.logradouro}','{end.bairro}', {end.numero} ,'{end.cidade}','{end.estado}')";

                Command = new NpgsqlCommand(
                    $"UPDATE public.usuario " +
                    $"SET id_usuario=@id_usuario, email=@email, senha=@senha, conta_bancaria=@conta_bancaria, nome=@nome, endereco={enderecoSTR}, telefone={telefoneSTR} " +
                    $"WHERE id_usuario = {id};", conn);

                Command.Parameters.AddWithValue("@id_usuario", value.id_usuario);
                Command.Parameters.AddWithValue("@email", value.email);
                Command.Parameters.AddWithValue("@senha", value.senha);
                Command.Parameters.AddWithValue("@conta_bancaria", value.conta_bancaria);
                Command.Parameters.AddWithValue("@nome", value.nome);
                //       Command.Parameters.AddWithValue("@endereco", enderecoSTR);
                //  Command.Parameters.AddWithValue("@telefone", telefoneSTR);


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
                      $"DELETE FROM public.usuario " +
                      $"WHERE id_usuario = {id};", conn);

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