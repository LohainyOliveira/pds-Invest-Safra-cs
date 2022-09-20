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

namespace InvestSafra.Views
{
    /// <summary>
    /// Lógica interna para Insumos.xaml
    /// </summary>
    public partial class Insumos : Window
    {
        public Insumos()
        {
            InitializeComponent();
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
    }
}
