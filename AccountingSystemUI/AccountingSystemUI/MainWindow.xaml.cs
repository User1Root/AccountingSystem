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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingSystemUI
{    
    public partial class MainWindow : Window
    {
        private bool isWindowNoraml = true;
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            ClientHelper.Connect(out bool isOldfRefreshtokenValid);
            if (isOldfRefreshtokenValid)
            {
                MainFrame.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));
            }
            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            base.Close();            
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizedWindow(object sender, RoutedEventArgs e)
        {

            WindowState = isWindowNoraml ? WindowState.Maximized : WindowState = WindowState.Normal;
            isWindowNoraml = !isWindowNoraml;
        }

        private void ToolBarPanelMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
