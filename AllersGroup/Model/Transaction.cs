using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Transaction
    {

        public string ClientCode { get; set; }
        public int Code { get; set; }
        public System.DateTime Date { get; set; }
        public long Total { get; set; }

        public List<Asset> Assets { get; set; }
        public List<int> Items { get; set; }

        /**
         * Creates a transaction.
         * info: Array of information of the transaction: client code, code (of the transaction), date, total(sum of all the subtotals).
         **/
        public Transaction(String[] info)
        {
            Assets = new List<Asset>();
            Items = new List<int>();

            ClientCode = info[0];
            Code = int.Parse(info[1]);
            Date = Convert.ToDateTime(info[2]);
            Total = long.Parse(info[3]);


            Asset a = new Asset(info[4], info[5], info[6], info[7]);
            Assets.Add(a);
        }

        /**
         * Add the item to the list of Items of the Transaction.
         * i: the item that is going to be added. 
         **/
        public void AddItem(int i)
        {
            Items.Add(i);
        }

        /**
         * Add the asset to the list of Assets of the Transaction.
         * ItemCode: Code of the item in the asset.
         * Quantity: quantity bought of the item.
         * Price: price of the item.
         * Subtotal: subtotal of the transaction (Quantity * Price).
         **/
        public void AddAsset(String ItemCode, String Quantity, String Price, String Subtotal)
        {
            Asset a = new Asset(ItemCode, Quantity, Price, Subtotal);
            Assets.Add(a);
        }

    }

}
