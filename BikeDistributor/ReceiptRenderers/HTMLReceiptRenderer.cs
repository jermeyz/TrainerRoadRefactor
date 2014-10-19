using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.ReceiptRenderers
{
    public class HtmlReceiptRenderer : IReceiptRenderer
    {
        public string Render( Order order)
        {
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", order.Company.Name));
            if (order.LineItems.Any())
            {
                result.Append("<ul>");
                foreach (var lineItem in order.LineItems)
                {
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", lineItem.Quantity, lineItem.Bike.Brand, lineItem.Bike.Model, lineItem.Total.Value.ToString("C")));
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", order.OrderTotal.Value.ToString("C")));
          
            result.Append(string.Format("<h3>Tax: {0}</h3>", order.TotalTax.Value.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", (order.OrderTotal.Value + order.TotalTax.Value).ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}
