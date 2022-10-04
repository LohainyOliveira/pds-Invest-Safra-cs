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
    /// Lógica interna para ClimaFazenda.xaml
    /// </summary>
    public partial class ClimaFazenda : Window
    {


        private Clima _climaFazenda= new Clima();

        public ClimaFazenda()
        {
            InitializeComponent();
            Loaded += ClimaFazendaFormWindow_Loaded;
        }
        public ClimaFazenda(Clima climaFazenda)
        {
            InitializeComponent();

            _climaFazenda = climaFazenda;
            Loaded += ClimaFazendaFormWindow_Loaded;

        }

		public ClimaFazenda(Area climaSelecionado)
		{
			this.climaSelecionado = climaSelecionado;
		}

		private void ClimaFazendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
         
            txtClima.Text = _climaFazenda.Climatizacao;
            txtTemperatura.Text = _climaFazenda.Temperatura;
            txtLocal.Text = _climaFazenda.Local;
            


        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtClima.Clear();
            txtLocal.Clear();
            txtTemperatura.Clear();

            ExibirMensagemLimpar();
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private bool IsMaxinized = false;
		private Area climaSelecionado;

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
    }

    
}
