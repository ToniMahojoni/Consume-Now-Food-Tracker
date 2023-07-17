using System;

public class AdvancedEntry : Entry {
    public AdvancedEntry(string Type, string Name, DateOnly BestBeforeDate, DateOnly? BuyDate, uint Amount, double? Prize,bool IsOpened, double? RemainingAmount) : 
    base(Type,Name,BestBeforeDate,BuyDate,Amount,Prize) {
        this.IsOpened = IsOpened;
        this.RemainingAmount = RemainingAmount;
    }
    public bool IsOpened {get;}
    public double? RemainingAmount {get;}
}