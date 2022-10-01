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
using System.Windows.Threading;
using InvestSafra.Views;


namespace InvestSafra
{
	/// <summary>
	/// Lógica interna para TelaPrincipalWindow.xaml
	/// </summary>
	public partial class TelaPrincipalWindow : Window
	{

		DispatcherTimer timer;

		double PainelWidth;
		bool hidden;
		public TelaPrincipalWindow()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;

			PainelWidth = SidePainel.Width;

            Loaded += TelaPrincipalWindow_Loaded;
		}

        private void TelaPrincipalWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //new CadastrarFazenda().Show();
            //this.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
			if(hidden)
            {
				SidePainel.Width += 1;
				if(SidePainel.Width >= PainelWidth)
                {
					timer.Stop();
					hidden = false;
                }


            }
			else
            {

				SidePainel.Width -= 1;
				if (SidePainel.Width <=30)
				{
					timer.Stop();
					hidden = true;
				}
			}
            
        }

        private void btCadastra_Click(object sender, RoutedEventArgs e)
		{
			CadastrarMaquinas form = new CadastrarMaquinas();
			form.ShowDialog();
		}

		private void btEntrar_Click(object sender, RoutedEventArgs e)
		{

		}

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {


			Entrar form = new Entrar();
			form.ShowDialog();
		}

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {
			timer.Start();
        }


        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void painelHeader_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
				DragMove();
            }

        }

		private void btCadastrar_Click(object sender, RoutedEventArgs e)
		{
			Insumos form = new Insumos();
			form.ShowDialog();
		}

		private void btHome_Click(object sender, RoutedEventArgs e)
		{
			ListaInsumos form = new ListaInsumos();
			form.ShowDialog();
		}
	}
}
