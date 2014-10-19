using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    public class DiscountRule
    {
        public double PriceLevelfordiscount { get; private set; }
        public int QuantityThresholdForDiscount { get; private set; }
        public double DiscountPercentage { get;private set; }

        public DiscountRule(double priceLevelForDiscount, int quantityThresholdForDiscount, double discountPercentage)
        {
            PriceLevelfordiscount = priceLevelForDiscount;
            QuantityThresholdForDiscount = quantityThresholdForDiscount;
            DiscountPercentage = discountPercentage;
        }

        public bool DoesPriceMatch(double bikePrice)
        {
            return bikePrice.Equals(PriceLevelfordiscount);
        }

        public bool DoesDiscountApply(double bikePrice, int bikeQuantity)
        {
            if (bikePrice.Equals(PriceLevelfordiscount)  && bikeQuantity >= QuantityThresholdForDiscount)
                return true;

            return false;
        }
        public double ApplyDiscount(double bikePrice, int bikeQuantity)
        {
            if (DoesDiscountApply(bikePrice, bikeQuantity))
                return (bikeQuantity * bikePrice) * DiscountPercentage;

            return bikeQuantity * bikePrice;
        }

        public double DiscountAmount(double bikePrice, int bikeQuantity)
        {
           var discountedTotal =  ApplyDiscount(bikePrice, bikeQuantity);

            return (bikeQuantity*bikePrice) - discountedTotal;
        }
    }
}
