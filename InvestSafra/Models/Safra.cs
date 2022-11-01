using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Safra
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Tipo { get; set; }
		public string NomeTerreno { get; set; }
		public string Hectares { get; set; }
		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }


	}

}
