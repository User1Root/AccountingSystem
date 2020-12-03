using AccountingSystemUI.Models;
using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                    FontSize = 17,
                    Content = "ЭНИ №" + esm.EsmId + "   ",
                    Background = new SolidColorBrush(Colors.White),
                    BorderBrush = new SolidColorBrush(Colors.White),
                    Margin = new Thickness(10, 0, 0, 0)
                };
                dp.Children.Add(label);

                var btn = new Button();
                
                btn.Style = (Style)Application.Current.Resources["ButtonForDockPanelStyle"] ?? throw new ArgumentException();
                dp.Children.Add(btn);

                btn.Click += new RoutedEventHandler((obj, e) => { GetEsmInformation(esm.EsmId); }
                );

                var brd = new Border()
                {
                    CornerRadius = new CornerRadius(10),
                    Child = dp,
                    BorderThickness = new Thickness(2),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    Background = new SolidColorBrush(Colors.White)
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
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {response.Item1}");
                //ClientHelper.LogOut();
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

        private void GetEsmInformation(long esmId) => this.NavigationService.Navigate(new ESMSearchPage(esmId));
    }
}
