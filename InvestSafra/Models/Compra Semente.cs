using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
    public class Compra_Semente
    {

        public int Id { get; set; }

        public int QuantidadeCompraSemente { get; set; }

        public double ValorCompraSemente { get; set; }

        public DateTime DataCompraSemente { get; set; }

        public string TipoCompraSemente { get; set; }
    }
}
