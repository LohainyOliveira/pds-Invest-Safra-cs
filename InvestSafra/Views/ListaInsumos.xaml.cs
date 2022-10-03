using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using InvestSafra.Models;

namespace InvestSafra.Views
{
    /// <summary>
    /// Lógica interna para ListaInsumos.xaml
    /// </summary>
    public partial class ListaInsumos : Window
    {
        public ListaInsumos()
        {
            InitializeComponent();

            Loaded += InsumoListaWindow_Loaded;
        }

        private void InsumoListaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new InsumosDAO();
                List<Insumos> listaInsumos = dao.List();

                dataGridInsumo.ItemsSource = listaInsumos;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var insumosSelecionada = dataGridInsumo.SelectedItem as Insumos;

            var resultado = MessageBox.Show($"Deseja realmente Remover a escola{insumosSelecionada.Id}?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new InsumosDAO();
                    dao.Delete(insumosSelecionada);

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
            var insumosSelecionada = dataGridInsumo.SelectedItem as Insumos;

            var form = new CadastrarInsumos(insumosSelecionada);
            form.ShowDialog();
            form.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
            if(e.ChangedButton == MouseButton.Left)
			{
                this.DragMove();
			}

		}

        private bool IsMaxinized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
			{
                if(IsMaxinized)
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
