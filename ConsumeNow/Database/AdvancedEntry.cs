using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
        public class AdvancedEntry : Entry
        {
            public AdvancedEntry(string Type, string Name, DateOnly BestBeforeDate, DateOnly BuyDate, uint Amount, double? Prize, bool IsOpened, double? RemainingAmount) :
            base(Type, Name, BestBeforeDate, BuyDate, Amount, Prize)
            {
                this.IsOpened = IsOpened;
                this.RemainingAmount = RemainingAmount; //represents the portion of the produkt that is still available (between 0 and 1)
            }
            public bool IsOpened { get; private set; }
            public double? RemainingAmount { get; private set; }
            public override string ToString()
            {
                return base.ToString() + "," + Convert.ToString(IsOpened) + "," + string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", RemainingAmount);
            }
            public override void SetValues(string Type, string Name, DateOnly BestBeforeDate, DateOnly BuyDate, uint Amount, double? Prize, bool IsOpened, double? RemainingAmount)
            {
                base.SetValues(Type, Name, BestBeforeDate, BuyDate, Amount, Prize, IsOpened, RemainingAmount);
                this.IsOpened = IsOpened;
                this.RemainingAmount = RemainingAmount;
            }
        }
}
