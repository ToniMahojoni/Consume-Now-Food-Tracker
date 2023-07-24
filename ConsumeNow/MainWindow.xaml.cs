using ConsumeNow.Database;
using ConsumeNow.Subpages;
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

namespace ConsumeNow
{
    
    public partial class MainWindow : Window
    {
        public const string entryfilepath = "./../../../Database/Data/ExampleEntries.csv";
        public const string typefilepath = "./../../../Database/Data/ExampleTypes.csv";

        //public const string entryfilepath = "./Database/Data/ExampleEntries.csv";
        //public const string typefilepath = "./Database/Data/ExampleTypes.csv";

        public MainWindow()
        {
            InitializeComponent();
        }

        public static LebensmittelPage lebensmittelpage = new LebensmittelPage();
        public static EinkaufslistePage einkaufslistepage = new EinkaufslistePage();
        public static ÜbersichtPage übersichtpage = new ÜbersichtPage();

        LebensmittelAddPage lebensmitteladdpage = new LebensmittelAddPage();
        EinkaufslisteAddPage einkaufslisteaddpage = new EinkaufslisteAddPage();
        KategorieAddPage kategorieaddpage = new KategorieAddPage();

        public static List<Entry> entries = DatabaseIO.LoadFromEntryDatabase(entryfilepath);
        public static List<ConsumeNow.Database.Type> types = DatabaseIO.LoadFromTypeDatabase(typefilepath);

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            string senderName = (sender as Button).Name;
            switch (senderName)
            {
                case "LebensmittelButton":
                    SubpageCC.Content = lebensmittelpage;
                    lebensmitteladdpage.LebensmittelAddReset(); 
                    break;
                case "EinkaufslisteButton":
                    SubpageCC.Content = einkaufslistepage;
                    lebensmitteladdpage.LebensmittelAddReset();
                    break;
                case "ÜbersichtButton":
                    SubpageCC.Content = übersichtpage;
                    lebensmitteladdpage.LebensmittelAddReset();
                    break;
                case "AddLebensmittelButton":
                    SubpageCC.Content = lebensmitteladdpage;
                    lebensmitteladdpage.SaveInfoTL.Visibility = Visibility.Collapsed;
                    break;
                case "AddEinkaufButton":
                    SubpageCC.Content = einkaufslisteaddpage;
                    lebensmitteladdpage.LebensmittelAddReset();
                    einkaufslisteaddpage.EinkaufslisteAddReset();
                    break;
                case "AddTypButton":
                    SubpageCC.Content = kategorieaddpage;
                    lebensmitteladdpage.LebensmittelAddReset();   
                    break;
                default: break;
            }

        }
    }
}
