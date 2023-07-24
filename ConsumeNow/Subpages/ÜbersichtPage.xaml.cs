using ConsumeNow.Database;
using ConsumeNow.Database.Data;
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
    /// Interaction logic for ÜbersichtPage.xaml
    /// </summary>
    public partial class ÜbersichtPage : UserControl
    {
        public ÜbersichtPage()
        {
            InitializeComponent();
        }

        public void WindowLoadedÜbersichtPage(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable dt4 = new System.Data.DataTable();

            string[] ColumnNames3 = { "Name", "Lagerort", "Zur Einkaufsliste hinzufügen \n wenn Menge kleiner als", "Änderung des MhD \n bei Öffnung", "Produkte"};

            foreach (string ColumnName in ColumnNames3)
            {
                dt4.Columns.Add(ColumnName, typeof(string));
            }
            
            foreach (var type in MainWindow.types)
            {
                string[] rowData = type.ToString().Split(',');
                Array.Resize(ref rowData,rowData.Length-1);
                //Array.Copy(rowData, 0, rowData, 0, rowData.Length - 1);
                dt4.Rows.Add(rowData);
            }

            DataView dv4 = new DataView(dt4);
            ÜbersichtDG.ItemsSource = dv4;
        }

        private void LöschenButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageDatabase.DeleteType(MainWindow.types, LöschenIDTB.Text.ToString());
                LöschenTL.Content = String.Empty;
                LöschenIDTB.Text = String.Empty;
                DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);
                MainWindow.übersichtpage.WindowLoadedÜbersichtPage(sender, e);
                LöschenTL.Visibility = Visibility.Collapsed;


            }
            catch
            {
                LöschenTL.Visibility = Visibility.Visible;
                LöschenTL.Content = "fehlgeschlagen!";
            }
        }
    }
}
