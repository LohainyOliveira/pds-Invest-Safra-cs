using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
