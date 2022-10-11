using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestSafra.Models
{
    public class Caixa
    {

        public int Id { get; set; }
        public int Numero { get; set; }
        public double SaldoInicial { get; set; }
        public double Troco { get; set; }
        public double ValorCredito { get; set; }    
        public double ValorDebito { get; set; }
        public string Descricao { get; set; }
        public double SaldoFinal { get; set; }
        public DateTime? Data_Hora { get; set; }
    }
}
