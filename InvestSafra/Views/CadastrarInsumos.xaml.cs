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
    /// Lógica interna para Insumos.xaml
    /// </summary>
    public partial class CadastrarInsumos : Window
    {
        private Insumos _insumos = new Insumos();
        public CadastrarInsumos()
        {
            InitializeComponent();
            Loaded += InsumosFormWindow_Loaded;
        }

        public CadastrarInsumos(Insumos insumos)
        {
            InitializeComponent();

            _insumos = insumos;
            Loaded += InsumosFormWindow_Loaded;

        }

        private void InsumosFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //txtDescricao1.Text = _insumos.Descricao;
            //txtMarca1.Text = _insumos.Marca;
            //txtQuantidade.Text = _insumos.Quantidade;
            //txtTipoInsumo.Text = _insumos.Tipo;
            //txtValor.Text = _insumos.Valor;

        }

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

       

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtDescricao1.Clear();
            txtMarca1.Clear();
            cbMedida.SelectedItem = null;
            txtQuantidade.Clear();
            txtTipoInsumo.Clear();
            txtValor.Clear();

            ExibirMensagemLimpar();
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
