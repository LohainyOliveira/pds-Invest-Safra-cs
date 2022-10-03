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
    /// Lógica interna para ClienteJuridico.xaml
    /// </summary>
    public partial class CadastrarClienteJuridico : Window
    {
        ClienteJuridico _clienteJ = new ClienteJuridico();
        public CadastrarClienteJuridico()
        {
            InitializeComponent();
            Loaded += ClienteJuridicoFormWindow_Loaded;
        }
        public CadastrarClienteJuridico(ClienteJuridico clienteJ)
        {
            InitializeComponent();

            _clienteJ = clienteJ;
            Loaded += ClienteJuridicoFormWindow_Loaded;

        }


        private void ClienteJuridicoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;
            txtNomeCompleto.Text = _clienteJ.Nome;

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
