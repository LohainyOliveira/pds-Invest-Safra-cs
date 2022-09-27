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
    /// Lógica interna para CadastrarArea.xaml
    /// </summary>
    public partial class CadastrarArea : Window
    {
        private Area _area = new Area();
        public CadastrarArea()
        {
            InitializeComponent();
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

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _area.Nome_Responsavel = txtresponsavel.Text;
            _area.Localizacao = txtLocalizacao.Text;
            _area.Descricao = txtDescricao.Text;
            _area.CNPJ = txtcnpj.Text;
            _area.Nome_Terreno = txtNomeTerreno.Text;
            _area.Metros = txtMetros.Text;

            try
            {
                var dao = new AreaDAO();
                dao.Insert(_area);

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtcnpj.Clear();
            txtDescricao.Clear();
            txtLocalizacao.Clear();
            txtMetros.Clear();
            txtNomeTerreno.Clear();
            txtresponsavel.Clear();

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtcnpj.Clear();
            txtDescricao.Clear();
            txtLocalizacao.Clear();
            txtMetros.Clear();
            txtNomeTerreno.Clear();
            txtresponsavel.Clear();

            ExibirMensagemLimpar();
        }
    }
}
