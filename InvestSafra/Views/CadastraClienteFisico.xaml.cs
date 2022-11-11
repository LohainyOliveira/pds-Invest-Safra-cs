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
    /// Lógica interna para CadastraClienteFisico.xaml
    /// </summary>
    public partial class CadastraClienteFisico : Window
    {
        ClienteFisico _clienteF = new ClienteFisico();
        public CadastraClienteFisico()
        {
            InitializeComponent();
            Loaded += ClienteFisicoFormWindow_Loaded;
        }

        public CadastraClienteFisico(ClienteFisico clienteJ)
        {
            InitializeComponent();

            _clienteF = clienteJ;
            Loaded += ClienteFisicoFormWindow_Loaded;

        }


        private void ClienteFisicoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCompleto.Text = _clienteF.Nome;
            txtCEP.Text = _clienteF.CEP;
            txtRg.Text = _clienteF.RG;
            txtBairro.Text = _clienteF.Bairro;
            txtCPF.Text = _clienteF.CEP;
            txtEmail.Text = _clienteF.Email;
            txtMunicipio.Text = _clienteF.Cidade;
            txtTelefone.Text = _clienteF.Telefone;

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
            txtMunicipio.Clear();
            txtCEP.Clear();
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

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _clienteF.Nome = txtNomeCompleto.Text;
            _clienteF.CEP = txtCEP.Text;
            _clienteF.Bairro = txtBairro.Text;
            _clienteF.Cidade = txtMunicipio.Text;
            _clienteF.Complemento = txtComplemento.Text;
            _clienteF.CPF = txtCPF.Text;
            _clienteF.Email = txtEmail.Text;
            _clienteF.RG = txtRg.Text;
            _clienteF.Rua = txtRua.Text;
            _clienteF.Telefone = txtTelefone.Text;
            _clienteF.Estado = cbEstado.Text;
            _clienteF.Sexo = cbSexo.Text;

            try
            {
                var dao = new ClienteFisicoDAO();

                if (_clienteF.Id > 0)
                {
                    dao.Update(_clienteF);
                }
                else
                {
                    dao.Insert(_clienteF);
                }

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtBairro.Clear();
            txtComplemento.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNomeCompleto.Clear();
            txtRg.Clear();
            txtRua.Clear();
            txtMunicipio.Clear();
            txtCEP.Clear();
            txtTelefone.Clear();
            cbEstado.SelectedItem = null;
            cbSexo.SelectedItem = null;

            CadastroUsuario form = new CadastroUsuario();
            this.Close();
            form.ShowDialog();

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
    }
}
