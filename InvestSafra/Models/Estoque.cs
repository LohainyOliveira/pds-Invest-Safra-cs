using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Estoque
	{
		public int Id { get; set; }
		public int Quantidade_Semente { get; set; }
		public int Quantidade_Insumos { get; set; }
		public string Tipo_Insumo { get; set; }
		public string Medida { get; set; }
		public string Descricao { get; set; }
	}
}
