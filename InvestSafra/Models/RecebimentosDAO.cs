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
    internal class RecebimentosDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Recebimentos recebimento )
        {


            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Recebimento  value (null, @valor_venda, @data, @comprador ");

                

                comando.Parameters.AddWithValue("@valor_venda", recebimento.Valor_Venda_Safra);
                comando.Parameters.AddWithValue("@ddata", recebimento.Data);
                comando.Parameters.AddWithValue("@comprador", recebimento.Comprador);

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


        public List<Recebimentos> List()
        {
            try
            {

                var lista = new List<Recebimentos>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Recebimento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var recebimento = new Recebimentos();
                    recebimento.Id = reader.GetInt32("id_rec");
                    recebimento.Valor_Venda_Safra = reader.GetDouble("valor_venda_rec");
                    recebimento.Data = reader.GetDateTime("data_rec");
                    recebimento.Comprador = reader.GetString("comprador_rec");

                    lista.Add(recebimento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Recebimentos recebimento)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = "UPDATE Recebimento set valor_venda_rec = @valor_venda, data_rec = @data, comprador_rec = @comprador WHERE id_rec = @id";

                comando.Parameters.AddWithValue("@valor_venda", recebimento.Valor_Venda_Safra);
                comando.Parameters.AddWithValue("@data", recebimento.Data);
                comando.Parameters.AddWithValue("@comprador", recebimento.Comprador);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Recebimentos recebimento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Recebimento where id_maq = @id";

                comando.Parameters.AddWithValue("@id", recebimento.Id);

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

