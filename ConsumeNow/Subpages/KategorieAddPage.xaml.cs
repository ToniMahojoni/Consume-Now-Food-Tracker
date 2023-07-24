using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConsumeNow.Subpages
{
    public partial class KategorieAddPage : UserControl
    {
        public KategorieAddPage()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e) { 
            string[] TypeData = new string[6];

            //fill the TypeData array with the data from the input-fields
            TypeData[0] = NameTB.Text.ToString();
            TypeData[1] = LagerortTB.Text.ToString();
            TypeData[2] = EinkaufslisteHinzufügenTB.Text.ToString();
            TypeData[3] = ÄnderungMhDTB.Text.ToString();
            TypeData[4] = ProdukteTB.Text.ToString();
            TypeData[5] = "0";

            try {

                //add the data to the general types array
                Database.ManageDatabase.AddType(TypeData,MainWindow.types);
                //save the changes to the file
                Database.DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);

                //clear input-fields and show successful message
                NameTB.Text = string.Empty;
                LagerortTB.Text = string.Empty;
                EinkaufslisteHinzufügenTB.Text = string.Empty;
                ÄnderungMhDTB.Text = string.Empty;
                ProdukteTB.Text = string.Empty;
                SaveInfoBR.Visibility = Visibility.Visible;
                SaveInfoTL.Content = "erfolgreich!";
                SaveInfoTL.Foreground = Brushes.Green;
            } catch {

                //show failed message
                SaveInfoBR.Visibility = Visibility.Visible;
                SaveInfoTL.Content = "fehlgeschlagen!";
                SaveInfoTL.Foreground = Brushes.Red;
            }
        }
    }
}
