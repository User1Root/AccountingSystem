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
            else if(depots.Item1 == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Время подключения истекло. Пожалуйста, авторизуйтесь повторно.");
                LogOut();
            }
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {depots.Item1}");
                //Что тут делать?
                LogOut();
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
            if(this.NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new Uri("AuthorizationPage.xaml", UriKind.Relative));
            }
        }
    }
}
