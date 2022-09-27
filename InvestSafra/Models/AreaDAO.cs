using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestSafra.Database;
using InvestSafra.Helpers;
using MySql.Data.MySqlClient;

namespace InvestSafra.Models
{
	internal class AreaDAO
	{

        private static Conexao _conn = new Conexao();
        public void Insert(Area area)
        {
        
            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Area value (null, @nome_responsavel, @nome_terreno, @metros, @cnpj, @localizacao, @descricao)");



                comando.Parameters.AddWithValue("@nome_responsavel", area.Nome_Responsavel);
                comando.Parameters.AddWithValue("@nome_terreno", area.Nome_Terreno);
                comando.Parameters.AddWithValue("@metros", area.Metros);
                comando.Parameters.AddWithValue("@cnpj", area.CNPJ);
                comando.Parameters.AddWithValue("@localizacao", area.Localizacao);
                comando.Parameters.AddWithValue("@descricao", area.Descricao);


                var resultado = comando.ExecuteNonQuery();



                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Area> List()
        {
            try
            {
                var lista = new List<Area>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Area";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    var area = new Area();
                    area.Id = reader.GetInt32("id_are");
                    area.Nome_Responsavel = DAOHelper.GetString(reader, "responsavel_are");
                    area.Nome_Terreno = DAOHelper.GetString(reader, "nome_terren_are");
                    area.Metros = DAOHelper.GetString(reader, "metros_are");
                    area.CNPJ = DAOHelper.GetString(reader, "cnpj_are");
                    area.Localizacao = DAOHelper.GetString(reader, "localizacao_are");
                    area.Descricao = DAOHelper.GetString(reader, "descricao_are");

                    lista.Add(area);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Area area)
        {



            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Area set  responsavel_are = @nome_responsavel, nome_terren_are = @nome_terreno, metros_are =  @metros, cnpj_are = @cnpj, localizacao_are = @localizacao, descricao_are = @descricao WHERE id_are = @id";



                comando.Parameters.AddWithValue("@id", area.Id);
                comando.Parameters.AddWithValue("@nome_responsavel", area.Nome_Responsavel);
                comando.Parameters.AddWithValue("@nome_terreno", area.Nome_Terreno);
                comando.Parameters.AddWithValue("@metros", area.Metros);
                comando.Parameters.AddWithValue("@cnpj", area.CNPJ);
                comando.Parameters.AddWithValue("@localizacao", area.Localizacao);
                comando.Parameters.AddWithValue("@descricao", area.Descricao);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Area area)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Area where id_are = @id";

                comando.Parameters.AddWithValue("@id", area.Id);

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
