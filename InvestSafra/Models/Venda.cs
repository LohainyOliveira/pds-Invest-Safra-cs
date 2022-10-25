using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
	public class Venda
	{
		public int Id { get; set; }
		public double Valor { get; set; }
		public DateTime Data { get; set; }
		public string Safra { get; set; }
		public string Comprador { get; set; }


		//Terceiras tabelas de venda

		//Venda Produto 

		public int IdVendaProduto { get; set; }

		public int QuantidadeVendaProduto { get; set; }

		public double ValorVendaProduto { get; set; }

		public string TipoVendaProduto { get; set; }

		public DateTime  DataVendaProduto { get; set; }







	}







}
