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

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para MenuWindow.xaml
	/// </summary>
	public partial class MenuWindow : Window
	{
		DispatcherTimer timer;

		double PainelWidth;
		bool hidden;
		public MenuWindow()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
			timer.Tick += Timer_Tick;

			PainelWidth = SidePainel.Width;

			Loaded += MenuWindow_Loaded;
			InitializeComponent();
		}



		private void MenuWindow_Loaded(object sender, RoutedEventArgs e)
		{

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
				if (SidePainel.Width <= 40)
				{
					timer.Stop();
					hidden = true;
				}
			}

		}

		private void btCadastra_Click(object sender, RoutedEventArgs e)
		{
			CadastrarMaquinas form = new CadastrarMaquinas();
			form.ShowDialog();
		}

		private void btEntrar_Click(object sender, RoutedEventArgs e)
		{


		}

		private void ListViewItem_Selected(object sender, RoutedEventArgs e)
		{


			Entrar form = new Entrar();
			form.ShowDialog();
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

		private void btCadastrar_Click(object sender, RoutedEventArgs e)
		{
			Insumos form = new Insumos();
			form.ShowDialog();
		}

		

		private void slhome_Selected(object sender, RoutedEventArgs e)
		{
			
			TelaPrincipalWindow form = new TelaPrincipalWindow();
			form.ShowDialog();
			
		}

		private void slArea_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarArea form = new CadastrarArea();
			form.ShowDialog();
		}

		private void slCaixa_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarCaixa form = new CadastrarCaixa();
			form.ShowDialog();
		}

		private void slCompra_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarCompra form = new CadastrarCompra();
			form.ShowDialog();

		}

		private void slFornecedor_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarFornecedor form = new CadastrarFornecedor();
			form.ShowDialog();
		}

		private void slFazenda_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarFazenda form = new CadastrarFazenda();
			form.ShowDialog();
		}

		private void slEmpresa_Selected(object sender, RoutedEventArgs e)
		{
			ClienteJuridico form = new ClienteJuridico();
			form.ShowDialog();
		}

		private void slMaquinas_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarMaquinas form = new CadastrarMaquinas();
			form.ShowDialog();
		}

		private void slEstoque_Selected(object sender, RoutedEventArgs e)
		{
			ControDeEstoque form = new ControDeEstoque();
			form.ShowDialog();
		}

		private void slSafras_Selected(object sender, RoutedEventArgs e)
		{
			LevantamentoDeSafra form = new LevantamentoDeSafra();
			form.ShowDialog();
		}

		private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
		{

		}
	}
}
