using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InvestSafra.Views;
using InvestSafra.Database;
using InvestSafra.Helpers;


namespace InvestSafra.Models
{
    internal class CaixaDAO
    { 

        private static Conexao _conn = new Conexao();
        public void Insert(Caixa caixa)
        {
           
            try
            {
                var comando = _conn.Query();

                comando.CommandText = ("insert into Caixa value (null, @numero, @saldo_inicial, @troco, @valor_creditos, @valor_debitos, @saldo_finial, @descricao, @data_hora)");



                comando.Parameters.AddWithValue("@numero", caixa.Numero);
                comando.Parameters.AddWithValue("@saldo_inicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@troco", caixa.Troco);
                comando.Parameters.AddWithValue("@valor_creditos", caixa.ValorCredito);
                comando.Parameters.AddWithValue("@valor_debitos", caixa.ValorDebito);
                comando.Parameters.AddWithValue("@saldo_finial", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@descricao", caixa.Descricao);
                comando.Parameters.AddWithValue("@data_hora", caixa.Data_Hora);

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


        public List<Caixa> List()
        {
            try
            {
                var lista = new List<Caixa>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    /*create table Caixa(
                    id_cai int primary key auto_increment not null,
                    numero_cai int not null,
                    saldoinicial_cai double not null,
                    troco_cai double not null,
                    valorcréditos_cai double not null,
                    valordébitos_cai double not null,
                    saldofinal_cai double not null,
                    descricao_cai varchar(300),
                    data_hora_cai DateTime
                    );
                    */

                    var caixa = new Caixa();
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.Numero = reader.GetInt32("numero_cai");
                    caixa.SaldoInicial = reader.GetDouble("saldoinicial_cai");
                    caixa.Troco = reader.GetDouble("troco_cai");
                    caixa.ValorCredito = reader.GetDouble("valorcreditos_cai");
                    caixa.ValorDebito = reader.GetDouble("valordebitos_cai");
                    caixa.SaldoFinal = reader.GetDouble("saldofinal_cai");
                    caixa.Descricao = DAOHelper.GetString(reader, "descricao_cai");
                    caixa.Data_Hora = DAOHelper.GetDateTime(reader, "data_hora_cai");

                    lista.Add(caixa);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Caixa caixa)
        {



            try
            {
                var comando = _conn.Query();

                /*create table Caixa(
                    id_cai int primary key auto_increment not null,
                    numero_cai int not null,
                    saldoinicial_cai double not null,
                    troco_cai double not null,
                    valorcreditos_cai double not null,
                    valordebitos_cai double not null,
                    saldofinal_cai double not null,
                    descricao_cai varchar(300),
                    data_hora_cai DateTime
                    );
                    */

                comando.CommandText = "UPDATE Caixa set  numero_cai = @numero, saldoinicial_cai = @saldo_inicial, troco_cai =  @troco," +
                    " valorcreditos_cai = @valor_creditos, valordebitos_cai = @valor_debitos,  WHERE id_are = @id";


                comando.CommandText = ("insert into Caixa value (null, @numero, @saldo_inicial, @troco, @valor_creditos, @valor_debitos, @saldo_finial, @descricao, @data_hora)");



                comando.Parameters.AddWithValue("@numero", caixa.Numero);
                comando.Parameters.AddWithValue("@saldo_inicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@troco", caixa.Troco);
                comando.Parameters.AddWithValue("@valor_creditos", caixa.ValorCredito);
                comando.Parameters.AddWithValue("@valor_debitos", caixa.ValorDebito);
                comando.Parameters.AddWithValue("@saldo_finial", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@descricao", caixa.Descricao);
                comando.Parameters.AddWithValue("@data_hora", caixa.Data_Hora);

               

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
