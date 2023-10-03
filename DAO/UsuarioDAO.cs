using Marketplace.API.Models;
using Npgsql;
using System.Collections.Generic;

namespace Marketplace.API.DAO
{
    public class UsuarioDAO : PostgreConn
    {
        public List<Usuario> Get()
        {
            List<Usuario> list = new();
            try
            {
                conn = new NpgsqlConnection();
                OpenConnection();
                Command = new NpgsqlCommand("SELECT id_usuario, email, senha, conta_bancaria, nome, endereco, telefone FROM public.usuario;", conn);

                DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                {
                    Usuario usuario = new();
                    //NpgsqlArray enderecoArray = new();
                    usuario.id_usuario = DataReader.GetInt32(0);
                    usuario.email = DataReader.GetString(1);
                    usuario.senha = DataReader.GetString(2);
                    usuario.conta_bancaria = DataReader.GetString(3);
                    usuario.nome = DataReader.GetString(4);
                    // usuario.endereco = DataReader.GetFieldValue<Endereco>(5);
                    usuario.telefone = DataReader.GetFieldValue<int[]>(6);
                    list.Add(usuario);
                }
                else
                {
                    // exce
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
                    //NpgsqlArray enderecoArray = new();
                    usuario.id_usuario = DataReader.GetInt32(0);
                    usuario.email = DataReader.GetString(1);
                    usuario.senha = DataReader.GetString(2);
                    usuario.conta_bancaria = DataReader.GetString(3);
                    usuario.nome = DataReader.GetString(4);
                    // usuario.endereco = DataReader.GetFieldValue<Endereco>(5);
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
            return null;
        }
    }
}
