using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
        public static class ManageDatabase
        {
            public static void AddEntry(string[] input, List<Entry> entries) //add Entry to list
            {
                entries.Add(DatabaseIO.GenerateEntryInstance(input));
            }
            public static void EditEntry(string[] input, List<Entry> entries, List<Type> types, uint ID) //edit specific Entry specified by its ID
            {
                Entry entry = SelectEntry(entries, ID);
                Entry newEntry = DatabaseIO.GenerateEntryInstance(input);
                bool IsOpened = false;
                double? RemainingAmount = null;
                AdvancedEntry? AdvEntry = newEntry as AdvancedEntry;
                if (AdvEntry != null)
                {
                    IsOpened = AdvEntry.IsOpened;
                    RemainingAmount = AdvEntry.RemainingAmount;
                }
                DateOnly BestBeforeDate = newEntry.BestBeforeDate;
                Type type = SelectType(types,newEntry.Type);
                int BestBeforeDateChange = -1;
                if (type.BestBeforeDateChange != null) BestBeforeDateChange = (int) type.BestBeforeDateChange;
                AdvancedEntry? OldAdvEntry = entry as AdvancedEntry;
                if (OldAdvEntry != null) {
                    if (IsOpened & !OldAdvEntry.IsOpened) {
                        BestBeforeDate = DateOnly.FromDateTime(DateTime.Today.AddDays(BestBeforeDateChange));
                    }
                }
                if (AdvEntry != null) {
                    (entry as AdvancedEntry).SetValues(newEntry.Type, newEntry.Name, BestBeforeDate, newEntry.BuyDate, newEntry.Amount, newEntry.Prize, IsOpened, RemainingAmount);
                } else {
                    entry.SetValues(newEntry.Type, newEntry.Name, BestBeforeDate, newEntry.BuyDate, newEntry.Amount, newEntry.Prize, IsOpened, RemainingAmount);
                }
            }
            public static void DeleteEntry(List<Entry> entries, uint ID) // delete specific Entry specified by its ID
            {
                Entry entry = SelectEntry(entries, ID);
                entries.Remove(entry);
            }
            public static Entry SelectEntry(List<Entry> entries, uint ID)
            {
                var SelectedEntry =
                    from entry in entries
                    where entry.ID == ID
                    select entry;
                foreach (Entry entry in SelectedEntry)
                {
                    return entry;
                }
                throw new ArgumentException();
            }
            public static void AddType(string[] input, List<Type> types) // add Type to list
            {
                if (input[4].Contains(',')) throw new ArgumentException();
                types.Add(DatabaseIO.GenerateTypeInstance(input,types));
            }
            public static void DeleteType(List<Type> types, string Name) // delete specific Type identified by its Name
            {
                Type type = SelectType(types, Name);
                types.Remove(type);
            }
            public static Type SelectType(List<Type> types, string Name)
            {
                var SelectedType =
                    from type in types
                    where type.Name == Name
                    select type;
                foreach (Type type in SelectedType)
                {
                    return type;
                }
                throw new ArgumentException();
            }



        }
}
