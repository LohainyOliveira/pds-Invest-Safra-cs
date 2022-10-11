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
using System.Windows.Threading;
using InvestSafra.Models;

namespace InvestSafra.Views
{
    /// <summary>
    /// Lógica interna para CadastrarFuncionario.xaml
    /// </summary>
    public partial class CadastrarFuncionario : Window
    {
        private Funcionario _funcionario = new Funcionario();
        public CadastrarFuncionario()
        {
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }
        public CadastrarFuncionario(Funcionario funcionario)
        {
            InitializeComponent();

            _funcionario = funcionario;
            Loaded += FuncionarioFormWindow_Loaded;

        }


        private void FuncionarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtComplemento.Text = _funcionario.Complemento;
            txtBairro.Text = _funcionario.Bairro;
            txtCidade.Text = _funcionario.Cidade;
            txtCPF.Text = _funcionario.CPF;
            txtEmail.Text = _funcionario.Email;
            txtfuncao.Text = _funcionario.Funcao;
            txtNomeCompleto.Text = _funcionario.Nome;
            txtRg.Text = _funcionario.RG;
            txtRua.Text = _funcionario.Rua;
            txtTelefone.Text = _funcionario.Telefone;
            
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {

            txtCPF.Clear();
            txtEmail.Clear();
            txtNomeCompleto.Clear();
            txtRg.Clear();
            txtRua.Clear();
            txtsalario.Clear();
            txtTelefone.Clear();

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
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _funcionario.Nome = txtNomeCompleto.Text;
            _funcionario.CPF = txtCPF.Text;
            _funcionario.RG = txtRg.Text;
            _funcionario.Sexo = cbSexo.Text;
            _funcionario.Telefone = txtTelefone.Text;
            _funcionario.Cidade = txtCidade.Text;
            _funcionario.Estado = cbEstado.Text;
            _funcionario.Rua = txtRua.Text;
            _funcionario.Bairro = txtBairro.Text;
            _funcionario.CEP = txtCEP.Text;
            _funcionario.Complemento = txtComplemento.Text;
            _funcionario.Email = txtEmail.Text;
            _funcionario.Funcao = txtfuncao.Text;
            _funcionario.Tipo = txtTipo.Text;
            _funcionario.Salario = Convert.ToDouble(txtsalario.Text);

           

            try
            {
                var dao = new FuncionarioDAO();

                if (_funcionario.Id > 0)
                {
                    dao.Update(_funcionario);
                }
                else
                {
                    dao.Insert(_funcionario);
                }

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            txtRua.Clear();
            txtNomeCompleto.Clear();
            txtCPF.Clear();
            txtRg.Clear();
            cbSexo = null;
            txtTelefone.Clear();
            txtCidade.Clear();
            cbEstado = null;
            txtRua.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtEmail.Clear();
            txtfuncao.Clear();
            txtTipo.Clear();
            txtsalario.Clear();
        }
        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
