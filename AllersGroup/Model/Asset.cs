using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Asset
    {

        public int ItemCode { get; set; }
        public int QuantityItems { get; set; }
        public int ItemPrice { get; set; }
        public long Subtotal { get; set; }

        public Asset(String ItemCode, String QuantityItems, String ItemPrice, String Subtotal)
        {
            this.ItemCode = int.Parse(ItemCode);
            this.QuantityItems = int.Parse(QuantityItems);
            this.ItemPrice = int.Parse(ItemPrice);
            this.Subtotal = long.Parse(Subtotal);

        }
    }
}
