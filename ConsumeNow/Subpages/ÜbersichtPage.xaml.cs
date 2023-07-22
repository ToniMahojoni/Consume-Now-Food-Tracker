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
    /// Interaction logic for ÜbersichtPage.xaml
    /// </summary>
    public partial class ÜbersichtPage : UserControl
    {
        public ÜbersichtPage()
        {
            InitializeComponent();
        }

        CategoryAddPage categoryaddpage = new CategoryAddPage();

        private void AddCatButton_Click(object sender, RoutedEventArgs e)
        {
            CCÜbersichtTable.Content = categoryaddpage;
            CCCatAddButton.Visibility = Visibility.Collapsed;
        }
    }
}
