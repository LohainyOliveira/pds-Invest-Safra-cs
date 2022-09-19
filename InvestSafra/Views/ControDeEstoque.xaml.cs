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
    /// Lógica interna para ControDeEstoque.xaml
    /// </summary>
    public partial class ControDeEstoque : Window
    {
        public ControDeEstoque()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtDescricao.Clear();
            txtMedida.Clear();
            txtQuantInsumos.Clear();
            txtQuantSementes.Clear();
            txtTipoInsumo.Clear();

            ExibirMensagemLimpar();
         
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
