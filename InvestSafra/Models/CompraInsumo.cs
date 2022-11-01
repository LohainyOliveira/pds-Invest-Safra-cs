using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
    public class CompraInsumo
    {
        public int Id { get; set; }

        public int QuantidadeCompraInsumo { get; set; }

        public double ValorCompraInsumo { get; set; }

        public DateTime DataCompraInsumo { get; set; }

        public string TipoCompraInsumo { get; set; }
    }
}
