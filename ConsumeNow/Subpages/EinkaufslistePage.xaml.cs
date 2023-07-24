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
    public partial class EinkaufslistePage : UserControl
    {
        public EinkaufslistePage()
        {
            InitializeComponent();
        }

        public void WindowLoadedEinkaufslistePage(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();

            string[] ColumnNames3 = { "Menge", "Typ"};

            foreach (string ColumnName in ColumnNames3)
            {
                dt3.Columns.Add(ColumnName, typeof(string));
            }
            foreach(var rowData in ShoppingList.GetShoppingList(MainWindow.types))
            {
                dt3.Rows.Add(rowData.Split(' '));
            }

            DataView dv3 = new DataView(dt3);
            EinkaufslisteDG.ItemsSource = dv3;
        }

    }
}
