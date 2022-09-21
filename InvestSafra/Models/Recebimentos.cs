using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
    internal class Recebimentos
    {
        public int Id { get; set; }
        public double Valor_Venda_Safra { get; set; }
        public DateTime? Data { get; set; }
        public string Comprador { get; set; }
    }
}
