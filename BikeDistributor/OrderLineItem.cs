using System.Collections.Generic;

namespace BikeDistributor
{
    public class OrderLineItem
    {
        public OrderLineItem()
        {
            Total = null;
            DiscountApplied = false;
        }

        public int Quantity { get; set; }
        public Bike Bike { get; set; }
        public double? Total { get; private set; }
        public bool DiscountApplied { get; private set; }
        public double DiscountAmount { get; private set; }

        public void Calculate(IList<DiscountRule> discountRules)
        {
            if (discountRules == null || discountRules.Count == 0)
            {
                Calculate();
                return;
            }


            foreach (DiscountRule discountRule in discountRules)
            {
                if (discountRule.DoesPriceMatch(Bike.Price))
                {
                    Total = discountRule.ApplyDiscount(Bike.Price, Quantity);
                    DiscountApplied = discountRule.DoesDiscountApply(Bike.Price, Quantity);
                    DiscountAmount = discountRule.DiscountAmount(Bike.Price, Quantity);
                    break;
                }
            }
        }

        public void Calculate()
        {
            Total = Quantity * Bike.Price;
        }
    }
}