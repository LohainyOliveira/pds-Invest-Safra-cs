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
	/// Lógica interna para LevantamentoDeDadosDaSafra.xaml
	/// </summary>
	public partial class LevantamentoDeDadosDaSafra : Window
	{
		private Safra _safra = new Safra();
		public LevantamentoDeDadosDaSafra()
		{
			InitializeComponent();
			Loaded += SafraFormWindow_Loaded;
		}

		public LevantamentoDeDadosDaSafra(Safra safra)
		{
			InitializeComponent();

			_safra = safra;
			Loaded += SafraFormWindow_Loaded;

		}

		private void SafraFormWindow_Loaded(object sender, RoutedEventArgs e)
		{
			
		}


		private void btSair_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
	}
}
