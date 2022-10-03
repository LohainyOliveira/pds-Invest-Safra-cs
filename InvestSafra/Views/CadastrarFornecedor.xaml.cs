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
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        private CadastrarFornecedor _fornecedor = new CadastrarFornecedor();
        public CadastrarFornecedor()
        {
            InitializeComponent();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtBairro.Clear();
            txtCNPJ.Clear();
            txtComplemento.Clear();
            txtEmail.Clear();
            txtNomeFantasia.Clear();
            txtSalario.Clear();
            txtTelefone.Clear();
            txtTelefoneF.Clear();
            cbEstado.SelectedItem = null;

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
    }
}
