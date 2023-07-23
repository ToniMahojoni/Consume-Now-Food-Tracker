using ConsumeNow.Database;
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
    /// Interaction logic for LebensmittelAddPage.xaml
    /// </summary>
    public partial class LebensmittelAddPage : UserControl
    {
        public LebensmittelAddPage()
        {
            InitializeComponent();
        }

        private void OpenableChecked(object sender, RoutedEventArgs e)
        {
            if (OpenableChecked != null)
            {
                
                CheckBox box = sender as CheckBox;

                if (box != null)
                {
                    if (box.IsChecked == true)
                    {
                        geöffnettextborder.Visibility = Visibility.Visible;
                        verbleibendtextboder.Visibility = Visibility.Visible;
                        openedCB.Visibility = Visibility.Visible;
                        verbleibendTB.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        geöffnettextborder.Visibility = Visibility.Collapsed;
                        verbleibendtextboder.Visibility = Visibility.Collapsed;
                        openedCB.Visibility = Visibility.Collapsed;
                        verbleibendTB.Visibility = Visibility.Collapsed;
                    }
                }
                

                
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var element in MainWindow.types)
            {
                TypCB.Items.Add(element.Name);
            }
        }




        private void SuccessfullSave()
        {
            TypCB.SelectedItem = null;
            NameCB.SelectedItem = null;
            HaltbarkeitTB.Text = string.Empty;
            KaufdatumTB.Text = string.Empty;
            MengeTB.Text = string.Empty;
            PreisTB.Text = string.Empty;
            openedCB.IsChecked = false;
            openableCB.IsChecked = false;
            verbleibendTB.Text = string.Empty;

            SaveInfoBorder.Visibility = Visibility.Visible;
            SaveInfo.Content = "gespeichert!";
            SaveInfo.Foreground = Brushes.Green;

            DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, "../../../Database/Data/ExampleEntries.csv");

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            string[] EntryData;
            if (openableCB.IsChecked == true)
            {
                EntryData = new string[8];
            }
            else
            {
                EntryData = new string[6];
            }

            if (TypCB.SelectedItem != null)
            {
                EntryData[0] = TypCB.SelectedItem.ToString();

                if (NameCB.SelectedItem == null)
                {
                    EntryData[1] = TypCB.SelectedItem.ToString();
                }
                else
                {
                    EntryData[1] = NameCB.SelectedItem.ToString();
                }

                EntryData[2] = HaltbarkeitTB.Text.ToString();

                if (KaufdatumTB.Text == string.Empty)
                {
                    EntryData[3] = DateOnly.FromDateTime(DateTime.Today).ToString();
                }
                else
                {
                    EntryData[3] = KaufdatumTB.Text.ToString();
                }


                EntryData[4] = MengeTB.Text.ToString();
                EntryData[5] = PreisTB.Text.ToString();
            }



            if (EntryData.Length == 8)
            {
                EntryData[6] = openedCB.IsChecked.ToString();
                EntryData[7] = verbleibendTB.Text.ToString();
            }

            try
            {
                ManageDatabase.AddEntry(EntryData, MainWindow.entries);
                SuccessfullSave();
            }
            catch
            {
                SaveInfoBorder.Visibility = Visibility.Visible;
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Foreground = Brushes.Red;
            }

            OpenableChecked(sender, e);

            MainWindow.lebensmittelpage.Window_Loaded_LebensmittelPage(sender, e);


        }

        private void BESTÄTIGENButtonClick(object sender, RoutedEventArgs e)
        {
            if (TypCB.SelectedItem != null)
            {
                NameCB.Visibility = Visibility.Visible;
                HaltbarkeitTB.Visibility = Visibility.Visible;
                KaufdatumTB.Visibility = Visibility.Visible;
                MengeTB.Visibility = Visibility.Visible;
                PreisTB.Visibility = Visibility.Visible;
                openableCB.Visibility = Visibility.Visible;

                NameTL.Visibility = Visibility.Visible;
                HaltbarkeitTL.Visibility = Visibility.Visible;
                KaufdatumTL.Visibility = Visibility.Visible;
                MengeTL.Visibility = Visibility.Visible;
                PreisTL.Visibility = Visibility.Visible;
                openableTL.Visibility = Visibility.Visible;

                SpeichernButton.Visibility = Visibility.Visible;

                TypCB.IsEnabled = false;
                BestätigenButton.Visibility = Visibility.Collapsed;

                var SelectedSubnames = 
                    from type in MainWindow.types
                    where type.Name == TypCB.SelectedItem.ToString() 
                    select type.Subnames;

                foreach( var subnames in SelectedSubnames )
                {
                    foreach (string subname in subnames)
                    {
                        NameCB.Items.Add(subname);
                    }
                }
            }




        }
    }
}
    

        


