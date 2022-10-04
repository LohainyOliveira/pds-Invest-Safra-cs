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
    /// Lógica interna para ListaClienteJuridico.xaml
    /// </summary>
    public partial class ListaClienteJuridico : Window
    {
        public ListaClienteJuridico()
        {
            InitializeComponent();
            Loaded += ClienteJuridicoListaWindow_Loaded;
        }

        private void ClienteJuridicoListaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteJuridicoDAO();
                List<ClienteJuridico> listaClienteJ = dao.List();

                dataGridClienteJuridico.ItemsSource = listaClienteJ;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var clientJSelecionada = dataGridClienteJuridico.SelectedItem as ClienteJuridico;

            var resultado = MessageBox.Show($"Deseja realmente Remover a escola{clientJSelecionada.Nome}?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new ClienteJuridicoDAO();
                    dao.Delete(clientJSelecionada);

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
            var clientJSelecionada = dataGridClienteJuridico.SelectedItem as ClienteJuridico;

            var form = new CadastrarClienteJuridico(clientJSelecionada);
            form.ShowDialog();
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
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
