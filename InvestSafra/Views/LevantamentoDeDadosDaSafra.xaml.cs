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
            Loaded += safraFisicoFormWindow_Loaded;
        }
        public LevantamentoDeDadosDaSafra(Safra safras)
        {
            InitializeComponent();

            _safra = safras;
            Loaded += safraFisicoFormWindow_Loaded;

        }


        private void safraFisicoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dtPickerDataFim.SelectedDate = _safra.DataFim;
            dtPickerDataInicio.SelectedDate = _safra.DataInicio;

        }

		private void btVoltar_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
	}
}
