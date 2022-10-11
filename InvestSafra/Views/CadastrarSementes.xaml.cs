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

            _sementes = semente;
            Loaded += SementesFormWindow_Loaded;
        }

        private void SementesFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtdescricao.Text = _sementes.Descricao;
            txtMarca1.Text = _sementes.Marca;
            txtMedida.Text = _sementes.Medida;
        }

        private void sementeFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtdescricao.Text = _semente.Descricao;
            txtMarca1.Text = _semente.Marca;
            txtMedida.Text = _semente.Medida;
            txtQuantidade1 = _semente.Quantidade;
            txtValor.Text = _semente.Valor;
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
    }
}
