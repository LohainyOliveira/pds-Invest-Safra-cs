using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Clima
	{
		public int Id { get; set; }
		public double Temperatura { get; set; }
		public string Climatizacao { get; set; }
		public string Local { get; set; }
		public DateTime? Data { get; set; }
	}
}
