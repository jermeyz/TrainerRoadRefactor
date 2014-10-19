using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.ReceiptRenderers
{
    public interface IReceiptRenderer
    {
        string Render( Order order);
    }
}
