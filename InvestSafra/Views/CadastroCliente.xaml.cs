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

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para Inscrever.xaml
	/// </summary>
	public partial class CadastroCliente : Window
	{
		DispatcherTimer timer;

		double PainelWidth;
		bool hidden;
		public CadastroCliente()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
			timer.Tick += Timer_Tick;

			PainelWidth = SidePainel.Width;
		}

		private void btCancelar_Click(object sender, RoutedEventArgs e)
		{
			TelaPrincipalWindow form = new TelaPrincipalWindow();
			form.ShowDialog();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (hidden)
			{
				SidePainel.Width += 1;
				if (SidePainel.Width >= PainelWidth)
				{
					timer.Stop();
					hidden = false;
				}


			}
			else
			{

				SidePainel.Width -= 1;
				if (SidePainel.Width <= 30)
				{
					timer.Stop();
					hidden = true;
				}
			}
		}

		private void ListViewItem_Selected(object sender, RoutedEventArgs e)
		{

		}

		private void btMenu_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();
		}


		private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
		{

		}

		private void painelHeader_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}

		}

		private void txtFuncao_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
