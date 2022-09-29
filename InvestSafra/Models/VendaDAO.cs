using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;

namespace InvestSafra.Models
{
	internal class VendaDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Venda venda)
        {

            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Venda  value (null, @valor, @data, @safra, @comprador");


                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@data", venda.Data);
                comando.Parameters.AddWithValue("@safra", venda.Safra);
                comando.Parameters.AddWithValue("@comprador", venda.Comprador);

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


        public List<Venda> List()
        {
            try
            {

                var lista = new List<Venda>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Venda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var venda = new Venda();
                    venda.Id = reader.GetInt32("id_ven");
                    venda.Valor = reader.GetDouble("valor_ven");
                    venda.Data = reader.GetDateTime("data_ven");
                    venda.Safra = reader.GetString( "safra_ven");
                    venda.Comprador = reader.GetString("comprador_ven");


                    lista.Add(venda);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Venda venda)
        {
            try
            {


                var comando = _conn.Query();

                comando.CommandText = "UPDATE Venda set valor_ven = @valor, data_ven = @data, safra_ven = @safra, comprador_ven = @comprador WHERE id_ven = @id";

                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@data", venda.Data);
                comando.Parameters.AddWithValue("safra", venda.Safra);
                comando.Parameters.AddWithValue("@comprador", venda.Comprador);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Venda venda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Venda where id_ven = @id";

                comando.Parameters.AddWithValue("@id", venda.Id);

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
