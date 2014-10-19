using System.Collections.Generic;
using BikeDistributor.ReceiptRenderers;

namespace BikeDistributor
{
    public class Order
    {
        private readonly IList<Line> _lines = new List<Line>();

        public IList<OrderLineItem> LineItems;

        public Order(Company company, double taxRate, IList<DiscountRule> discountRules,
            IReceiptRenderer receiptRenderer)
        {
            Company = company;
            LineItems = new List<OrderLineItem>();
            TaxRate = taxRate;
            ReceiptRenderer = receiptRenderer;
            DiscountRules = discountRules;
        }

        public IReceiptRenderer ReceiptRenderer { get; set; }
        public double TaxRate { get; set; }
        public double? OrderTotal { get; set; }
        public double? TotalTax { get; set; }
        public IList<DiscountRule> DiscountRules { get; set; }

        public Company Company { get; private set; }


        public void AddRental(Line rental)
        {
            _lines.Add(rental);
        }
         
        public double CalculateTotal()
        {
            double Total = 0;
            foreach (Line line in _lines)
            {
                double thisAmount = 0d;
                var lineItem = new OrderLineItem();
                lineItem.Bike = line.Bike;
                lineItem.Quantity = line.Quantity;
                lineItem.Calculate(DiscountRules);
                LineItems.Add(lineItem);
                Total += lineItem.Total.Value;
            }
            return Total;
        }

        public string RenderReceipt()
        {
            OrderTotal = CalculateTotal();
            TotalTax = OrderTotal.Value * TaxRate;
            return ReceiptRenderer.Render(this);
        }


    }
}