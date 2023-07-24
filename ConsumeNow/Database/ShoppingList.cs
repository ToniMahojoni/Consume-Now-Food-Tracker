using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
    public static class ShoppingList
    {
        public static List<string> GetShoppingList(List<Type> types) // for printing the shopping list
        {
            List<string> result = new List<string>();
            foreach (Type type in types)
            {
                if (type.AmountOnShoppinglist > 0)
                {
                    result.Add(Convert.ToString(type.AmountOnShoppinglist) + " " + type.Name);
                }
            }
            return result;
        }
        public static void GenerateShoppingList(List<Entry> entries, List<Type> types) // automatically generate shopping list according to the data from Type list when to add to the shopping list
        {
            foreach (Type type in types)
            {
                double count = 0;
                var EntrySelection =
                    from entry in entries
                    where type.Name == entry.Type
                    select entry;
                foreach (Entry entry in EntrySelection)
                {
                    double? RemainingAmount = null;
                    AdvancedEntry? AdvEntry = entry as AdvancedEntry;
                    if (AdvEntry != null)
                    {
                        RemainingAmount = AdvEntry.RemainingAmount;
                    }
                    if (RemainingAmount == null)
                    {
                        count += entry.Amount;
                    }
                    else
                    {
                        count += entry.Amount * (double)RemainingAmount;
                    }
                }
                if (count <= type.WhenToAddToShoppingList)
                {
                    type.AddToShoppingList(1);
                }
            }
        }
        public static void ClearShoppingList(List<Type> types)
        {
            foreach (Type type in types)
            {
                type.RemoveFromShoppingList();
            }
        }
    }
}
