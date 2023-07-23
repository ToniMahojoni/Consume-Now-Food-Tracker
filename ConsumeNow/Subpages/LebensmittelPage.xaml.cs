using ConsumeNow.Subpages;
using System;
using System.Collections.Generic;
using System.Data;
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
 
        public void Window_Loaded_LebensmittelPage(object sender, RoutedEventArgs e)
        {    
            DataTable dt = new DataTable();

            string[] ColumnNames = { "Name", "Typ", "Mindesthaltbarkeitsdatum", "Kaufdatum", "Menge", "Preis", "geöffnet", "verbleibend" };

            foreach (string ColumnName in ColumnNames)
            {
                dt.Columns.Add(ColumnName, typeof(string));
            }
           

            foreach (Entry element in MainWindow.entries)
            {
              
                dt.Rows.Add(element.ToString().Split(','));
            }


            DataView dv = new DataView(dt);
            LebensmittelTable.ItemsSource = dv;

        }
    }
}
