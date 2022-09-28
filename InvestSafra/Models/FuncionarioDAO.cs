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
	internal class FuncionarioDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Funcionario funcionario)
        {


            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Funcionario  value (null, @nome, @cpf, @rg, @sexo, @telefone. @cidade, @estado, @rua, @bairro, @cep, @complemento, @email, @funcao, @salario");


                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.CEP);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);

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


        public List<Funcionario> List()
        {
            try
            {

                var lista = new List<Funcionario>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    var funcionario = new Funcionario();
                    funcionario.Id = reader.GetInt32("id_fun");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_fun");
                    funcionario.CPF = DAOHelper.GetString(reader, "cpf_fun");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_fun");
                    funcionario.Sexo = DAOHelper.GetString(reader, "sexo_fun");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_fun");
                    funcionario.Cidade = DAOHelper.GetString(reader, "cidade_fun");
                    funcionario.Estado = DAOHelper.GetString(reader, "estado_fun");
                    funcionario.Rua = DAOHelper.GetString(reader, "rua_fun");
                    funcionario.Bairro = DAOHelper.GetString(reader, "bairro_fun");
                    funcionario.CEP = DAOHelper.GetString(reader, "cep_fun");
                    funcionario.Complemento = DAOHelper.GetString(reader, "complemento_fun");
                    funcionario.Email = DAOHelper.GetString(reader, "email_fun");
                    funcionario.Funcao = DAOHelper.GetString(reader, "funcao_fun");
                    funcionario.Salario = reader.GetDouble ("salario_fun");


                    lista.Add(funcionario);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Funcionario set nome_fun = @nome, cpf_fun = @cpf, rg_fun = @rg, sexo_fun = @sexo, telefone_fun = @telefone, " +
                    "cidade_fun = @cidade, estado_fun = @estado, rua_fun = @rua, bairro_fun = @bairo, cep_fun = @cep, complemento_fun = @complemento," +
                    "email_fun = @email, funcao_fun = @funcao, salario_fun = @salario WHERE id_fun = @id";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.CEP);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Funcionario where id_fun = @id";

                comando.Parameters.AddWithValue("@id", funcionario.Id);

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
