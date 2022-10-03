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

namespace InvestSafra.Views
{
	/// <summary>
	/// Lógica interna para MenuWindow.xaml
	/// </summary>
	public partial class MenuWindow : Window
	{
		DispatcherTimer timer;

		double PainelWidth;
		bool hidden;
		public MenuWindow()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
			timer.Tick += Timer_Tick;

			PainelWidth = SidePainel.Width;

			Loaded += MenuWindow_Loaded;
			InitializeComponent();
		}



		private void MenuWindow_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (hidden)
			{
				SidePainel.Width += 1;
				if (SidePainel.Width >= PainelWidth)
				{
					timer.Stop();
					hidden = false;
				}


			}
			else
			{

				SidePainel.Width -= 1;
				if (SidePainel.Width <= 45)
				{
					timer.Stop();
					hidden = true;
				}
			}

		}

		private void MaxBtn_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Normal)
			{
				WindowState = WindowState.Maximized;
			}
			else
			{
				if (WindowState == WindowState.Maximized)
				{
					WindowState = WindowState.Normal;
				}
			}
		}

		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void btMenu_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();
		}


		private void painelHeader_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}

		}

	}
}
