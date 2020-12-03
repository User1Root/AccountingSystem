using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AccountingSystemUI
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            userId.Content = $" User Id :{ClientHelper.UserId}";
            depotId.SelectionChanged += ClientHelper.DepotIdWasChanged;
            ClientHelper.LogOutHandler += LogOut;
            var depots = ClientHelper.GetDepots();
            if(depots.Item1 == System.Net.HttpStatusCode.OK)
            {
                foreach(var depot in depots.Item2)
                {
                    depotId.Items.Add($"{depot.depotId}: {depot.depotName}");
                }
                depotId.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {depots.Item1}");
                //Что тут делать?
                //LogOut();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch(button.Tag)
            {
                case "0": MenuFrame.Source = new Uri("ESMSearchPage.xaml", UriKind.Relative); break;
                case "1": MenuFrame.Source = new Uri("ESMInDepotPage.xaml", UriKind.Relative); break;
                case "2": MenuFrame.Source = new Uri("AddESMPage.xaml", UriKind.Relative); break;
                case "3": MenuFrame.Source = new Uri("ESMGiveOutPage.xaml", UriKind.Relative); break;
                case "4": ClientHelper.LogOut(); break;
            }
        }

        private void LogOut()
        {
            var frame = (Application.Current.MainWindow as MainWindow).MainFrame;
            frame.Navigate(new Uri("AuthorizationPage.xaml", UriKind.Relative));
            
        }
    }
}
