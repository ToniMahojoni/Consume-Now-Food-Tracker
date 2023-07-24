﻿using System;
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
    public partial class KategorieAddPage : UserControl
    {
        public KategorieAddPage()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e) { 
            string[] TypeData = new string[6];
            TypeData[0] = NameTB.Text.ToString();
            TypeData[1] = LagerortTB.Text.ToString();
            TypeData[2] = EinkaufslisteHinzufügenTB.Text.ToString();
            TypeData[3] = ÄnderungMhDTB.Text.ToString();
            //TypeData[4] = "";
            /* List<string> names = new List<string>();
            
            foreach (System.Data.DataRowView row in ProduktTable.Items) {
                names.Add(row.Row.ItemArray[0].ToString());
            
            }
            string.Join(TypeData[4],names); */
            TypeData[4] = ProdukteTB.Text.ToString();
            TypeData[5] = "0";
            try {
                Database.ManageDatabase.AddType(TypeData,MainWindow.types);
                Database.DatabaseIO.SaveToDatabase<Database.Type>(MainWindow.types, MainWindow.typefilepath);
                NameTB.Text = string.Empty;
                LagerortTB.Text = string.Empty;
                EinkaufslisteHinzufügenTB.Text = string.Empty;
                ÄnderungMhDTB.Text = string.Empty;
                ProdukteTB.Text = string.Empty;
                SaveInfoBR.Visibility = Visibility.Visible;
                SaveInfoTL.Content = "erfolgreich!";
                SaveInfoTL.Foreground = Brushes.Green;
            } catch {
                SaveInfoBR.Visibility = Visibility.Visible;
                SaveInfoTL.Content = "fehlgeschlagen!";
                SaveInfoTL.Foreground = Brushes.Red;
            }
            //Database.DatabaseIO.SaveToDatabase<Entry>(MainWindow.entries, "./Database/Data/ExampleEntries.csv");
            
        }

    }
}