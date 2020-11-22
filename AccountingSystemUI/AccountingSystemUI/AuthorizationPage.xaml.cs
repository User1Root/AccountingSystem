using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AccountingSystemUI
{
    //TODO:
    //Добавить 
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
                var statusCode = await Task.Run(() => ClientHelper.Login(login, pass));
                if (statusCode == System.Net.HttpStatusCode.OK)
                {
                    (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));
                }
                else if (statusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("неверный логин или пороль!");
                }
                else
                {
                    MessageBox.Show($"Возникли проблемы! Код ошибки : {statusCode}");
                }                
                LoginBox.IsEnabled = true;
                PasswordBox.Clear();
                PasswordBox.IsEnabled = true;               
                push.IsEnabled = true;
            }                                 
        }

    }
}
