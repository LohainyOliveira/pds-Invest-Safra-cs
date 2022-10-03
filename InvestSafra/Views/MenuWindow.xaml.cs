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
				if (SidePainel.Width <= 45)
				{
					timer.Stop();
					hidden = true;
				}
			}

		}

		private void MaxBtn_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Normal)
			{
				WindowState = WindowState.Maximized;
			}
			else
			{
				if (WindowState == WindowState.Maximized)
				{
					WindowState = WindowState.Normal;
				}
			}
		}

		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void btMenu_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();
		}



		private void painelHeader_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}

		}

		private void SideMenuItemHome_Selected(object sender, RoutedEventArgs e)
		{

		}

		private void SideMenuItemListaArea_Selected(object sender, RoutedEventArgs e)
		{
			ListaArea form = new ListaArea();
			form.ShowDialog();
		}
		private void SideMenuItemListaCaixa_Selected(object sender, RoutedEventArgs e)
		{
			ListaCaixa form = new ListaCaixa();
			form.ShowDialog();
		}
		private void SideMenuItemListaEmpresa_Selected(object sender, RoutedEventArgs e)
		{
			ListaClienteJuridico form = new ListaClienteJuridico();
			form.ShowDialog();
		}

		private void SideMenuItemListaClima_Selected(object sender, RoutedEventArgs e)
		{
			ListaClima form = new ListaClima();
			form.ShowDialog();
		}
		private void SideMenuItemListaCompra_Selected(object sender, RoutedEventArgs e)
		{
			ListaCompra form = new ListaCompra();
			form.ShowDialog();
		}
		private void SideMenuItemListaEstoque_Selected(object sender, RoutedEventArgs e)
		{
			ListaEstoque form = new ListaEstoque();
			form.ShowDialog();
		}
		private void SideMenuItemListaFazenda_Selected(object sender, RoutedEventArgs e)
		{
			ListaFazenda form = new ListaFazenda();
			form.ShowDialog();
		}
		private void SideMenuItemListaFornecedor_Selected(object sender, RoutedEventArgs e)
		{
			ListaFornecedor form = new ListaFornecedor();
			form.ShowDialog();
		}
		private void SideMenuItemListaFuncionario_Selected(object sender, RoutedEventArgs e)
		{
			ListaFuncionario form = new ListaFuncionario();
			form.ShowDialog();
		}
		private void SideMenuItemListaInsumo_Selected(object sender, RoutedEventArgs e)
		{
			ListaInsumos form = new ListaInsumos();
			form.ShowDialog();
		}
		private void SideMenuItemListaSafra_Selected(object sender, RoutedEventArgs e)
		{
			ListaLevantamentoSafra form = new ListaLevantamentoSafra();
			form.ShowDialog();
		}
		private void SideMenuItemListaMaquinas_Selected(object sender, RoutedEventArgs e)
		{
			ListaMaquinas form = new ListaMaquinas();
			form.ShowDialog();
		}
		private void SideMenuItemListaProduto_Selected(object sender, RoutedEventArgs e)
		{
			ListaProduto form = new ListaProduto();
			form.ShowDialog();
		}
		private void SideMenuItemListaSementes_Selected(object sender, RoutedEventArgs e)
		{
			ListaSemente form = new ListaSemente();
			form.ShowDialog();
		}
		private void SideMenuItemListaVenda_Selected(object sender, RoutedEventArgs e)
		{
			ListaVenda form = new ListaVenda();
			form.ShowDialog();
		}



		//Telas Principais


		private void SideMenuItemArea_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarArea form = new CadastrarArea();
			form.ShowDialog();
		}
		private void SideMenuItemCaixa_Selected(object sender, RoutedEventArgs e)
		{
			
		}
		private void SideMenuItemEmpresas_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarClienteJuridico form = new CadastrarClienteJuridico();
			form.ShowDialog();
		}

		private void SideMenuItemClima_Selected(object sender, RoutedEventArgs e)
		{
			ClimaFazenda form = new ClimaFazenda();
			form.ShowDialog();
		}
		private void SideMenuItemCompra_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarCompra form = new CadastrarCompra();
			form.ShowDialog();
		}
		private void SideMenuItemEstoque_Selected(object sender, RoutedEventArgs e)
		{
			ControDeEstoque form = new ControDeEstoque();
			form.ShowDialog();
		}
		private void SideMenuItemFazenda_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarFazenda form = new CadastrarFazenda();
			form.ShowDialog();
		}
		private void SideMenuItemFornecedores_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarFornecedor form = new CadastrarFornecedor();
			form.ShowDialog();
		}
		private void SideMenuItemFuncionarios_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarFuncionario form = new CadastrarFuncionario();
			form.ShowDialog();
		}
		private void SideMenuItemInsumo_Selected(object sender, RoutedEventArgs e)
		{
			Insumos form = new Insumos();
			form.ShowDialog();
		}
		private void SideMenuItemSafra_Selected(object sender, RoutedEventArgs e)
		{
			LevantamentoDeDadosDaSafra form = new LevantamentoDeDadosDaSafra();
			form.ShowDialog();
		}
		private void SideMenuItemMaquinas_Selected(object sender, RoutedEventArgs e)
		{
			CadastrarMaquinas form = new CadastrarMaquinas();
			form.ShowDialog();
		}
		private void SideMenuItemProdutos_Selected(object sender, RoutedEventArgs e)
		{
			Produto form = new Produto();
			form.ShowDialog();
		}
		private void SideMenuItemSementes_Selected(object sender, RoutedEventArgs e)
		{
			Sementes form = new Sementes();
			form.ShowDialog();
		}
		private void SideMenuItemVenda_Selected(object sender, RoutedEventArgs e)
		{
			Venda form = new Venda();
			form.ShowDialog();
		}
	}
}
