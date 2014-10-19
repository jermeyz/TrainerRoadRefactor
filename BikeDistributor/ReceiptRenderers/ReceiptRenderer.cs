using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.ReceiptRenderers
{
    public class ReceiptRenderer : IReceiptRenderer
    {
        public string Render(Order order)
        {
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", order.Company.Name, Environment.NewLine));

            foreach (var lineItem in order.LineItems)
            {
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", lineItem.Quantity, lineItem.Bike.Brand, lineItem.Bike.Model, lineItem.Total.Value.ToString("C")));
            }

            result.AppendLine(string.Format("Sub-Total: {0}", order.OrderTotal.Value.ToString("C")));

            result.AppendLine(string.Format("Tax: {0}", order.TotalTax.Value.ToString("C")));
            result.Append(string.Format("Total: {0}", (order.OrderTotal.Value + order.TotalTax.Value).ToString("C")));
            return result.ToString();
        }

    }
}
