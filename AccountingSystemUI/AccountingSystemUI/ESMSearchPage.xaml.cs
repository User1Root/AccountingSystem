using AccountingSystemUI.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AccountingSystemUI
{
    public partial class ESMSearchPage : Page
    {
        public ESMSearchPage()
        {
            InitializeComponent();
        }

        public ESMSearchPage(long esmId)
        {
            InitializeComponent();
            searchBnt.Visibility = Visibility.Hidden;
            inputBx.IsReadOnly = true;
            inputBx.Text = esmId.ToString();
            backBtn.Visibility = Visibility.Visible;
            SeachInfo(new object(), new RoutedEventArgs());
        }

        private void SeachInfo(object sender, RoutedEventArgs e)
        {

            try
            {
                Convert.ToInt64(inputBx.Text);
            }
            catch
            {
                MessageBox.Show("Данные имели не верный формат.");
                return;
            }

            var esmId = Convert.ToInt64(inputBx.Text);
            var response = ClientHelper.GetEsmInfo(esmId);
            ESM esm;

            if (response.Item1 == System.Net.HttpStatusCode.OK)
            {
                esm = response.Item2;
            }
            else if (response.Item1 == System.Net.HttpStatusCode.NotFound)
            {
                MessageBox.Show($"ЭНИ не найдено!");
                return;
            }
            else
            {
                MessageBox.Show($"Возникли проблемы при загрузке страницы! Код ошибки : {response.Item1}");
                //ClientHelper.LogOut();
                return;
            }
            if (esm == null)
                throw new ArgumentNullException("Esm was null!");

            PrintEsm(esm);

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PrintEsm(ESM esm)
        {
            var esmInfo = new StringBuilder();

            esmInfo.AppendLine($"Номер ЭНИ : { esm.EsmId}");

            string statusMsg = null;
            switch(esm.Status)
            {
                case 1: statusMsg = "В родном депо."; break;
                case 2: statusMsg = "В поездке."; break;
                case 3: statusMsg = "В чужом депо."; break;
                default: throw new ArgumentException("status was invalid!");
            }
            esmInfo.AppendLine($"Статус ЭНИ : {statusMsg}");

            esmInfo.AppendLine($"Номер родного депо: {esm.HomeDepotNavigation.depotId}");
            esmInfo.AppendLine($"Местоположение родного депо: {esm.HomeDepotNavigation.depotName}");
            esmInfo.AppendLine($"Номер последнего депо: {esm.LastDepotNavigation.depotId}");
            esmInfo.AppendLine($"Местоположение последнего депо: {esm.LastDepotNavigation.depotName}");

            if (esm.LastDriver != null)
                esmInfo.AppendLine($"Номер последниго машиниста: {esm.LastDriver}");


            resultTextBox.Text = esmInfo.ToString();
        }
    }
}
