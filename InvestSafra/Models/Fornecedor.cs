using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Fornecedor
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
		public int Id { get; set; }
		public string CNPJ { get; set; }
		public string Razao_Social { get; set; }
		public string Nome_Fantasia { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string CEP { get; set; }
		public string Complemento { get; set; }
		public string Telefone_Pessoal { get; set; }
		public string Telefone_Empresa { get; set; }
		public string Email { get; set; }
	}
}
