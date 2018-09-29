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
        public int Quantity { get; set; }
        public int Price { get; set; }
        public long Subtotal { get; set; }

        /**
         * Creates an Asset (a description of an item on the transaction).
         * ItemCode: the code of the item.
         * Quantity: quantity bought of the item.
         * Price: price of the item.
         * Subtotal: subtotal of the transaction (Quantity * Price).
         **/
        public Asset(String ItemCode, String Quantity, String Price, String Subtotal)
        {
            this.ItemCode = int.Parse(ItemCode);
            this.Quantity = int.Parse(Quantity);
            this.Price = int.Parse(Price);
            this.Subtotal = long.Parse(Subtotal);

        }
    }
}
