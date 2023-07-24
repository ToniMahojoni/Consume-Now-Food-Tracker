using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConsumeNow.Subpages
{
    public partial class EinkaufslisteAddPage : UserControl
    {
        public EinkaufslisteAddPage()
        {
            InitializeComponent();
        }

        private void WindowLoadedEinkaufslisteAddPage(object sender, RoutedEventArgs e)
        {
            fillComboBox();
        }

        //SaveButtonClick
        private void SaveButtonClick(object sender, RoutedEventArgs e) 
        {
            try
            {
                //avoid empty ComboBox
                if (TypCB.SelectedItem != null)
                {
                    //pick the type-instance from the selected type 
                    var SelectedType =
                            from type in MainWindow.types
                            where type.Name == TypCB.SelectedItem.ToString()
                            select type;

                    foreach (var type in SelectedType)
                    {   //adds a certain amount of the selected type to the shopping list
                        type.AddToShoppingList(Convert.ToUInt32(MengeTB.Text));
                    }
                    //save changes to file
                    Database.DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);
                    SuccessfullSave(sender, e);
                    //reload page to make the changes visible
                    MainWindow.einkaufslistepage.WindowLoadedEinkaufslistePage(sender, e);
                    
                }
            }
            catch
            {
                //show fehlgeschlagen message
                SaveInfoTL.Content = "fehlgeschlagen!";
                SaveInfoTL.Foreground = Brushes.Red;
                SaveInfoBR.Visibility = Visibility.Visible;
            }
        }

        private void SuccessfullSave(object sender, RoutedEventArgs e)
        {
            //reset input-fields and show save message
            TypCB.SelectedItem = null;
            MengeTB.Text = string.Empty;
            SaveInfoTL.Content = "gespeichert!";
            SaveInfoTL.Foreground = Brushes.Green;
            SaveInfoBR.Visibility = Visibility.Visible;

        }

        public void EinkaufslisteAddReset()
        {
            //clear input-fields and hide save message
            TypCB.SelectedItem = null;
            MengeTB.Text = string.Empty;
            SaveInfoBR.Visibility = Visibility.Collapsed;
        }

        private void fillComboBox()
        {
            foreach(var type in MainWindow.types)
            {
                //fill the ComboBox with all possible types
                TypCB.Items.Add(type.Name);
            }
        }
    }
}
