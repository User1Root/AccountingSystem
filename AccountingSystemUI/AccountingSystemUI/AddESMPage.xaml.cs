﻿using System;
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
    public partial class AddESMPage : Page
    {
        public AddESMPage()
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
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {response.Item1}");
                //ClientHelper.LogOut();
            }
        }

    }
}
