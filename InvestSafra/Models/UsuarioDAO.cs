using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;

namespace InvestSafra.Models
{
	internal class UsuarioDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Usuario usuario)
        {

            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Usuario  value (null, @user, @senha");


                comando.Parameters.AddWithValue("@user", usuario.User);
                comando.Parameters.AddWithValue("@senha", usuario.User);
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


        public List<Usuario> List()
        {
            try
            {

                var lista = new List<Usuario>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Usuario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var usuario = new Usuario();
                    usuario.Id = reader.GetInt32("id_usu");
                    usuario.User = reader.GetString("user_usu");
                    usuario.Senha = reader.GetString("senha_usu");


                    lista.Add(usuario);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {


                var comando = _conn.Query();

                comando.CommandText = "UPDATE Usuario set user_usu = @user, senha_usu = @senha  WHERE id_usu = @id";

                comando.Parameters.AddWithValue("@user", usuario.User);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Usuario usuario)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Usuario where id_prod = @id";

                comando.Parameters.AddWithValue("@id", usuario.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreu erros ao tentar deletar!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
