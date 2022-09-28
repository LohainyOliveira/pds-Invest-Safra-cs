using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;
namespace InvestSafra.Models
{
	internal class SafraDAO
	{private static Conexao _conn = new Conexao();
        public void Insert(Safra safra)
        {


            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Safra  value (null, @nome, @tipo ");


                comando.Parameters.AddWithValue("@nome", safra.Nome);
                comando.Parameters.AddWithValue("@tipo", safra.Tipo);

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


        public List<Safra> List()
        {
            try
            {

                var lista = new List<Safra>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Safra";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var safra = new Safra();
                    safra.Id = reader.GetInt32("id_saf");
                    safra.Nome = reader.GetString("nome_saf");
                    safra.Tipo = reader.GetString("tipo_saf");

                    lista.Add(safra);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Safra safra)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = "UPDATE Safra set nome_saf = @nome, tipo_saf = @tipo WHERE id_saf = @id";

                comando.Parameters.AddWithValue("@nome", safra.Nome);
                comando.Parameters.AddWithValue("@tipo", safra.Tipo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Safra safra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Safra where id_saf = @id";

                comando.Parameters.AddWithValue("@id", safra.Id);

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