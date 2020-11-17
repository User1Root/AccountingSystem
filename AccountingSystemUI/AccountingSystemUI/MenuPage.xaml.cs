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
    //TODO:допилить кнопку выбора депо.
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            userId.Content = $" User Id :{ClientHelper.UserId}";
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
                case "4": LogOut();break;
            }
        }

        private void LogOut()
        {
            ClientHelper.LogOut();
            this.NavigationService.GoBack();
        }
    }
}
