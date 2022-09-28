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
        public void Insert(Insumos insumo)
        {


            try
            {
                
                var comando = _conn.Query();

                comando.CommandText = ("insert into Insumo  value (null, @nome,  @tipo, @marca, @descricao ");


                comando.Parameters.AddWithValue("@nome", insumo.Nome);
                comando.Parameters.AddWithValue("@tipo", insumo.Tipo);
                comando.Parameters.AddWithValue("@marca", insumo.Marca);
                comando.Parameters.AddWithValue("@descricao", insumo.Descricao);

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
                    

                    var insumo = new Insumos();
                    insumo.Id = reader.GetInt32("id_ins");
                    insumo.Nome = DAOHelper.GetString(reader, "nome_ins");
                    insumo.Tipo = DAOHelper.GetString(reader, "tipo_ins");
                    insumo.Marca = DAOHelper.GetString(reader, "marca_ins");
                    insumo.Descricao= DAOHelper.GetString(reader, "descricao_ins");


                    lista.Add(insumo);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Insumos insumo)
        {
            try
            {
               
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Insumo set nome_ins = @nome, tipo_ins = @tipo, marca_ins = @marca, descricao_ins = @descricao  WHERE id_ins = @id";

                comando.Parameters.AddWithValue("@nome", insumo.Nome);
                comando.Parameters.AddWithValue("@tipo", insumo.Tipo);
                comando.Parameters.AddWithValue("@marca", insumo.Marca);
                comando.Parameters.AddWithValue("@descricao", insumo.Descricao);   

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
