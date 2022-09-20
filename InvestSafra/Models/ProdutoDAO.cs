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

                comando.CommandText = ("insert into Produto  value (null, @nome, @descricao, @quantidade, @valor ");


                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
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

                    /* public int Id { get; set; }
         public string Nome { get; set; }
         public string Descricao { get; set; }
         public string Quantidade { get; set; }
         public double Valor { get; set; }
            */
                    var produto = new Produto();
                    produto.Id = reader.GetInt32("id_ins");
                    produto.Nome = DAOHelper.GetString(reader, "nome_prod");
                    produto.Descricao = DAOHelper.GetString(reader, "descricao_prod");
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

        public void Update(Insumos insumos)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = "UPDATE Insumo set nome_ins = @nome, tipo_ins = @tipo, marca_ins = @marca, descricao_ins = @descricao  WHERE id_fun = @id";

                comando.Parameters.AddWithValue("@nome", insumos.Nome);
                comando.Parameters.AddWithValue("@tipo", insumos.Tipo);
                comando.Parameters.AddWithValue("@marca", insumos.Marca);
                comando.Parameters.AddWithValue("@descricao", insumos.Descricao);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Insumos insumo)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Insumo where id_ins = @id";

                comando.Parameters.AddWithValue("@id", insumo.Id);

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
