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
        private Fornecedor _fornecedor = new Fornecedor();
        public CadastrarFornecedor()
        {
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }
        public CadastrarFornecedor(Fornecedor fornecedor)
        {
            InitializeComponent();

            _fornecedor = fornecedor;
            Loaded += FornecedorFormWindow_Loaded;

        }


        private void FornecedorFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeFantasia.Text = _fornecedor.Nome_Fantasia;
            txtRazaoSocial.Text = _fornecedor.Razao_Social;
            txtBairro.Text = _fornecedor.Bairro;
            txtCep.Text = _fornecedor.CEP;
            txtCidade.Text = _fornecedor.Cidade;
            txtCNPJ.Text = _fornecedor.CNPJ;
            txtEmail.Text = _fornecedor.Email;
            txtTelefone.Text = _fornecedor.Telefone_Pessoal;
            txtTelefoneF.Text = _fornecedor.Telefone_Empresa;
            txtRua.Text = _fornecedor.Rua;

        }
        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtBairro.Clear();
            txtCNPJ.Clear();
            txtComplemento.Clear();
            txtEmail.Clear();
            txtNomeFantasia.Clear();
            txtRazaoSocial.Clear();
            txtTelefone.Clear();
            txtTelefoneF.Clear();
            cbEstado.SelectedItem = null;
            txtCep.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            txtRua.Clear();

            ExibirMensagemLimpar();
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _fornecedor.Telefone_Pessoal = txtTelefone.Text;
            _fornecedor.CEP = txtCep.Text;
            _fornecedor.Bairro = txtBairro.Text;
            _fornecedor.Cidade = txtCidade.Text;
            _fornecedor.CNPJ = txtCNPJ.Text;
            _fornecedor.Complemento = txtComplemento.Text;
            _fornecedor.Email = txtComplemento.Text;
            _fornecedor.Nome_Fantasia = txtNomeFantasia.Text;
            _fornecedor.Razao_Social = txtRazaoSocial.Text;
            _fornecedor.Rua = txtRua.Text;
            _fornecedor.Telefone_Empresa = txtTelefoneF.Text;
            _fornecedor.Estado = cbEstado.Text;

            try
            {
                var dao = new FornecedorDAO();
                dao.Insert(_fornecedor);

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtBairro.Clear();
            txtCNPJ.Clear();
            txtComplemento.Clear();
            txtEmail.Clear();
            txtNomeFantasia.Clear();
            txtRazaoSocial.Clear();
            txtTelefone.Clear();
            txtTelefoneF.Clear();
            cbEstado.SelectedItem = null;
            txtCep.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            txtRua.Clear();
        }
    }
}
