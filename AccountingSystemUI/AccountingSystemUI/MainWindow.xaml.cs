using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

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
