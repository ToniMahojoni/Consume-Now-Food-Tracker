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

namespace ConsumeNow.Subpages
{
    /// <summary>
    /// Interaction logic for LebensmittelAddPage.xaml
    /// </summary>
    public partial class LebensmittelAddPage : UserControl
    {
        public LebensmittelAddPage()
        {
            InitializeComponent();
        }

        private void OpenableChecked(object sender, RoutedEventArgs e)
        {
            if(OpenableChecked != null)
            {
                CheckBox box = sender as CheckBox;

                if(box.IsChecked ==  true)
                {
                    VBopenedBox.Visibility = Visibility.Visible;
                    VBopenedText.Visibility = Visibility.Visible;
                    VBremainingBox.Visibility = Visibility.Visible;
                    VBremainingText.Visibility = Visibility.Visible;
                } else if(box.IsChecked == false) 
                    {
                        VBopenedBox.Visibility = Visibility.Collapsed;
                        VBopenedText.Visibility = Visibility.Collapsed;
                        VBremainingBox.Visibility = Visibility.Collapsed;
                        VBremainingText.Visibility = Visibility.Collapsed;
                    }
                }
                
            }

    }
    }

