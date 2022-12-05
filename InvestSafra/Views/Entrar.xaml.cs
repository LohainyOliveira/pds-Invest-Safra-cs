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
using System.Windows.Threading;
using MS.Internal.WindowsBase;
using InvestSafra.Helpers;
using InvestSafra.Database;
using InvestSafra.Models;

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para Entrar.xaml
	/// </summary>
	public partial class Entrar : Window
	{


		public Entrar()
		{

			InitializeComponent();
            
        }




        private void btVoltar_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

		private void btLogar_Click(object sender, RoutedEventArgs e)
		{
			string usuario = txtUsuario.Text;
			string senha = psSenha.Password.ToString();

			if (Usuario.Login(usuario, senha))
			{
				MenuWindow form = new MenuWindow();

				this.Close();
				form.ShowDialog();
			}
			else
			{
				MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
				_ = txtUsuario.Focus();
			}
			

		}

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
			CadastrarClienteJuridico form = new CadastrarClienteJuridico();
			this.Close();
			form.ShowDialog();
        }
    }
}
