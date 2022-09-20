using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;
using InvestSafra.Helpers;

namespace InvestSafra.Models
{
	internal class FazendaDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Fazenda fazenda)
        {


            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Fazenda value (null, @nome, @nomeFantasia, @proprietario, @cnpj, @localizacao, @complemento");



                comando.Parameters.AddWithValue("@nome", fazenda.Nome);
                comando.Parameters.AddWithValue("@nomeFantasia", fazenda.NomeFantasia);
                comando.Parameters.AddWithValue("@proprietario", fazenda.Proprietario);
                comando.Parameters.AddWithValue("@cnpj", fazenda.CNPJ);
                comando.Parameters.AddWithValue("@localizacao", fazenda.Localizacao);
                comando.Parameters.AddWithValue("@complemento", fazenda.Complemento);

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


        public List<Fazenda> List()
        {
            try
            {

                var lista = new List<Fazenda>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Fazenda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    
                    var fazenda = new Fazenda();
                    fazenda.Id = reader.GetInt32("id_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "nome_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "nome_fantasia_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "proprietario_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "cnpj_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "localizacao_faze");
                    fazenda.Nome = DAOHelper.GetString(reader, "complemento_faze");

                    lista.Add(fazenda);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Fazenda fazenda)
        {
            try
            {
                var comando = _conn.Query();


                comando.CommandText = "UPDATE Fazenda set nome_faze = @nome, nome_faze = @nomeFantasia, proprietario_faze = @proprietario, cnpj_faze = @cnpj, localizacao_faze = @localizacao, complemento_faze = @complemento  WHERE id_faze = @id";

                comando.Parameters.AddWithValue("@nome", fazenda.Nome);
                comando.Parameters.AddWithValue("@nomeFantasia", fazenda.NomeFantasia);
                comando.Parameters.AddWithValue("@proprietario", fazenda.Proprietario);
                comando.Parameters.AddWithValue("@cnpj", fazenda.CNPJ);
                comando.Parameters.AddWithValue("@localizacao", fazenda.Localizacao);
                comando.Parameters.AddWithValue("@complemento", fazenda.Complemento);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Fazenda fazenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Fazenda where id_faze = @id";

                comando.Parameters.AddWithValue("@id", fazenda.Id);

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
