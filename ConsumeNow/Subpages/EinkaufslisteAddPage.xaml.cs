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
    /// Interaction logic for EinkaufslisteAddPage.xaml
    /// </summary>
    public partial class EinkaufslisteAddPage : UserControl
    {
        public EinkaufslisteAddPage()
        {
            InitializeComponent();
        }

        private void SaveButton(object sender, RoutedEventArgs e) 
        {
            try
            {
                if (TypCB.SelectedItem != null)
                {
                    var SelectedType =
                            from type in MainWindow.types
                            where type.Name == TypCB.SelectedItem.ToString()
                            select type;

                    foreach (var type in SelectedType)
                    {
                        type.AddToShoppingList(Convert.ToUInt32(MengeTB.Text));
                    }
                    Database.DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);
                    SuccessfullSave(sender, e);
                    MainWindow.einkaufslistepage.WindowLoadedEinkaufslistePage(sender, e);
                    
                }
                
                
            }
            catch
            {
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Foreground = Brushes.Red;
                SaveInfoBorder.Visibility = Visibility.Visible;
            }
            

            
        }

        private void SuccessfullSave(object sender, RoutedEventArgs e)
        {
            TypCB.SelectedItem = null;
            MengeTB.Text = string.Empty;
            SaveInfo.Content = "gespeichert!";
            SaveInfo.Foreground = Brushes.Green;
            SaveInfoBorder.Visibility = Visibility.Visible;

        }

        public void EinkaufslisteAddReset()
        {
            TypCB.SelectedItem = null;
            MengeTB.Text = string.Empty;
            SaveInfoBorder.Visibility = Visibility.Collapsed;
        }

        private void fillComboBox()
        {
            foreach(var type in MainWindow.types)
            {
                TypCB.Items.Add(type.Name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillComboBox();
        }

    }
}
