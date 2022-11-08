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
