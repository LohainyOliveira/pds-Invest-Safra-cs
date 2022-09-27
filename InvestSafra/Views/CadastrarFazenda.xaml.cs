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
                dao.Insert(_fazenda);

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
    }
}
