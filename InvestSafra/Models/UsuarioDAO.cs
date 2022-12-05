using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;

namespace InvestSafra.Models
{
    internal class UsuarioDAO: AbstractDAO<Usuario>
    {
        private static Conexao _conn = new Conexao();
        public void Insert (Usuario usuario)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("Call InsertUsuario (@usuario, @senha, @funcionario)");

                comando.Parameters.AddWithValue("@usuario", usuario.UsuarioNome);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@Funcionario", usuario.Id);

                var resultado = comando.ExecuteNonQuery();


                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações!!!");
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public Usuario GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario LEFT JOIN Funcionario ON id_fun = id_fun_fk " +
                    "WHERE usuario_user = @usuario AND senha_user = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("id_user");
                    usuario.UsuarioNome = reader.GetString("usuario_user");
                    usuario.Funcionario = new Funcionario() { Id = reader.GetInt32("id_fun"), Nome = reader.GetString("nome_fun") };
                }

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
