using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestSafra.Database;
using MySql.Data.MySqlClient;
using InvestSafra.Helpers;

namespace InvestSafra.Models
{
	internal class ClienteFisicoDAO
	{

        private static Conexao _conn = new Conexao();
        public void Insert(ClienteFisico clienteF)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Cliente_Fisico value (null, @nome, @cpf, @rg, @sexo, @telefone, @cidade, @estado, @rua, @bairro, @cep, @Complemento, @email)");
 



                comando.Parameters.AddWithValue("@nome", clienteF.Nome);
                comando.Parameters.AddWithValue("@cpf", clienteF.CPF);
                comando.Parameters.AddWithValue("@rg", clienteF.RG);
                comando.Parameters.AddWithValue("@sexo", clienteF.Sexo);
                comando.Parameters.AddWithValue("@telefone", clienteF.Telefone);
                comando.Parameters.AddWithValue("@cidade", clienteF.Cidade);
                comando.Parameters.AddWithValue("@estado", clienteF.Estado);
                comando.Parameters.AddWithValue("@rua", clienteF.Rua);
                comando.Parameters.AddWithValue("@bairro", clienteF.Bairro);
                comando.Parameters.AddWithValue("@cep", clienteF.CEP);
                comando.Parameters.AddWithValue("@Complemento", clienteF.Complemento);
                comando.Parameters.AddWithValue("@email", clienteF.Email);

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


        public List<ClienteFisico> List()
        {
            try
            {
                var lista = new List<ClienteFisico>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Cliente_Fisico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    var clienteF = new ClienteFisico();
                    clienteF.Id = reader.GetInt32("id_cliF");
                    clienteF.Nome = DAOHelper.GetString(reader, "nome_cliF");
                    clienteF.CPF = DAOHelper.GetString(reader, "cpf_cliF");
                    clienteF.RG = DAOHelper.GetString(reader, "rg_cliF");
                    clienteF.Sexo = DAOHelper.GetString(reader, "sexo_cliF");
                    clienteF.Telefone = DAOHelper.GetString(reader, "telefone_cliF");
                    clienteF.Cidade= DAOHelper.GetString(reader, "cidade_cliF");
                    clienteF.Estado = DAOHelper.GetString(reader, "estado_cliF");
                    clienteF.Rua = DAOHelper.GetString(reader, "rua_cliF");
                    clienteF.Bairro = DAOHelper.GetString(reader, "bairro_cliF");
                    clienteF.CEP = DAOHelper.GetString(reader, "cep_cliF");
                    clienteF.Complemento = DAOHelper.GetString(reader, "complemento_cliF");
                    clienteF.Email = DAOHelper.GetString(reader, "email_cliF");

                    lista.Add(clienteF);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ClienteFisico clienteF)
        {

            

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Cliente_Fisico SET nome_cliF = @nome, cpf_cliF = @cpf, rg_cliF = @rg, sexo_cliF = @sexo, " +
                    "telefone_cliF = @telefone, cidade_cliF = @cidade, estado_cliF = @estado, rua_cliF = @rua, bairro_cliF = @bairro, " +
                    "cep_cliF = @cep, complemento_cliF = @Complemento, email_cliF = @email WHERE id_cliF= @id";

                comando.Parameters.AddWithValue("@id", clienteF.Id);
                comando.Parameters.AddWithValue("@nome", clienteF.Nome);
                comando.Parameters.AddWithValue("@cpf", clienteF.CPF);
                comando.Parameters.AddWithValue("@rg", clienteF.RG);
                comando.Parameters.AddWithValue("@sexo", clienteF.Sexo);
                comando.Parameters.AddWithValue("@telefone", clienteF.Telefone);
                comando.Parameters.AddWithValue("@cidade", clienteF.Cidade);
                comando.Parameters.AddWithValue("@estado", clienteF.Estado);
                comando.Parameters.AddWithValue("@rua", clienteF.Rua);
                comando.Parameters.AddWithValue("@bairro", clienteF.Bairro);
                comando.Parameters.AddWithValue("@cep", clienteF.CEP);
                comando.Parameters.AddWithValue("@Complemento", clienteF.Complemento);
                comando.Parameters.AddWithValue("@email", clienteF.Email);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(ClienteFisico clienteF)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Cliente_Fisico where id_cliF = @id";

                comando.Parameters.AddWithValue("@id", clienteF.Id);

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
