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
    /// Lógica interna para Produto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {

        private Produto _produto = new Produto();
        public CadastrarProduto()
        {
            InitializeComponent();
            Loaded += ProdutoFormWindow_Loaded;
        }

        public CadastrarProduto(Produto produto)
        {
            InitializeComponent();

            _produto = produto;
            Loaded += ProdutoFormWindow_Loaded;

        }


        private void ProdutoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDescricao.Text = _produto.Descricao;
            txtMarca.Text = _produto.Marca;
            txtNome.Text = _produto.Nome;
            txtQuantidade = _produto.Nome;
            txtvalor = _produto.Valor;

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
