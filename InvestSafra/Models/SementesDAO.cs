using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;

namespace InvestSafra.Models
{
	internal class SementesDAO
    {
		private static Conexao _conn = new Conexao();
        public void Insert(Sementes semente)
        {


            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Semente  value (null, @marca, @descricao, @quantidade, @medida ");


                comando.Parameters.AddWithValue("@marca", semente.Marca);
                comando.Parameters.AddWithValue("@descricao", semente.Descricao);
                comando.Parameters.AddWithValue("@quantidade", semente.Quantidade);
                comando.Parameters.AddWithValue("@medida", semente.Medida);
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


        public List<Sementes> List()
        {
            try
            {

                var lista = new List<Sementes>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Semente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var semente = new Sementes();
                    semente.Id = reader.GetInt32("id_sem");
                    semente.Marca = reader.GetString("marca_sem");
                    semente.Descricao = reader.GetString("descricao_sem");
                    semente.Quantidade = reader.GetDouble("quantidade_sem");
                    semente.Medida = reader.GetString("medida_sem");

                    lista.Add(semente);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Sementes semente)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = "UPDATE Semente set nome_saf = @nome, tipo_saf = @tipo WHERE id_saf = @id";

                comando.Parameters.AddWithValue("@marca", semente.Marca);
                comando.Parameters.AddWithValue("@descricao", semente.Descricao);
                comando.Parameters.AddWithValue("@quantidade", semente.Quantidade);
                comando.Parameters.AddWithValue("@medida", semente.Medida);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Sementes semente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Semente where id_saf = @id";

                comando.Parameters.AddWithValue("@id", semente.Id);

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
