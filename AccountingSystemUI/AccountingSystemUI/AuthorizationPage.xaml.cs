using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private const string _noConnectionMessage = "Не удалось подключиться к серверу!";

        private const string _incorrectLoginOrPasswordMessage = "Не верный логин или пороль!";

        private const string _noData = "Данные не введены!";

        private void Connect(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Source = new Uri("MenuPage.xaml", UriKind.Relative);
        }
    }
}
