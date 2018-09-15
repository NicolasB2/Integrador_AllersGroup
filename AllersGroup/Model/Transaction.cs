using System;
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
        public int ItemCode { get; set; }
        public int QuantityItems { get; set; }
        public int ItemPrice { get; set; }
        public long Subtotal { get; set; }

        public Client Client { get; set; }
        public Item Item { get; set; }

        public Transaction(String[] info)
        {
            ClientCode = info[0];
            Code = int.Parse(info[1]);
            Date = Convert.ToDateTime(info[2]);
            Total = long.Parse(info[3]);
            ItemCode = int.Parse(info[4]);
            QuantityItems = int.Parse(info[5]);
            ItemPrice = int.Parse(info[6]);
            Subtotal = long.Parse(info[7]);
        }
    }

}
