using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using InvestSafra;
using InvestSafra.Models;

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para Inscrever.xaml
	/// </summary>
	public partial class CadastroCliente : Window
	{
        private Cliente _cliente = new Cliente();

        public CadastroCliente()
		{
			InitializeComponent();
		}

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
