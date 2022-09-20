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
	internal class InsumosDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Insumos insumos)
        {


            try
            {
                
                var comando = _conn.Query();

                comando.CommandText = ("insert into Insumo  value (null, @nome,  @tipo, @marca, @descricao ");


                comando.Parameters.AddWithValue("@nome", insumos.Nome);
                comando.Parameters.AddWithValue("@tipo", insumos.Tipo);
                comando.Parameters.AddWithValue("@marca", insumos.Marca);
                comando.Parameters.AddWithValue("@descricao", insumos.Descricao);

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


        public List<Insumos> List()
        {
            try
            {

                var lista = new List<Insumos>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Insumo";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    

                    var insumos = new Insumos();
                    insumos.Id = reader.GetInt32("id_ins");
                    insumos.Nome = DAOHelper.GetString(reader, "nome_ins");
                    insumos.Tipo = DAOHelper.GetString(reader, "tipo_ins");
                    insumos.Marca = DAOHelper.GetString(reader, "marca_ins");
                    insumos.Descricao= DAOHelper.GetString(reader, "descricao_ins");


                    lista.Add(insumos);
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
