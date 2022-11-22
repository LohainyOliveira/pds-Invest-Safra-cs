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
    /// Lógica interna para ControDeEstoque.xaml
    /// </summary>
    public partial class ControDeEstoque : Window
    {
        private Estoque _estoque = new Estoque();
        public ControDeEstoque()
        {
            InitializeComponent();
            Loaded += EstoqueFormWindow_Loaded;
        }

        public ControDeEstoque(Estoque estoque)
        {
            InitializeComponent();

            _estoque = estoque;
            Loaded += EstoqueFormWindow_Loaded;

        }

		public ControDeEstoque(Area estoqueSelecionada)
		{
			this.estoqueSelecionada = estoqueSelecionada;
		}

		private void EstoqueFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDescricao.Text = _estoque.Descricao;
            txtMedida.Text = _estoque.Medida;
            txtTipoInsumo.Text = _estoque.Tipo_Insumo;
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

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
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
		private Area estoqueSelecionada;

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
            _estoque.Descricao = txtDescricao.Text;
            _estoque.Medida = txtMedida.Text;
            _estoque.Tipo_Insumo = txtTipoInsumo.Text;
            _estoque.Quantidade_Insumos = Convert.ToInt32(txtQuantInsumos.Text);
            _estoque.Quantidade_Semente = Convert.ToInt32(txtQuantSementes.Text);

            try
            {
                var dao = new EstoqueDAO();

                if (_estoque.Id > 0)
                {
                    dao.Update(_estoque);
                }
                else
                {
                    dao.Insert(_estoque);
                }

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
