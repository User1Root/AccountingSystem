using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    //TODO:
    //Добавить жесткую фиксацию элементов на grid.
    //крутящуюся загрузку.
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LoginBox.IsEnabled = false;
            PasswordBox.IsEnabled = false;
            push.IsEnabled = false;
            if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пороль");
                PasswordBox.Clear();
                LoginBox.IsEnabled = true;
                PasswordBox.IsEnabled = true;
                push.IsEnabled = true;
            }
            else
            {
                var login = LoginBox.Text;
                var pass = PasswordBox.Password;                
                var statusCode = await ClientHelper.Login(login, pass);
                if (statusCode == System.Net.HttpStatusCode.OK)
                {
                    NavigationService.Source = new Uri("MenuPage.xalm", UriKind.Relative);
                }
                else if (statusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("неверный логин или пороль!");
                }
                else
                {
                    MessageBox.Show("Не удаётся подключиться к серверу!");
                }                
                LoginBox.IsEnabled = true;
                PasswordBox.Clear();
                PasswordBox.IsEnabled = true;               
                push.IsEnabled = true;
            }                                 
        }

    }
}
