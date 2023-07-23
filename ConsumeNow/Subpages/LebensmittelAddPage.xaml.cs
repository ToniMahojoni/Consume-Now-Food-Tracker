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
            if (OpenableChecked != null)
            {
                CheckBox box = sender as CheckBox;

                if (box.IsChecked == true)
                {
                    geöffnettextborder.Visibility = Visibility.Visible;
                    verbleibendtextboder.Visibility = Visibility.Visible;
                    openedCB.Visibility = Visibility.Visible;
                    verbleibendtextbox.Visibility = Visibility.Visible;
                }
                else 
                {
                    geöffnettextborder.Visibility = Visibility.Collapsed;
                    verbleibendtextboder.Visibility = Visibility.Collapsed;
                    openedCB.Visibility = Visibility.Collapsed;
                    verbleibendtextbox.Visibility = Visibility.Collapsed;
                }
            }


        }
            
        }
    }
    

        


