using ConsumeNow.Database;
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
            DataTable dt1 = new DataTable();

            string[] ColumnNames1 = { "ID", "Typ", "Name", "Mindesthaltbarkeitsdatum", "Kaufdatum", "Menge", "Preis", "geöffnet", "verbleibend" };

            foreach (string ColumnName in ColumnNames1)
            {
                dt1.Columns.Add(ColumnName, typeof(string));
            }
           

            foreach (Entry element in MainWindow.entries)
            {
                string[] rowcontent = element.ToString().Split(',');
                Array.Resize(ref rowcontent, rowcontent.Length + 1);
                Array.Copy(rowcontent, 0,rowcontent,1, rowcontent.Length-1);
                rowcontent[0] = Convert.ToString(element.ID);
                dt1.Rows.Add(rowcontent);
            }


            DataView dv1 = new DataView(dt1);
            LebensmittelTable.ItemsSource = dv1;

        }

        private void LöschenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageDatabase.DeleteEntry(MainWindow.entries, Convert.ToUInt32(LöschenIDTB.Text.ToString()));
                LöschenLabel.Content = String.Empty;
                LöschenIDTB.Text = String.Empty;
                DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, "./Database/Data/ExampleEntries.csv");
                Window_Loaded_LebensmittelPage(sender, e);
                

            }
            catch
            {
                LöschenLabel.Content = "fehlgeschlagen!";
            }

           
        }
    }
}
