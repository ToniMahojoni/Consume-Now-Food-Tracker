using System;

public class Type {
    public Type(string Name,string StoreLocation,double? WhenToAddToShoppingList,int? BestBeforeDateChange,string[] Subnames,uint AmountOnShoppinglist) {
        this.ID = NextID++;
        this.Name = Name;
        this.StoreLocation = StoreLocation;
        this.WhenToAddToShoppingList = WhenToAddToShoppingList;
        this.BestBeforeDateChange = BestBeforeDateChange;
        this.Subnames = Subnames;
        this.AmountOnShoppinglist = AmountOnShoppinglist;
    }
    public int ID {get;}
    private static int NextID = 0;
    public string Name {get;}
    public string StoreLocation {get;}
    public double? WhenToAddToShoppingList {get;}
    public int? BestBeforeDateChange {get;}
    public string[] Subnames {get;}
    public uint AmountOnShoppinglist {get;}
    private string PrintSubnames() {
        string result = "";
        for (int i = 0; i<Subnames.Length; i++) {
            result += Subnames[i];
            if (i < Subnames.Length-1) result += ";";
        }
        return result;
    }
    public override string ToString()
    {
        return Name+","+StoreLocation+","+Convert.ToString(WhenToAddToShoppingList,System.Globalization.CultureInfo.InvariantCulture)+","+
            Convert.ToString(BestBeforeDateChange)+","+PrintSubnames()+","+Convert.ToString(AmountOnShoppinglist);
    }
}