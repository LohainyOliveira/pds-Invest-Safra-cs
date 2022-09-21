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

                

                comando.Parameters.AddWithValue("@nome", recebimento.Valor_Venda_Safra);
                comando.Parameters.AddWithValue("@descricao", recebimento.Data);
                comando.Parameters.AddWithValue("@modelo", recebimento.Comprador);

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

                var lista = new List<Maquinas>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Recebimento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {


                    var recebimento = new Recebimentos();
                    recebimento.Id = reader.GetInt32("id_rec");
                    recebimento.Valor_Venda_Safra= reader.GetDouble("valor_venda_rec");
                    recebimento.Valor_Venda_Safra= reader.GetDateTime("valor_venda_rec");
                    maquinas.Marca = DAOHelper.GetString(reader, "marca_maq");
                    maquinas.Quantidade = reader.GetInt32("quantidade_maq");
                    maquinas.Valor = reader.GetDouble("valor_maq");

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

                comando.CommandText = "UPDATE Insumo set nome_maq = @nome, descricao_maq = @descricao, modelo_maq = @modelo, marca_maq = @marca, quantidade_maq = @quantidade, valor_maq = @valor WHERE id_maq = @id";

                comando.Parameters.AddWithValue("@nome", maquinas.Nome);
                comando.Parameters.AddWithValue("@descricao", maquinas.Descricao);
                comando.Parameters.AddWithValue("@modelo", maquinas.Modelo);
                comando.Parameters.AddWithValue("@marca", maquinas.Marca);
                comando.Parameters.AddWithValue("@quantidade", maquinas.Quantidade);
                comando.Parameters.AddWithValue("@valor", maquinas.Valor);

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

                comando.CommandText = "Delete from Maquina where id_maq = @id";

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
}
