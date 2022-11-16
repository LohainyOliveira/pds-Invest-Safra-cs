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
    /// Lógica interna para CadastraCaixa.xaml
    /// </summary>
    public partial class CadastraCaixa : Window
    {
        Caixa _caixa = new Caixa();
        public CadastraCaixa()
        {
            InitializeComponent();
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
            _caixa.Data_Hora = dtDia.SelectedDate;
            _caixa.Descricao = txtDescricao.Text;
            _caixa.ValorCredito = Convert.ToDouble(txtValorcredito.Text);
            _caixa.ValorDebito = Convert.ToDouble(txtValorDebito.Text);
            _caixa.SaldoFinal = Convert.ToDouble(txtSaldofinal.Text);
            _caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
            _caixa.Numero = Convert.ToInt32(txtNumero.Text);
            _caixa.Troco = Convert.ToDouble(txtTroco.Text);

            try
            {
                var dao = new CaixaDAO();

                if (_caixa.Id > 0)
                {
                    dao.Update(_caixa);
                }
                else
                {
                    dao.Insert(_caixa);
                }

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dtDia.SelectedDate = null;
            txtDescricao.Clear();
            txtNumero.Clear();
            txtSaldofinal.Clear();
            txtSaldoInicial.Clear();
            txtTroco.Clear();
            txtValorcredito.Clear();
            txtValorDebito.Clear();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            dtDia.SelectedDate = null;
            txtDescricao.Clear();
            txtNumero.Clear();
            txtSaldofinal.Clear();
            txtSaldoInicial.Clear();
            txtTroco.Clear();
            txtValorcredito.Clear();
            txtValorDebito.Clear();
          
            ExibirMensagemLimpar();
        }
    }
}
