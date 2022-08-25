using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Fazenda
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string NomeFantasia { get; set; }
		public string CNPJ { get; set; }
		public string Localizacao { get; set; }
		public string Complemento { get; set; }
	}
}
