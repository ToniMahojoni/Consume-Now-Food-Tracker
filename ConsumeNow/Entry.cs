using System;

public class Entry {
    public Entry(string Type, string Name, DateOnly BestBeforeDate, DateOnly? BuyDate, uint Amount, double? Prize) {
        this.Type = Type;
        this.Name = Name;
        this.BestBeforeDate = BestBeforeDate;
        this.BuyDate = BuyDate;
        this.Amount = Amount;
        this.Prize = Prize;
    }
    public string Type {get;}
    public string Name {get;}
    public DateOnly BestBeforeDate {get;}
    public DateOnly? BuyDate {get;}
    public uint Amount {get;}
    public double? Prize {get;}
    public override string ToString() {
        return Type+","+Name+","+Convert.ToString(BestBeforeDate)+","+Convert.ToString(BuyDate)+","+Convert.ToString(Amount)+","
            +string.Format(System.Globalization.CultureInfo.InvariantCulture,"{0:0.00}",Prize);
    }
}