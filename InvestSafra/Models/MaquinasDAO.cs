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
	internal class MaquinasDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Maquinas maquinas)
        {


            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Maquinas  value (null, @nome, @descricao, @modelo, @marca, @quantidade, @valor");


                comando.Parameters.AddWithValue("@nome", maquinas.Nome);
                comando.Parameters.AddWithValue("@modelo", maquinas.Modelo);
                comando.Parameters.AddWithValue("@marca", maquinas.Marca);
                comando.Parameters.AddWithValue("@quantidade", maquinas.Quantidade);

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


        public List<Maquinas> List()
        {
            try
            {

                var lista = new List<Maquinas>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Maquina";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var maquinas = new Maquinas();
                    maquinas.Id = reader.GetInt32("id_maq");
                    maquinas.Nome = DAOHelper.GetString(reader, "nome_maq");
                    maquinas.Modelo = DAOHelper.GetString(reader, "modelo_maq");
                    maquinas.Marca = DAOHelper.GetString(reader, "marca_maq");
                    maquinas.Quantidade = reader.GetInt32("quantidade_maq");

                    lista.Add(maquinas);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Maquinas maquinas)
        {
            try
            {

                var comando = _conn.Query();

                comando.CommandText = "UPDATE Maquinas set nome_maq = @nome, descricao_maq = @descricao, modelo_maq = @modelo, marca_maq = @marca, quantidade_maq = @quantidade, valor_maq = @valor WHERE id_maq = @id";

                comando.Parameters.AddWithValue("@nome", maquinas.Nome);
                comando.Parameters.AddWithValue("@modelo", maquinas.Modelo);
                comando.Parameters.AddWithValue("@marca", maquinas.Marca);
                comando.Parameters.AddWithValue("@quantidade", maquinas.Quantidade);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Maquinas maquinas)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Maquinas where id_maq = @id";

                comando.Parameters.AddWithValue("@id", maquinas.Id);

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
