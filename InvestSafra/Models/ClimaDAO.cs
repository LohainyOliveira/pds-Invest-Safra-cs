using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Database;
using InvestSafra.Helpers;
using HandyControl.Controls;
using System.Windows.Input;

namespace InvestSafra.Models
{
	internal class ClimaDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Clima clima)
        {


            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Clima value (null, @temperatura, @local, @clima, @data)");



                comando.Parameters.AddWithValue("@temperatura", clima.Temperatura);
                comando.Parameters.AddWithValue("@local", clima.Local);
                comando.Parameters.AddWithValue("@clima", clima.Climatizacao);
                comando.Parameters.AddWithValue("@data", clima.Data?.ToString("yyyy-MM-dd"));

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


        public List<Clima> List()
        {
            try
            {

                var lista = new List<Clima>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Clima";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

               
                    var clima = new Clima();
                    clima.Id = reader.GetInt32("id_clim");
                    clima.Temperatura = reader.GetDouble("temperatura_clim");
                    clima.Local = DAOHelper.GetString(reader, "local_clim");
                    clima.Climatizacao = DAOHelper.GetString(reader, "clima_clim");


                    lista.Add(clima);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Clima clima)
        {
            try
            {
                var comando = _conn.Query();


                comando.CommandText = "UPDATE Clima set  data_clim = @data, temperatura_clim = @temperatura, local_clim = @local, clima_clim = @clima WHERE id_clim = @id";

                comando.Parameters.AddWithValue("@data", clima.Data?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@temperatura", clima.Temperatura);
                comando.Parameters.AddWithValue("@local", clima.Local);
                comando.Parameters.AddWithValue("@clima", clima.Climatizacao);



                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Clima clima)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Clima where id_clim = @id";

                comando.Parameters.AddWithValue("@id", clima.Id);

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
