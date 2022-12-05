using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Funcionario
	{


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

		public double Salario { get; set; }
	}
}
