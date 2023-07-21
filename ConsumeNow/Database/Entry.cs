using System;

public class Entry {
    public Entry(string Type, string Name, DateOnly BestBeforeDate, DateOnly BuyDate, uint Amount, double? Prize) {
        this.ID = NextID++;
        this.Type = Type;
        this.Name = Name;
        this.BestBeforeDate = BestBeforeDate;
        this.BuyDate = BuyDate;
        this.Amount = Amount;
        this.Prize = Prize;
    }
    public uint ID {get;}
    private static uint NextID = 0;
    public string Type {get;private set;}
    public string Name {get;private set;}
    public DateOnly BestBeforeDate {get;private set;}
    public DateOnly BuyDate {get;private set;}
    public uint Amount {get;private set;}
    public double? Prize {get;private set;}
    public override string ToString() {
        return Type+","+Name+","+Convert.ToString(BestBeforeDate)+","+Convert.ToString(BuyDate)+","+Convert.ToString(Amount)+","
            +string.Format(System.Globalization.CultureInfo.InvariantCulture,"{0:0.00}",Prize);
    }
    public virtual void SetValues(string Type, string Name, DateOnly BestBeforeDate, DateOnly BuyDate, uint Amount, double? Prize,bool IsOpened, double? RemainingAmount) {
        this.Type = Type;
        this.Name = Name;
        this.BestBeforeDate = BestBeforeDate;
        this.BuyDate = BuyDate;
        this.Amount = Amount;
        this.Prize = Prize;        
    }
}