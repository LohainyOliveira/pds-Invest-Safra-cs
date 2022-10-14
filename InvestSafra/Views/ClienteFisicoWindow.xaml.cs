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
    /// Lógica interna para ClienteFisico.xaml
    /// </summary>
    public partial class ClienteFisicoWindow : Window
    {
        private ClienteFisico _clienteFisico = new ClienteFisico();

        public ClienteFisicoWindow()
        {
            InitializeComponent();
            Loaded += ClienteFisicoFormWindow_Loaded;
        }
        public ClienteFisicoWindow(ClienteFisico clienteF)
        {
            InitializeComponent();

            _clienteFisico = clienteF;
            Loaded += ClienteFisicoFormWindow_Loaded;

        }


        private void ClienteFisicoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
           


        }

        private void ExibirMensagemLimpar()
        {
            MessageBox.Show($"Campos Limpos com Sucesso", "Limpeza Concluida",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExibirMensagemSalvar()
        {
            MessageBox.Show($"Campos Salvos com Sucesso!", "Registros Salvos",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void btLimpar_Click_1(object sender, RoutedEventArgs e)
        {
            

            ExibirMensagemLimpar();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                var dao = new ClienteFisicoDAO();
                dao.Insert(_clienteFisico);

                ExibirMensagemSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
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
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

   
}
