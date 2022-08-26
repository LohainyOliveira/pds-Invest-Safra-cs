using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	internal class Area
	{
		public int Id { get; set; }
		public string Nome_Responsavel { get; set; }
		public string Nome_Terreno { get; set; }
		public string Metros { get; set; }
		public string CNPJ { get; set; }
		public string Localizacao { get; set; }
		public string Descricao { get; set; }
	}
}
