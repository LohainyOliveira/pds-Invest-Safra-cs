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
	internal class CompraDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Compra compra)
        {


            try
            {
               
                var comando = _conn.Query();

                comando.CommandText = ("insert into Compra value (null, @nome, @data, @quantidade, @descricao)");



                comando.Parameters.AddWithValue("@nome", compra.Nome);
                comando.Parameters.AddWithValue("@data", compra.Data);
                comando.Parameters.AddWithValue("@quantidade", compra.Quantidade);
                comando.Parameters.AddWithValue("@descricao", compra.Descricao);

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


        public List<Compra> List()
        {
            try
            {

                var lista = new List<Compra>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Compra";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    
                    var compra = new Compra();
                    compra.Id = reader.GetInt32("id_com");
                    compra.Nome = DAOHelper.GetString(reader, "nome_com");
                    compra.Quantidade = reader.GetInt32("quantidade_com");
                    compra.Descricao = DAOHelper.GetString(reader, "descricao_com");
                    compra.Data = DAOHelper.GetDateTime(reader, "data_com");


                    lista.Add(compra);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Compra compra)
        {
            /*id_com int AI PK 
nome_com varchar(100) 
data_com date 
quantidade_com int 
descricao_com varchar(100) 
id_for_fk*/
            try
            {
                var comando = _conn.Query();


                comando.CommandText = "UPDATE Compra set nome_com = @nome, data_com = @data, quantidade_com = @quantidade, descricao_com = @descricao WHERE id_com = @id";

                comando.Parameters.AddWithValue("@nome", compra.Nome);
                comando.Parameters.AddWithValue("@data", compra.Data);
                comando.Parameters.AddWithValue("@quantidade", compra.Quantidade);
                comando.Parameters.AddWithValue("@descricao", compra.Descricao);


                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Compra compra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Compra where id_com = @id";

                comando.Parameters.AddWithValue("@id", compra.Id);

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
