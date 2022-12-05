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
    /// Lógica interna para CadastrarMaquinas.xaml
    /// </summary>
    public partial class CadastrarMaquinas : Window
    {


        private Maquinas _maquinas = new Maquinas();


        public CadastrarMaquinas()
        {
            InitializeComponent();
            Loaded += MaquinasFormWindow_Loaded;
        }

        public CadastrarMaquinas(Maquinas maquinas)
		{
            InitializeComponent();

            _maquinas = maquinas;
            Loaded += MaquinasFormWindow_Loaded;
        }


        private void MaquinasFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _maquinas.Nome;
            txtMarca.Text = _maquinas.Marca;
            



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
                    this.Width = 600;
                    this.Height = 520;

                    IsMaxinized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaxinized = true;

                }
            }
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

		private void btSalvar_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
