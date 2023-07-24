using ConsumeNow.Database;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ConsumeNow
{
    public partial class EinkaufslistePage : UserControl
    {
        public EinkaufslistePage()
        {
            InitializeComponent();
        }

        public void WindowLoadedEinkaufslistePage(object sender, RoutedEventArgs e)
        {
            //fills the table with the data from the shopping list file
            System.Data.DataTable dt3 = new System.Data.DataTable();

            string[] ColumnNames3 = { "Menge", "Typ"};

            //creation of the columns
            foreach (string ColumnName in ColumnNames3)
            {
                dt3.Columns.Add(ColumnName, typeof(string));
            }
            
            //creation of the rows
            foreach(var rowData in Database.ShoppingList.GetShoppingList(MainWindow.types))
            {
                dt3.Rows.Add(rowData.Split(' '));
            }

            DataView dv3 = new DataView(dt3);
            EinkaufslisteDG.ItemsSource = dv3;
        }

        private void GenerierenButtonClick(object sender, RoutedEventArgs e)
        {
            //clear current list, generate and reload page
            ShoppingList.ClearShoppingList(MainWindow.types);
            ShoppingList.GenerateShoppingList(MainWindow.entries, MainWindow.types);
            WindowLoadedEinkaufslistePage(sender, e);
        }

        private void LöschenButtonClick(object sender, RoutedEventArgs e)
        {
            //clear shopping list and reload page
            ShoppingList.ClearShoppingList(MainWindow.types);
            WindowLoadedEinkaufslistePage(sender, e);
        }
    }
}
