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
	internal class FornecedorDAO
	{
        private static Conexao _conn = new Conexao();
        public void Insert(Fornecedor fornecedor)
        {

            try
            {

                var comando = _conn.Query();

                comando.CommandText = ("insert into Fornecedor value (null, @nomeFantasia, @cnpj, @razao_social, @bairro, @rua, @cidade," +
                    "@estado, @cep, @complemento, @telefone_pessoal, @telefone_firma, @email");



                comando.Parameters.AddWithValue("@nomeFantasia", fornecedor.Nome_Fantasia);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao_Social);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);
                comando.Parameters.AddWithValue("@cep", fornecedor.CEP);
                comando.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                comando.Parameters.AddWithValue("@telefone_pessoal", fornecedor.Telefone_Pessoal);
                comando.Parameters.AddWithValue("@telefone_firma", fornecedor.Telefone_Empresa);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
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


        public List<Fornecedor> List()
        {
            try
            {

                var lista = new List<Fornecedor>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    /*
        create table Fornecedor (
        id_for int primary key auto_increment not null,
        nome_for varchar (100) not null,
        cnpj_for varchar (100) not null,
        razao_social_for varchar (100) not null,
        bairro_for varchar (100) not null,
        rua_for varchar (100) not null,
        cidade_for varchar (100) not null,
        estado_for varchar (100) not null,
        cep_for varchar (100) not null,
        complemento_for varchar (100) not null,
        telefone_pessoal_for varchar (100) not null,
        telefone_firma_for varchar (100) not null,
        email_for varchar (100) not null
        );*/


                    var fornecedor = new Fornecedor();
                    fornecedor.Id = reader.GetInt32("id_for");
                    fornecedor.Nome_Fantasia = DAOHelper.GetString(reader, "nome_for");
                    fornecedor.CNPJ = DAOHelper.GetString(reader, "cnpj_for");
                    fornecedor.Razao_Social = DAOHelper.GetString(reader, "razao_social_for");
                    fornecedor.Bairro = DAOHelper.GetString(reader, "bairro_for");
                    fornecedor.Rua = DAOHelper.GetString(reader, "rua_for");
                    fornecedor.Cidade = DAOHelper.GetString(reader, "cidade_for");
                    fornecedor.Estado = DAOHelper.GetString(reader, "estado_for");
                    fornecedor.CEP = DAOHelper.GetString(reader, "cep_for");
                    fornecedor.Complemento = DAOHelper.GetString(reader, "complemento_for");
                    fornecedor.Telefone_Pessoal = DAOHelper.GetString(reader, "telefone_pessoal_for");
                    fornecedor.Telefone_Empresa = DAOHelper.GetString(reader, "telefone_firma_for");
                    fornecedor.Email = DAOHelper.GetString(reader, "email_for");

                    lista.Add(fornecedor);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Fazenda fazenda)
        {
            try
            {
                var comando = _conn.Query();


                comando.CommandText = "UPDATE Fazenda set nome_faze = @nome, nome_faze = @nomeFantasia, proprietario_faze = @proprietario, cnpj_faze = @cnpj, localizacao_faze = @localizacao, complemento_faze = @complemento  WHERE id_faze = @id";

                comando.Parameters.AddWithValue("@nome", fazenda.Nome);
                comando.Parameters.AddWithValue("@nomeFantasia", fazenda.NomeFantasia);
                comando.Parameters.AddWithValue("@proprietario", fazenda.Proprietario);
                comando.Parameters.AddWithValue("@cnpj", fazenda.CNPJ);
                comando.Parameters.AddWithValue("@localizacao", fazenda.Localizacao);
                comando.Parameters.AddWithValue("@complemento", fazenda.Complemento);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Fazenda fazenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Delete from Fazenda where id_faze = @id";

                comando.Parameters.AddWithValue("@id", fazenda.Id);

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
