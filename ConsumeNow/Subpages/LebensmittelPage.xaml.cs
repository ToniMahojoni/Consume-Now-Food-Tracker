using ConsumeNow.Subpages;
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
    /// <summary>
    /// Interaction logic for LebensmittelPage.xaml
    /// </summary>
    public partial class LebensmittelPage : UserControl
    {
        public LebensmittelPage()
        {
            InitializeComponent();
        }

        LebensmittelAddPage lebensmitteladdpage = new LebensmittelAddPage();

        public void FoodButtonClick(object sender, RoutedEventArgs e)
        {
            DataTable.Content = lebensmitteladdpage;
            AddButton.Visibility = Visibility.Collapsed;
        }


    }
}
