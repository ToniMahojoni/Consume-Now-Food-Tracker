using ConsumeNow.Database;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ConsumeNow
{
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

            //fill table columns
            foreach (string ColumnName in ColumnNames3)
            {
                dt4.Columns.Add(ColumnName, typeof(string));
            }
            
            //fill table rows 
            foreach (var type in MainWindow.types)
            {
                //show type data without the amount on shopping list 
                string[] rowData = type.ToString().Split(',');
                Array.Resize(ref rowData,rowData.Length-1);
                dt4.Rows.Add(rowData);
            }

            DataView dv4 = new DataView(dt4);
            ÜbersichtDG.ItemsSource = dv4;
        }

        private void LöschenButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //delete type from general type list
                ManageDatabase.DeleteType(MainWindow.types, LöschenIDTB.Text.ToString());

                //hide error message and clear Name input-field
                LöschenTL.Content = String.Empty;
                LöschenIDTB.Text = String.Empty;

                //save changes to the type file
                DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);
                MainWindow.übersichtpage.WindowLoadedÜbersichtPage(sender, e);

                //hide error message
                LöschenTL.Visibility = Visibility.Collapsed;


            }
            catch
            {
                //show error message
                LöschenTL.Visibility = Visibility.Visible;
                LöschenTL.Content = "fehlgeschlagen!";
            }
        }
    }
}
