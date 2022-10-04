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
    /// Lógica interna para CadastrarFazenda.xaml
    /// </summary>
    public partial class CadastrarFazenda : Window
    {
        private Fazenda _fazenda = new Fazenda();
        public CadastrarFazenda()
        {
            InitializeComponent(); 
            Loaded += FazendaFormWindow_Loaded;
        }
        public CadastrarFazenda(Fazenda fazenda)
        {
            InitializeComponent();

            _fazenda = fazenda;
            Loaded += FazendaFormWindow_Loaded;

        }


        private void FazendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _fazenda.Nome;
            txtCnpj.Text = _fazenda.CNPJ;
            txtComplemento.Text = _fazenda.Complemento;
            txtLocalizacao.Text = _fazenda.Localizacao;
            txtProprietario.Text = _fazenda.Proprietario;
            txtNomeFantasia.Text = _fazenda.NomeFantasia;



        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCnpj.Clear();
            txtComplemento.Clear();
            txtLocalizacao.Clear();
            txtNome.Clear();
            txtNomeFantasia.Clear();
            txtProprietario.Clear();

            ExibirMensagemLimpar();
        }
        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click_1(object sender, RoutedEventArgs e)
        {
            _fazenda.CNPJ = txtCnpj.Text;
            _fazenda.Proprietario = txtProprietario.Text;
            _fazenda.Complemento = txtComplemento.Text;
            _fazenda.Nome = txtNome.Text;
            _fazenda.NomeFantasia = txtNomeFantasia.Text;
            _fazenda.Localizacao = txtLocalizacao.Text;

            try
            {
                var dao = new FazendaDAO();

                if (_fazenda.Id > 0)
                {
                    dao.Update(_fazenda);
                }
                else
                {
                    dao.Insert(_fazenda);
                }

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtCnpj.Clear();
            txtComplemento.Clear();
            txtLocalizacao.Clear();
            txtNome.Clear();
            txtNomeFantasia.Clear();
            txtProprietario.Clear();
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