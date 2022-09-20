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
	internal class EstoqueDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Estoque estoque)
        {
            

            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Estoque value (null, @qtd_semente, @qtd_insumo, @tipo_insumo, @medida, @descricao)");



                comando.Parameters.AddWithValue("@qtd_semente", estoque.Quantidade_Semente);
                comando.Parameters.AddWithValue("@qtd_insumo", estoque.Quantidade_Insumos);
                comando.Parameters.AddWithValue("@tipo_insumo", estoque.Tipo_Insumo);
                comando.Parameters.AddWithValue("@medida", estoque.Medida);
                comando.Parameters.AddWithValue("@descricao", estoque.Descricao);
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


        public List<Estoque> List()
        {
            try
            {

                var lista = new List<Estoque>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Estoque";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                 

                    var estoque = new Estoque();
                    estoque.Id = reader.GetInt32("id_est");
                    estoque.Quantidade_Semente = reader.GetInt32("qtdd_sement_est");
                    estoque.Quantidade_Insumos = reader.GetInt32("qtdd_insum_est");
                    estoque.Tipo_Insumo = DAOHelper.GetString(reader, "tipo_insum_est");
                    estoque.Medida = DAOHelper.GetString(reader, "medida_est");
                    estoque.Descricao = DAOHelper.GetString(reader, "descricao_est");

                    lista.Add(estoque);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Estoque estoque)
        {
            try
            {
                var comando = _conn.Query();
              

                comando.CommandText = "UPDATE Estoque set  qtdd_sement_est = @qtd_semente, qtdd_insum_est = @qtd_insumo, tipo_insum_est = @tipo_insumo, medida_est = @medida, descricao_est = @descricao WHERE id_est = @id";

                comando.Parameters.AddWithValue("@qtd_semente", estoque.Quantidade_Semente);
                comando.Parameters.AddWithValue("@qtd_insumo", estoque.Quantidade_Insumos);
                comando.Parameters.AddWithValue("@tipo_insumo", estoque.Tipo_Insumo);
                comando.Parameters.AddWithValue("@medida", estoque.Medida);
                comando.Parameters.AddWithValue("@descricao", estoque.Descricao);


                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Estoque estoque )
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Estoque where id_est = @id";

                comando.Parameters.AddWithValue("@id", estoque.Id);

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
