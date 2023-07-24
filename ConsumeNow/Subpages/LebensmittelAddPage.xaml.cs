using ConsumeNow.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ConsumeNow.Subpages
{
    public partial class LebensmittelAddPage : UserControl
    {
        public LebensmittelAddPage()
        {
            InitializeComponent();
        }

        //boolean that represents the mode
        //false == add mode
        //true == edit mode
        private bool mode = false;

        private void WindowLoadedLebensmittelAddPage(object sender, RoutedEventArgs e)
        {
            fillTypComboBox();
        }

        private void OpenableChecked(object sender, RoutedEventArgs e)
        {

                if (openableCB != null)
                {
                    if (openableCB.IsChecked == true)
                    {
                        //show the further options for openable food
                        geöffnetTL.Visibility = Visibility.Visible;
                        verbleibendTL.Visibility = Visibility.Visible;
                        openedCB.Visibility = Visibility.Visible;
                        verbleibendTB.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        //hide the further options for unopenable food
                        geöffnetTL.Visibility = Visibility.Collapsed;
                        verbleibendTL.Visibility = Visibility.Collapsed;
                        openedCB.Visibility = Visibility.Collapsed;
                        verbleibendTB.Visibility = Visibility.Collapsed;
                    }
                }
        }

        private void EmptyData()
        {
            //clear all input-fields
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

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            
            string[] EntryData;
            if (openableCB.IsChecked == true)
            {
                //if food is openable, it gets saved as AdvancedEntry
                //array length is 8 in this case
                EntryData = new string[8];
            }
            else
            {
                //if food is unopenable, it gets saved as Entry
                //array length is 6 in this case
                EntryData = new string[6];
            }

            if (TypCB.SelectedItem != null)
            {
                //inserted data from the input-fields is getting written in the EntryData array
                EntryData[0] = TypCB.SelectedItem.ToString();

                if (NameCB.SelectedItem == null)
                {
                    //when there is no name selected, the name is set to the type
                    EntryData[1] = TypCB.SelectedItem.ToString();
                }
                else
                {
                    EntryData[1] = NameCB.SelectedItem.ToString();
                }

                EntryData[2] = HaltbarkeitTB.Text.ToString();

                if (KaufdatumTB.Text == string.Empty)
                {
                    //if there is no buy date selected, the current date is set as buy date
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
                //additional data for the AdvancedEntries
                EntryData[6] = openedCB.IsChecked.ToString();
                EntryData[7] = verbleibendTB.Text.ToString();
            }


            try
            {
                if (mode)
                {
                    //editing mode
                    //saving changes the general entries list
                    ManageDatabase.EditEntry(EntryData, MainWindow.entries,
                        Convert.ToUInt32(IDTB.Text.ToString()));
                    //clear ID TextBox
                    IDTB.Text = String.Empty;
                }
                else
                {
                    //saving as a new entry
                    ManageDatabase.AddEntry(EntryData, MainWindow.entries);
                }
                DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, MainWindow.entryfilepath);
                SuccessfullSave(sender, e);
            }
            catch
            {
                //show failed message
                SaveInfoTL.Visibility = Visibility.Visible;
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Foreground = Brushes.Red;
            }
        }

        private void BestätigenButtonClick(object sender, RoutedEventArgs e)
        {
            if (TypCB.SelectedItem != null)
            {
                //show all input-fields
                NameCB.Visibility = Visibility.Visible;
                HaltbarkeitTB.Visibility = Visibility.Visible;
                KaufdatumTB.Visibility = Visibility.Visible;
                MengeTB.Visibility = Visibility.Visible;
                PreisTB.Visibility = Visibility.Visible;
                openableCB.Visibility = Visibility.Visible;

                //show all TextLabels
                NameTL.Visibility = Visibility.Visible;
                HaltbarkeitTL.Visibility = Visibility.Visible;
                KaufdatumTL.Visibility = Visibility.Visible;
                MengeTL.Visibility = Visibility.Visible;
                PreisTL.Visibility = Visibility.Visible;
                openableTL.Visibility = Visibility.Visible;

                //show save button and hide edit button and ID input-field
                SpeichernButton.Visibility = Visibility.Visible;
                EditierenButton.Visibility = Visibility.Collapsed;
                IDTB.Visibility = Visibility.Collapsed;
                IDTL.Visibility = Visibility.Collapsed;
                EditierenTL.Visibility = Visibility.Collapsed;

                //disable Typ CheckBox after selecting the type
                TypCB.IsEnabled = false;

                //hide confirm button and save info TextLabel
                BestätigenButton.Visibility = Visibility.Collapsed;
                SaveInfoTL.Visibility = Visibility.Collapsed;

                //mode is set to editing mode
                mode = false;

                fillNameComboBox();
            }
        }

        private void EditierenButtonClick(object sender, RoutedEventArgs e)
        {
            //hide save info TextLabel
            SaveInfoTL.Visibility = Visibility.Collapsed;
            
            try
            {
            //load data from the entry with the selected ID
            LoadEditData(Convert.ToUInt32(IDTB.Text.ToString()), sender, e);

            //show and enable all input-fields
            TypCB.Visibility = Visibility.Visible;
            TypCB.IsEnabled = true;
            NameCB.Visibility = Visibility.Visible;
            HaltbarkeitTB.Visibility = Visibility.Visible;
            KaufdatumTB.Visibility = Visibility.Visible;
            MengeTB.Visibility = Visibility.Visible;
            PreisTB.Visibility = Visibility.Visible;
            openableCB.Visibility = Visibility.Visible;

            //show all TextLabels
            NameTL.Visibility = Visibility.Visible;
            HaltbarkeitTL.Visibility = Visibility.Visible;
            KaufdatumTL.Visibility = Visibility.Visible;
            MengeTL.Visibility = Visibility.Visible;
            PreisTL.Visibility = Visibility.Visible;
            openableTL.Visibility = Visibility.Visible;

            //show save button and hide other buttons and ID input-field
            SpeichernButton.Visibility = Visibility.Visible;
            IDTB.Visibility = Visibility.Collapsed;
            IDTL.Visibility = Visibility.Collapsed;
            EditierenTL.Visibility = Visibility.Collapsed;
            BestätigenButton.Visibility = Visibility.Collapsed;
            EditierenButton.Visibility = Visibility.Collapsed;

            //hide add TextLabel in the top left corner
            hinzufügenTL.Visibility = Visibility.Collapsed;

            fillNameComboBox();
            }
            catch
            {
                //show failed message
                SaveInfo.Content = "fehlgeschlagen!";
                SaveInfo.Visibility = Visibility.Visible;
                SaveInfoTL.Visibility = Visibility.Visible;
                SaveInfo.Foreground = Brushes.Red;
            }
            
            //mode is set to edit mode
            mode = true;
        }

        private void SuccessfullSave(object sender, RoutedEventArgs e)
        {
            EmptyData();

            //show saved message
            SaveInfoTL.Visibility = Visibility.Visible;
            SaveInfo.Content = "gespeichert!";
            SaveInfo.Foreground = Brushes.Green;

            //create standard configuration for openable CheckBox
            OpenableChecked(sender, e);

            //clear all input-fields
            LebensmittelAddReset();

            //reload LebensmittelPage to make the changes visible
            MainWindow.lebensmittelpage.WindowLoadedLebensmittelPage(sender, e);

            //hide save button
            SpeichernButton.Visibility = Visibility.Collapsed;
        }

        private void fillNameComboBox()
        {
            //pick type with selected name
            var SelectedSubnames =
                    from type in MainWindow.types
                    where type.Name == TypCB.SelectedItem.ToString()
                    select type.Subnames;

            //fill all type names into the subnames ComboBox
            foreach (var subnames in SelectedSubnames)
            {
                foreach (string subname in subnames)
                {
                    NameCB.Items.Add(subname);
                }
            }
        }

        private void fillTypComboBox()
        {
            //fill the type ComboBox with all types from the general type list
            foreach (var element in MainWindow.types)
            {
                TypCB.Items.Add(element.Name);
            }
        }

        public void LebensmittelAddReset()
        {
            //clear the data on the input-fields
            EmptyData();

            //show the add TextLabel at the top left corner
            //and hide all other input-fields
            hinzufügenTL.Visibility = Visibility.Visible;
            NameCB.Visibility = Visibility.Collapsed;
            HaltbarkeitTB.Visibility = Visibility.Collapsed;
            KaufdatumTB.Visibility = Visibility.Collapsed;
            MengeTB.Visibility = Visibility.Collapsed;
            PreisTB.Visibility = Visibility.Collapsed;
            openableCB.Visibility = Visibility.Collapsed;
            openedCB.Visibility = Visibility.Collapsed;
            geöffnetTL.Visibility = Visibility.Collapsed;
            verbleibendTB.Visibility = Visibility.Collapsed;
            verbleibendTL.Visibility = Visibility.Collapsed;

            //hide all TextLabels
            NameTL.Visibility = Visibility.Collapsed;
            HaltbarkeitTL.Visibility = Visibility.Collapsed;
            KaufdatumTL.Visibility = Visibility.Collapsed;
            MengeTL.Visibility = Visibility.Collapsed;
            PreisTL.Visibility = Visibility.Collapsed;
            openableTL.Visibility = Visibility.Collapsed;
            
            //hide save button and show all other buttons and ID input-field
            SpeichernButton.Visibility = Visibility.Collapsed;
            EditierenButton.Visibility = Visibility.Visible;
            IDTB.Visibility = Visibility.Visible;
            IDTL.Visibility = Visibility.Visible;
            EditierenTL.Visibility = Visibility.Visible;

            //enable type CheckBox and show confirm button
            TypCB.IsEnabled = true;
            BestätigenButton.Visibility = Visibility.Visible;
            
        }

        private void LoadEditData(uint ID, object sender, RoutedEventArgs e)
        {
            //select entry with the inserted ID
            var entry = ManageDatabase.SelectEntry(MainWindow.entries, ID);

            //fill the TextBoxes with the entry data
            NameCB.SelectedItem = entry.Name;
            TypCB.SelectedItem = entry.Type;
            HaltbarkeitTB.Text = entry.BestBeforeDate.ToString();
            KaufdatumTB.Text = entry.BuyDate.ToString();
            MengeTB.Text = entry.Amount.ToString();
            PreisTB.Text = Convert.ToString(entry.Prize,System.Globalization.CultureInfo.InvariantCulture);
            openableCB.IsChecked = entry is AdvancedEntry;
            if (entry is AdvancedEntry)
            {
                //data of the AdvancedEntry
                openedCB.IsChecked = (entry as AdvancedEntry).IsOpened;
                verbleibendTB.Text = Convert.ToString((entry as AdvancedEntry).RemainingAmount, System.Globalization.CultureInfo.InvariantCulture);
            }
            //check if entry is openable and then display the neccessary TextBoxes and input-fields
            OpenableChecked(sender, e);
        }
    }
}
    

        


