using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
    public class Type
    {
        public Type(string Name, string StoreLocation, double? WhenToAddToShoppingList, int? BestBeforeDateChange, string[] Subnames, uint AmountOnShoppinglist)
        {
            this.ID = NextID++;
            this.Name = Name;
            this.StoreLocation = StoreLocation;
            this.WhenToAddToShoppingList = WhenToAddToShoppingList;
            this.BestBeforeDateChange = BestBeforeDateChange;
            this.Subnames = Subnames;
            this.AmountOnShoppinglist = AmountOnShoppinglist;
        }
        public uint ID { get; }
        private static uint NextID = 0;
        public string Name { get; private set; }
        public string StoreLocation { get; private set; }
        public double? WhenToAddToShoppingList { get; private set; }
        public int? BestBeforeDateChange { get; private set; }
        public string[] Subnames { get; private set; }
        public uint AmountOnShoppinglist { get; private set; }
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
        public void SetValues(string Name, string StoreLocation, double? WhenToAddToShoppingList, int? BestBeforeDateChange, string[] Subnames, uint AmountOnShoppinglist)
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
