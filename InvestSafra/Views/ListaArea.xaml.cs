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
    /// Lógica interna para ListaArea.xaml
    /// </summary>
    public partial class ListaArea : Window
    {
        public ListaArea()
        {
            InitializeComponent();
            Loaded += AreaListaWindow_Loaded;
        }

        private void AreaListaWindow_Loaded(object sender, RoutedEventArgs e)
        {
           CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new AreaDAO();
                List<Area> listasAreas = dao.List();

                dataGridArea.ItemsSource = listasAreas;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var areaSelecionada = dataGridArea.SelectedItem as Area;

            var resultado = MessageBox.Show($"Deseja realmente Remover a escola{areaSelecionada.Metros}?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new AreaDAO();
                    dao.Delete(areaSelecionada);

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
            var areaSelecionada = dataGridArea.SelectedItem as Area;

            var form = new CadastrarArea(areaSelecionada);
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

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
            CadastrarArea form = new CadastrarArea();
            this.Close();
            form.ShowDialog();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
            MenuWindow form = new MenuWindow();
            this.Close();
            form.ShowDialog();
		}
	}
}
