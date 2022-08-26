using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Compra
	{
		public int Id { get; set; }
		public int Quantidade { get; set; }
		public int Nome { get; set; }
		public int Descricao { get; set; }
		public DateTime Data { get; set; }
	}
}
