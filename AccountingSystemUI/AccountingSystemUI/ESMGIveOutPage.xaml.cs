using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AccountingSystemUI
{
    public partial class ESMGIveOutPage : Page
    {
        public ESMGIveOutPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt64(driverIdBox.Text);
                Convert.ToInt64(esmIdBox.Text);
            }
            catch
            {
                MessageBox.Show("Данные имели не верный формат.");
                return;
            }

            var driverId = Convert.ToInt64(driverIdBox.Text);
            var esmId = Convert.ToInt64(esmIdBox.Text);

            var response = ClientHelper.GiveOutEsm(driverId, esmId);

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
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {response.Item1}");
                //ClientHelper.LogOut();
            }
        }
    }
}
