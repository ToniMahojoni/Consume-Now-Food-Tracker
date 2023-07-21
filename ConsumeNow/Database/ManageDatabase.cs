using System;
using System.Collections.Generic;
using System.Linq;

public static class ManageDatabase {
    public static void AddEntry(string[] input,List<Entry> entries) {
        entries.Add(DatabaseIO.GenerateEntryInstance(input));
    }
    public static void EditEntry(string[] input,List<Entry> entries,uint ID) {
        Entry entry = SelectEntry(entries,ID);
        Entry newEntry = DatabaseIO.GenerateEntryInstance(input);
        bool IsOpened = false;
        double? RemainingAmount = null;
        AdvancedEntry? AdvEntry = entry as AdvancedEntry;
        if (AdvEntry != null) {
            IsOpened = AdvEntry.IsOpened;
            RemainingAmount = AdvEntry.RemainingAmount;
        }
        entry.SetValues(newEntry.Type,newEntry.Name,newEntry.BestBeforeDate,newEntry.BuyDate,newEntry.Amount,newEntry.Prize,IsOpened,RemainingAmount);
    }
    public static void DeleteEntry(List<Entry> entries,uint ID) {
        Entry entry = SelectEntry(entries,ID);
        entries.Remove(entry);      
    }
    private static Entry SelectEntry(List<Entry> entries,uint ID) {
        var SelectedEntry = 
            from entry in entries
            where entry.ID == ID
            select entry;
        foreach (Entry entry in SelectedEntry) {
            return entry;
        }
        throw new ArgumentException();
    }
    public static void AddType(string[] input,List<Entry> entries) {
        entries.Add(DatabaseIO.GenerateEntryInstance(input));
    } 
    public static void EditType(string[] input,List<Type> types,uint ID) {
        Type type = SelectType(types,ID);
        Type newType = DatabaseIO.GenerateTypeInstance(input);
        type.SetValues(newType.Name,newType.StoreLocation,newType.WhenToAddToShoppingList,newType.BestBeforeDateChange,newType.Subnames,newType.AmountOnShoppinglist);
    }
    public static void DeleteType(List<Type> types,uint ID) {
        Type type = SelectType(types,ID);
        types.Remove(type);      
    }
    private static Type SelectType(List<Type> types,uint ID) {
        var SelectedType = 
            from type in types
            where type.ID == ID
            select type;
        foreach (Type type in SelectedType) {
            return type;
        }
        throw new ArgumentException();
    }



}