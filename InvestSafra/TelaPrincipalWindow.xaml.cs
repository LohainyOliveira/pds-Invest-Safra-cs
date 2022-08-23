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
using InvestSafra.Views;


namespace InvestSafra
{
	/// <summary>
	/// Lógica interna para TelaPrincipalWindow.xaml
	/// </summary>
	public partial class TelaPrincipalWindow : Window
	{
		public TelaPrincipalWindow()
		{
			InitializeComponent();
		}



		private void btCadastra_Click(object sender, RoutedEventArgs e)
		{
			CadastroCliente form = new CadastroCliente();
			form.ShowDialog();
		}

		private void btEntrar_Click(object sender, RoutedEventArgs e)
		{

			Entrar form = new Entrar();
			form.ShowDialog();
		}
	}
}
