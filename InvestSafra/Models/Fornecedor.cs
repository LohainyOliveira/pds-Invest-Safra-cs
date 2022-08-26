using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Fornecedor
	{
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
