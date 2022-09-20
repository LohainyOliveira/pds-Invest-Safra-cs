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
using InvestSafra;

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para Inscrever.xaml
	/// </summary>
	public partial class CadastroCliente : Window
	{
		public CadastroCliente()
		{
			InitializeComponent();
		}

		private void btCancelar_Click(object sender, RoutedEventArgs e)
		{
			TelaPrincipalWindow form = new TelaPrincipalWindow();
			form.ShowDialog();
		}
	}
}
