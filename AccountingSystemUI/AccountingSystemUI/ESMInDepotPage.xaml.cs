﻿using AccountingSystemUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public partial class ESMInDepotPage : Page
    {
        public ESMInDepotPage()
        {
            InitializeComponent();           
        }

        private void CreateDockPanelsForESMList(ESM[] esms)
        { 
            foreach(var esm in esms)
            {
                DockPanel dp = new DockPanel();
                Label label = new Label()
                {
                    FontSize = 20,
                    Content = "ЭНИ №" + esm.EsmId + "   ",
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.Transparent),
                    Margin = new Thickness(10, 0, 0, 0)
                };
                dp.Children.Add(label);

                var btn = new Button();
                btn.Style = (Style)Application.Current.Resources["ButtonForDockPanelStyle"] ?? throw new ArgumentException();
                dp.Children.Add(btn);

                //TODO:
                //заменить на окно с подробной информацией об эни.
                //btn.Click += new RoutedEventHandler((obj, e) => MessageBox.Show(ESMNumber));

                var brd = new Border()
                {
                    CornerRadius = new CornerRadius(10),
                    Child = dp,
                    BorderThickness = new Thickness(2),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    Background = new SolidColorBrush(Colors.SandyBrown)
                };

                ESMList.Items.Add(brd);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ESMList.Items.Clear();
            var button = sender as Button;
            button.IsEnabled = false;
            Tuple<HttpStatusCode, Depot> response = null;
            switch (button.Tag)
            {                
                case "0": response = ClientHelper.GetEsm(); break;
                case "1": response = ClientHelper.GetEsm(); break;
                case "2": response = ClientHelper.GetRecordedEsm(); break;
            }

            if (response.Item1 == System.Net.HttpStatusCode.OK)
            {
                var depot = response.Item2;
                switch (button.Tag)
                {
                    case "0": OutPutEsm(depot); break;
                    case "1": OutPutEsmWhoFromTheOtherDepots(depot); break;
                    case "2": OutPutEsmWhoInTravel(depot); break;
                }
                
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

            button.IsEnabled = true;
        }

        //фильтр статус - 1 и 2;
        private void OutPutEsm(Depot depot)
        {
            CreateDockPanelsForESMList(depot.EsmLastDepotNavigation);
        }

        //фильтр статус - 2;
        private void OutPutEsmWhoFromTheOtherDepots(Depot depot)
        {
            var esms = from esm in depot.EsmLastDepotNavigation where esm.Status == 2 select esm;
            CreateDockPanelsForESMList(esms.ToArray());           
        }

        //фильтр статус - 3;
        private  void OutPutEsmWhoInTravel(Depot depot)
        {
            var esms = from esm in depot.EsmHomeDepotNavigation where esm.Status == 2 select esm;
            CreateDockPanelsForESMList(esms.ToArray());
        }
    }
}
