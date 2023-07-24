using ConsumeNow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private bool mode = false;

        private void OpenableChecked(object sender, RoutedEventArgs e)
        {

                if (openableCB != null)
                {
                    if (openableCB.IsChecked == true)
                    {
                        geöffnettextborder.Visibility = Visibility.Visible;
                        verbleibendtextborder.Visibility = Visibility.Visible;
                        openedCB.Visibility = Visibility.Visible;
                        verbleibendTB.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        geöffnettextborder.Visibility = Visibility.Collapsed;
                        verbleibendtextborder.Visibility = Visibility.Collapsed;
                        openedCB.Visibility = Visibility.Collapsed;
                        verbleibendTB.Visibility = Visibility.Collapsed;
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


        private void EmptyData()
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
        }

        private void SuccessfullSave(object sender, RoutedEventArgs e)
        {
            EmptyData();

            SaveInfoBorder.Visibility = Visibility.Visible;
            SaveInfo.Content = "gespeichert!";
            SaveInfo.Foreground = Brushes.Green;

            OpenableChecked(sender, e);

            LebensmittelAddReset();

            MainWindow.lebensmittelpage.Window_Loaded_LebensmittelPage(sender, e);

            SpeichernButton.Visibility = Visibility.Collapsed;

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
                if (mode)
                {
                    ManageDatabase.EditEntry(EntryData, MainWindow.entries, MainWindow.types,
                        Convert.ToUInt32(IDTB.Text.ToString()));
                    IDTB.Text = String.Empty;
                }
                else
                {
                    ManageDatabase.AddEntry(EntryData, MainWindow.entries);
                    
                }
                DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, MainWindow.entryfilepath);
                SuccessfullSave(sender, e);
            }
            catch
            {
                SaveInfoBorder.Visibility = Visibility.Visible;
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Foreground = Brushes.Red;
            }
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
                EditierenButton.Visibility = Visibility.Collapsed;
                IDTB.Visibility = Visibility.Collapsed;
                IDTL.Visibility = Visibility.Collapsed;
                editierenLabel.Visibility = Visibility.Collapsed;

                TypCB.IsEnabled = false;
                BestätigenButton.Visibility = Visibility.Collapsed;
                SaveInfoBorder.Visibility = Visibility.Collapsed;

                mode = false;

                fillComboBox();

            }
        }

        private void fillComboBox()
        {
            var SelectedSubnames =
                    from type in MainWindow.types
                    where type.Name == TypCB.SelectedItem.ToString()
                    select type.Subnames;

            foreach (var subnames in SelectedSubnames)
            {
                foreach (string subname in subnames)
                {
                    NameCB.Items.Add(subname);
                }
            }
        }

        public void LebensmittelAddReset()
        {
            EmptyData();

            hinzufügenLabel.Visibility = Visibility.Visible;
            NameCB.Visibility = Visibility.Collapsed;
            HaltbarkeitTB.Visibility = Visibility.Collapsed;
            KaufdatumTB.Visibility = Visibility.Collapsed;
            MengeTB.Visibility = Visibility.Collapsed;
            PreisTB.Visibility = Visibility.Collapsed;
            openableCB.Visibility = Visibility.Collapsed;
            openedCB.Visibility = Visibility.Collapsed;
            geöffnettextborder.Visibility = Visibility.Collapsed;
            verbleibendTB.Visibility = Visibility.Collapsed;
            verbleibendtextborder.Visibility = Visibility.Collapsed;



            NameTL.Visibility = Visibility.Collapsed;
            HaltbarkeitTL.Visibility = Visibility.Collapsed;
            KaufdatumTL.Visibility = Visibility.Collapsed;
            MengeTL.Visibility = Visibility.Collapsed;
            PreisTL.Visibility = Visibility.Collapsed;
            openableTL.Visibility = Visibility.Collapsed;
            

            SpeichernButton.Visibility = Visibility.Collapsed;
            EditierenButton.Visibility = Visibility.Visible;
            IDTB.Visibility = Visibility.Visible;
            IDTL.Visibility = Visibility.Visible;
            editierenLabel.Visibility = Visibility.Visible;

            TypCB.IsEnabled = true;
            BestätigenButton.Visibility = Visibility.Visible;
            
        }

        private void EditierenButtonClick(object sender, RoutedEventArgs e)
        {
            SaveInfoBorder.Visibility = Visibility.Collapsed;
            
            try
            {
            LoadEditData(Convert.ToUInt32(IDTB.Text.ToString()), sender, e);
            TypCB.Visibility = Visibility.Visible;
            TypCB.IsEnabled = true;
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
            IDTB.Visibility = Visibility.Collapsed;
            IDTL.Visibility = Visibility.Collapsed;
            editierenLabel.Visibility = Visibility.Collapsed;
            BestätigenButton.Visibility = Visibility.Collapsed;
            EditierenButton.Visibility = Visibility.Collapsed;

            hinzufügenLabel.Visibility = Visibility.Collapsed;
            fillComboBox();
            }
            catch
            {
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Visibility = Visibility.Visible;
                SaveInfoBorder.Visibility = Visibility.Visible;
                SaveInfo.Foreground = Brushes.Red;
            }
            

            mode = true;
        }

        private void LoadEditData(uint ID, object sender, RoutedEventArgs e)
        {
            var entry = ManageDatabase.SelectEntry(MainWindow.entries, ID);

            NameCB.SelectedItem = entry.Name;
            TypCB.SelectedItem = entry.Type;
            HaltbarkeitTB.Text = entry.BestBeforeDate.ToString();
            KaufdatumTB.Text = entry.BuyDate.ToString();
            MengeTB.Text = entry.Amount.ToString();
            PreisTB.Text = Convert.ToString(entry.Prize,System.Globalization.CultureInfo.InvariantCulture);
            openableCB.IsChecked = entry is AdvancedEntry;
            if (entry is AdvancedEntry)
            {
                openedCB.IsChecked = (entry as AdvancedEntry).IsOpened;
                verbleibendTB.Text = Convert.ToString((entry as AdvancedEntry).RemainingAmount, System.Globalization.CultureInfo.InvariantCulture);
            }
            OpenableChecked(sender, e);
        }
    }
}
    

        


