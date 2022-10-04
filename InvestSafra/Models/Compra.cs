using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Compra
	{

		public int Id { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public string Descricao { get; set; }
		public DateTime? Data { get; set; }
	}
}
