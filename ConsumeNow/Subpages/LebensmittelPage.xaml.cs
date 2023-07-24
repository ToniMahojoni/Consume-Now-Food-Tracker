using ConsumeNow.Database;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ConsumeNow
{
    public partial class LebensmittelPage : UserControl
    {
        public LebensmittelPage()
        {
            InitializeComponent();
        }
 
        public void WindowLoadedLebensmittelPage(object sender, RoutedEventArgs e)
        {    
            DataTable dt1 = new DataTable();

            string[] ColumnNames1 = { "ID", "Typ", "Name", "Mindesthaltbarkeitsdatum", "Kaufdatum", "Menge", "Preis", "geöffnet", "verbleibend" };

            //fill the columns of the table
            foreach (string ColumnName in ColumnNames1)
            {
                dt1.Columns.Add(ColumnName, typeof(string));
            }
           
            //fill the rows of table with each entry from the general entries list
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

        private void LöschenButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //delete entry from general entries list and 
                ManageDatabase.DeleteEntry(MainWindow.entries, Convert.ToUInt32(LöschenIDTB.Text.ToString()));

                //hide failed message and clear ID input-field
                LöschenTL.Content = String.Empty;
                LöschenIDTB.Text = String.Empty;

                //save changes to entries file
                DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, MainWindow.entryfilepath);

                //reload LebensmittelPage
                WindowLoadedLebensmittelPage(sender, e);
            }
            catch
            {
                //show failed message
                LöschenTL.Content = "fehlgeschlagen!";
            }
        }
    }
}
