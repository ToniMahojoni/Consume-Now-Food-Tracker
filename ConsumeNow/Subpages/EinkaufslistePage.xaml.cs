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
    /// Interaction logic for EinkaufslistePage.xaml
    /// </summary>
    public partial class EinkaufslistePage : UserControl
    {
        public EinkaufslistePage()
        {
            InitializeComponent();
        }

        public void Window_Loaded_EinkaufslistePage(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();

            string[] ColumnNames2 = { "Typ", "Menge" };

            foreach (string ColumnName in ColumnNames2)
            {
                dt2.Columns.Add(ColumnName, typeof(string));
            }

            DataView dv2 = new DataView(dt2);
            EinkaufslisteTable.ItemsSource = dv2;
        }

    }
}
