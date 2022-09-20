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
    /// Lógica interna para ClienteFisico.xaml
    /// </summary>
    public partial class ClienteFisicoWindow : Window
    {
        private ClienteFisico _clienteFisico = new ClienteFisico();

        public ClienteFisicoWindow()
        {
            InitializeComponent();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtBairro.Clear();
            txtComplemento.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNomeCompleto.Clear();
            txtRg.Clear();
            txtRua.Clear();
            txtSalario.Clear();
            txtSetor.Clear();
            txtTelefone.Clear();
            cbEstado.SelectedItem = null;
            cbSexo.SelectedItem = null;

            ExibirMensagemLimpar();
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _clienteFisico.Nome = txtNomeCompleto.Text;
            _clienteFisico.CPF = txtCPF.Text;
            _clienteFisico.Complemento = txtComplemento.Text;
            _clienteFisico.Email = txtEmail.Text;
            _clienteFisico.Bairro = txtBairro.Text;
            _clienteFisico.RG = txtRg.Text;
            _clienteFisico.Rua = txtRua.Text;
            _clienteFisico.Telefone = txtTelefone.Text;
        }
    }
}
