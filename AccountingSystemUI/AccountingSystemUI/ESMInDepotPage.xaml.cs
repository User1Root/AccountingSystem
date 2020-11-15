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
    /// Логика взаимодействия для ESMInDepotPage.xaml
    /// </summary>
    public partial class ESMInDepotPage : Page
    {
        public ESMInDepotPage()
        {
            InitializeComponent();           
        }

        static Border DockPanelForESMList(string ESMNumber)
        {
            DockPanel dp = new DockPanel();            
            
            Label label = new Label() 
            {
                FontSize = 20,
                Content = "ЭНИ №" + ESMNumber + "   ",
                Background = new SolidColorBrush(Colors.Transparent),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                Margin = new Thickness(10,0,0,0)
            };
            dp.Children.Add(label);

            var btn = new Button();
            btn.Style = (Style)Application.Current.Resources["ButtonForDockPanelStyle"] ?? throw new ArgumentException();
                
            btn.Click += new RoutedEventHandler((obj, e) => MessageBox.Show(ESMNumber));
            
            dp.Children.Add(btn);

            var brd = new Border()
            {
                CornerRadius = new CornerRadius(10),
                Child = dp,
                BorderThickness = new Thickness(2),
                BorderBrush = new SolidColorBrush(Colors.Black),
                Background = new SolidColorBrush(Colors.SandyBrown)
            };

            return brd;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ESMList.Items.Clear();// при нажатии на кнопку ListBox отчищается от предыдущих заполнений
            var button = sender as Button;
            button.IsEnabled = false;
            switch (button.Tag)
            {
                
                case "0":  break;
                case "1":  break;
                case "2":  break;
            }

            // можно добавть цикл или изменить метод
            String ESMNumber = "123456";
            ESMList.Items.Add(DockPanelForESMList(ESMNumber));
            ESMNumber = "654321";
            ESMList.Items.Add(DockPanelForESMList(ESMNumber));

            button.IsEnabled = true;
        }
    }
}
