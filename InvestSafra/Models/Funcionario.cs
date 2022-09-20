using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Funcionario
	{
		/*
create table Funcionário (
id_fun int primary key auto_increment not null,
nome_fun varchar (100) not null,
cpf_fun varchar (100) not null,
rg_fun varchar (100) not null,
sexo_fun varchar (100) not null,
telefone_fun varchar (100) not null,
cidade_fun varchar (100) not null,
estado_fun varchar (100) not null,
rua_fun varchar (100) not null,
bairro_fun varchar (100) not null,
cep_fun varchar (100) not null,
complemento_fun varchar (100) not null,
email_fun varchar (100) not null,
funcao_fun varchar (100) not null,
salario_fun double not null
); 
*/

		public int Id { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string RG { get; set; }
		public string Sexo { get; set; }
		public string Telefone { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Rua { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Complemento { get; set; }
		public string Email { get; set; }
		public string Funcao { get; set; }
		public string Tipo { get; set; }
		public double Salario { get; set; }
	}
}
