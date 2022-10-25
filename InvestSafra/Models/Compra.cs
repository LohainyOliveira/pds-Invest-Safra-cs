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
		public string Fornecedor { get; set; }

		//Terceiras tabelas de compra

		//Compra Insumo

		public int IdCompraInsumo { get; set; }

		public int QuantidadeCompraInsumo { get; set; }

		public double ValorCompraInsumo { get; set; }

		public DateTime DataCompraInsumo { get; set; }

		public string TipoCompraInsumo { get; set; }


		//Compra Semente

		public int IdCompraSemente { get; set; }

		public int QuantidadeCompraSemente { get; set; }

		public double ValorCompraSemente { get; set; }

		public DateTime DataCompraSemente { get; set; }

		public string TipoCompraSemente { get; set; }
	}
}
