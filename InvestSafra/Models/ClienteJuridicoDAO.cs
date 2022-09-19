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
    internal class ClienteJuridicoDAO
    {

        private static Conexao _conn = new Conexao();
        public void Insert(ClienteJuridico clienteJ)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Cliente_Juridico value (null, @nome, @cpf, @rg, @sexo, @telefone, @cidade, @estado, @rua, @bairro, @cep, @Complemento, @email)");

                comando.Parameters.AddWithValue("@nome", clienteJ.Nome);
                comando.Parameters.AddWithValue("@cpf", clienteJ.CPF);
                comando.Parameters.AddWithValue("@rg", clienteJ.RG);
                comando.Parameters.AddWithValue("@sexo", clienteJ.Sexo);
                comando.Parameters.AddWithValue("@telefone", clienteJ.Telefone);
                comando.Parameters.AddWithValue("@cidade", clienteJ.Cidade);
                comando.Parameters.AddWithValue("@estado", clienteJ.Estado);
                comando.Parameters.AddWithValue("@rua", clienteJ.Rua);
                comando.Parameters.AddWithValue("@bairro", clienteJ.Bairro);
                comando.Parameters.AddWithValue("@cep", clienteJ.CEP);
                comando.Parameters.AddWithValue("@Complemento", clienteJ.Complemento);
                comando.Parameters.AddWithValue("@email", clienteJ.Email);


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


        public List<ClienteJuridico> List()
        {
            try
            {
                var lista = new List<ClienteJuridico>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Cliente_Juridico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    var clienteJ = new ClienteJuridico();
                    clienteJ.Id = reader.GetInt32("id_cliJ");
                    clienteJ.Nome = DAOHelper.GetString(reader, "nome_cliJ");
                    clienteJ.CPF = DAOHelper.GetString(reader, "cpf_cliJ");
                    clienteJ.RG = DAOHelper.GetString(reader, "rg_cliJ");
                    clienteJ.Sexo = DAOHelper.GetString(reader, "sexo_cliJ");
                    clienteJ.Telefone = DAOHelper.GetString(reader, "telefone_cliJ");
                    clienteJ.Cidade = DAOHelper.GetString(reader, "cidade_cliJ");
                    clienteJ.Estado = DAOHelper.GetString(reader, "estado_cliJ");
                    clienteJ.Rua = DAOHelper.GetString(reader, "rua_cliJ");
                    clienteJ.Bairro = DAOHelper.GetString(reader, "bairro_cliJ");
                    clienteJ.CEP = DAOHelper.GetString(reader, "cep_cliJ");
                    clienteJ.Complemento = DAOHelper.GetString(reader, "complemento_cliJ");
                    clienteJ.Email = DAOHelper.GetString(reader, "email_cliJ");

                    lista.Add(clienteJ);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ClienteJuridico clienteJ)
        {



            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Cliente_Juridico SET nome_cliJ = @nome, cpf_cliJ = @cpf, rg_cliJ = @rg, sexo_cliJ = @sexo, " +
                    "telefone_cliJ = @telefone, cidade_cliJ = @cidade, estado_cliJ = @estado, rua_cliJ = @rua, bairro_cliJ = @bairro, " +
                    "cep_cliJ = @cep, complemento_cliJ = @Complemento, email_cliJ = @email WHERE id_cliJ= @id";

                comando.Parameters.AddWithValue("@id", clienteJ.Id);
                comando.Parameters.AddWithValue("@nome", clienteJ.Nome);
                comando.Parameters.AddWithValue("@cpf", clienteJ.CPF);
                comando.Parameters.AddWithValue("@rg", clienteJ.RG);
                comando.Parameters.AddWithValue("@sexo", clienteJ.Sexo);
                comando.Parameters.AddWithValue("@telefone", clienteJ.Telefone);
                comando.Parameters.AddWithValue("@cidade", clienteJ.Cidade);
                comando.Parameters.AddWithValue("@estado", clienteJ.Estado);
                comando.Parameters.AddWithValue("@rua", clienteJ.Rua);
                comando.Parameters.AddWithValue("@bairro", clienteJ.Bairro);
                comando.Parameters.AddWithValue("@cep", clienteJ.CEP);
                comando.Parameters.AddWithValue("@Complemento", clienteJ.Complemento);
                comando.Parameters.AddWithValue("@email", clienteJ.Email);


                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(ClienteJuridico clienteJ)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Cliente_Juridico where id_cliJ = @id";

                comando.Parameters.AddWithValue("@id", clienteJ.Id);

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
