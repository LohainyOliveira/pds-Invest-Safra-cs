using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Estoque
	{
		public int Id { get; set; }
		public int Qtd_Sementes { get; set; }
		public int Qtd_Insumos { get; set; }
		public string Tipo_Insumos { get; set; }
		public string Descricao { get; set; }
		public string Medidas { get; set; }
	}
}
