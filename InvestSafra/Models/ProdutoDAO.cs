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
    internal class ProdutoDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Produto produto)
        {
            
            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Produto  value (null, @nome, @descricao, @marca, @quantidade, @valor ");


                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@marca", produto.Marca);
                comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@valor", produto.Valor);

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


        public List<Produto> List()
        {
            try
            {

                var lista = new List<Produto>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                  
                    var produto = new Produto();
                    produto.Id = reader.GetInt32("id_prod");
                    produto.Nome = DAOHelper.GetString(reader, "nome_prod");
                    produto.Descricao = DAOHelper.GetString(reader, "descricao_prod");
                    produto.Descricao = DAOHelper.GetString(reader, "marca_prod");
                    produto.Quantidade = reader.GetInt32("quantidade_prod");
                    produto.Valor = reader.GetDouble("valor_prod");


                    lista.Add(produto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Produto produto )
        {
            try
            {


                var comando = _conn.Query();

                comando.CommandText = "UPDATE Produto set nome_prod = @nome, descricao_prod = @descricao, marca_prod = @marca, quantidade_prod = @quantidade, valor_prod = @valor  WHERE id_prod = @id";

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("marca", produto.Marca);
                comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@valor", produto.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Produto produto)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Produto where id_prod = @id";

                comando.Parameters.AddWithValue("@id", produto.Id);

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
