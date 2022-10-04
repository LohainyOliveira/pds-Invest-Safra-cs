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
    /// Lógica interna para Venda.xaml
    /// </summary>
    public partial class CadastrarVenda : Window
    {
        private Venda _venda = new Venda();
        public CadastrarVenda()
        {
            InitializeComponent();
            Loaded += VendaFormWindow_Loaded;
        }
        public CadastrarVenda(Venda venda)
        {
            InitializeComponent();

            _venda = venda;
            Loaded += VendaFormWindow_Loaded;

        }


        private void VendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
          

        }
    }
}
