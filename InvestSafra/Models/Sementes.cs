using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Sementes
	{
		public int Id { get; set; }
		public int Quantidade { get; set; }
		public string Marca { get; set; }
		public string Descricao { get; set; }
		public string Medida { get; set; }
		public double Valor { get; set; }
	}
}
