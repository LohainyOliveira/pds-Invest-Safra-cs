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
    /// Lógica interna para ListaVenda.xaml
    /// </summary>
    public partial class ListaVenda : Window
    {
        public ListaVenda()
        {
            InitializeComponent();
            Loaded += VendaListaWindow_Loaded;
        }

        private void VendaListaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new VendaDAO();
                List<Venda> listaVenda = dao.List();

                dataGridVenda.ItemsSource = listaVenda;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelecionada = dataGridVenda.SelectedItem as Venda;

            var resultado = MessageBox.Show($"Deseja realmente Remover a escola{vendaSelecionada.Id}?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new VendaDAO();
                    dao.Delete(vendaSelecionada);

                    MessageBox.Show("Registros Removidos!");
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelecionada = dataGridVenda.SelectedItem as Venda;

            var form = new CadastrarVenda(vendaSelecionada);
            form.ShowDialog();
            form.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
