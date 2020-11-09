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
    /// <summary>
    /// Логика взаимодействия для ESMGIveOutPage.xaml
    /// </summary>
    public partial class ESMGIveOutPage : Page
    {
        public ESMGIveOutPage()
        {
            InitializeComponent();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool serverAnswer = true;

            if (serverAnswer)
            {
                //кнопки Подтвердить и Отмена становятся видимыми и появляется галочка
                answerImage.Source = new BitmapImage(new Uri("Images/check.png", UriKind.Relative));
                confirmBTN.Visibility = Visibility.Visible;
                cancelBTN.Visibility = Visibility.Visible;
            }
            else
            {
                answerImage.Source = new BitmapImage(new Uri("Images/cross.png", UriKind.Relative));
                cancelBTN.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
