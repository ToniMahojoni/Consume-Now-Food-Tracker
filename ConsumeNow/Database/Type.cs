using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
    public class Type //represents a row in ÜbersichtPage
    {
        public Type(string Name, string StoreLocation, double? WhenToAddToShoppingList, int? BestBeforeDateChange, string[] Subnames, uint AmountOnShoppinglist)
        {
            this.Name = Name;
            this.StoreLocation = StoreLocation;
            this.WhenToAddToShoppingList = WhenToAddToShoppingList;
            this.BestBeforeDateChange = BestBeforeDateChange;
            this.Subnames = Subnames;
            this.AmountOnShoppinglist = AmountOnShoppinglist;
        }
        public string Name { get; private set; }
        public string StoreLocation { get; private set; } //the location where product is usually stored
        public double? WhenToAddToShoppingList { get; private set; } //represents at which remaining amount the produkt will automatically added to the shopping list
        public int? BestBeforeDateChange { get; private set; } //when the product changes to opened, the best before date will be set to today in BestBeforeDateChange days
        public string[] Subnames { get; private set; } //choose Names that can be shown for a specific product from this type
        public uint AmountOnShoppinglist { get; private set; } //represents how many of this type is on the shopping list, 0 means its not on the shopping list
        private string PrintSubnames()
        {
            string result = "";
            for (int i = 0; i < Subnames.Length; i++)
            {
                result += Subnames[i];
                if (i < Subnames.Length - 1) result += ";";
            }
            return result;
        }
        public override string ToString()
        {
            return Name + "," + StoreLocation + "," + Convert.ToString(WhenToAddToShoppingList, System.Globalization.CultureInfo.InvariantCulture) + "," +
                Convert.ToString(BestBeforeDateChange) + "," + PrintSubnames() + "," + Convert.ToString(AmountOnShoppinglist);
        }
        public void SetValues(string Name, string StoreLocation, double? WhenToAddToShoppingList, int? BestBeforeDateChange, string[] Subnames)
        {
            this.Name = Name;
            this.StoreLocation = StoreLocation;
            this.WhenToAddToShoppingList = WhenToAddToShoppingList;
            this.BestBeforeDateChange = BestBeforeDateChange;
            this.Subnames = Subnames;
        }
        public void AddToShoppingList(uint Amount)
        {
            this.AmountOnShoppinglist += Amount;
        }
        public void RemoveFromShoppingList()
        {
            this.AmountOnShoppinglist = 0;
        }
    }
}
