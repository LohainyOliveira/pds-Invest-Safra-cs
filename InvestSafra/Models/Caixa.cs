using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
    internal class Caixa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Descricao { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoFinal { get; set; }
        public DateTime Data_Hora { get; set; }
    }
}
