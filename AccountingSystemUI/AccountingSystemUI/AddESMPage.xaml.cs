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
    //TODO:
    //Унаследовать от giveOutPage,чтобы код не повторялся.
    public partial class AddESMPage : Page
    {
        public AddESMPage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var driverId = Convert.ToInt64(driverIdBox.Text);
            var esmId = Convert.ToInt64(esmIdBox.Text);

            var response = ClientHelper.TakeEsm(driverId, esmId);

            if (response.Item1 == System.Net.HttpStatusCode.OK)
            {
                answerImage.Source = new BitmapImage(new Uri("Images/check.png", UriKind.Relative));
            }
            else if (response.Item1 == System.Net.HttpStatusCode.BadRequest)
            {
                answerImage.Source = new BitmapImage(new Uri("Images/cross.png", UriKind.Relative));
                //TODO:
                //добавить вывод проблемы!.
                MessageBox.Show("Не корректные данные");
            }
            else if (response.Item1 == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Время подключения истекло. Пожалуйста, авторизуйтесь повторно.");
                ClientHelper.LogOut();
            }
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {response.Item1}");
                ClientHelper.LogOut();
            }
        }

    }
}
