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
    /// Lógica interna para Sementes.xaml
    /// </summary>
    public partial class CadastrarSementes : Window
    {

        private Sementes _semente = new Sementes();

        public CadastrarSementes()
        {
            InitializeComponent();
            Loaded += SementesFormWindow_Loaded;
        }

        public CadastrarSementes(Sementes semente)
        {
            InitializeComponent();

            _semente = semente;
            Loaded += SementesFormWindow_Loaded;
        }

        private void SementesFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtdescricao.Text = _semente.Descricao;
            txtMarca1.Text = _semente.Marca;
            txtMedida.Text = _semente.Medida;
            //txtQuantidade1 = _semente.Quantidade;
            //txtValor.Text = _semente.Valor;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtdescricao.Clear();
            txtMarca1.Clear();
            txtMedida.Clear();  
            txtQuantidade1.Clear();
            txtValor.Clear();

            ExibirMensagemLimpar();
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
