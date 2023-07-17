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

namespace ConsumeNow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string senderName = (sender as Button).Name;
            switch (senderName)
            {
                case "LebensmittelButton":
                    CC.Content = new LebensmittelPage();
                    break;
                case "FinanzenButton":
                    CC.Content = new FinanzenPage();
                    break;
                case "EinkaufslisteButton":
                    CC.Content = new EinkaufslistePage();
                    break;
                case "EinstellungenButton":
                    CC.Content = new EinstellungenPage();
                    break;
                default: break;

            }
        }
    }
}
