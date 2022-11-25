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
using InvestSafra.Models;

namespace InvestSafra.Views
{
    /// <summary>
    /// Lógica interna para Venda.xaml
    /// </summary>
    public partial class CadastrarVenda : Window
    {
        private Venda _venda = new Venda();
        public CadastrarVenda()
        {
            InitializeComponent();
            Loaded += VendaFormWindow_Loaded;
        }
        public CadastrarVenda(Venda venda)
        {
            InitializeComponent();

            _venda = venda;
            Loaded += VendaFormWindow_Loaded;

        }


        private void VendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
          

        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private bool IsMaxinized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaxinized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaxinized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaxinized = true;

                }
            }
        }

		private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void BtnSearch_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btSalvar_Click(object sender, RoutedEventArgs e)
		{

		}

		private void txtDescricao_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
