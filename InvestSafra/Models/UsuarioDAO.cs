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
        public void Insert(ClienteFisico clienteF, int IdCliente)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "Call (@nomeUsu, @senha, @idCliente);";

                comando.Parameters.AddWithValue("@nomeUsu", usuarioNome);
                comando.Parameters.AddWithValue("@senha", senha);
                comando.Parameters.AddWithValue("@idCliente", IdCliente);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Usuario GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario LEFT JOIN Cliente_fisico ON id_cliF = id_cliF_fk " +
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
                    usuario.Cliente = new ClienteFisico() { Id = reader.GetInt32("id_CliF"), Nome = reader.GetString("nome_cliF") };
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
