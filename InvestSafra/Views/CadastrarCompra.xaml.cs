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
    /// Lógica interna para CadastrarCompra.xaml
    /// </summary>
    public partial class CadastrarCompra : Window
    {
        private Compra _compra = new Compra();
        public CadastrarCompra()
        {
            InitializeComponent(); 
            Loaded += CompraFormWindow_Loaded;
        }
        public CadastrarCompra(Compra compra)
        {
            InitializeComponent();

            _compra = compra;
            Loaded += CompraFormWindow_Loaded;

        }


        private void CompraFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDescricao.Text = _compra.Descricao;
            txtNome.Text = _compra.Nome;



        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

            txtDescricao.Clear();
            txtNome.Clear();
            txtQuantidade.Clear();
            dtPickerDataNascimento.SelectedDate= null;

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

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _compra.Nome = txtNome.Text;
            _compra.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            _compra.Descricao = txtDescricao.Text;
            _compra.Data = dtPickerDataNascimento.SelectedDate;

            try
            {
                var dao = new CompraDAO();
                dao.Insert(_compra);

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
