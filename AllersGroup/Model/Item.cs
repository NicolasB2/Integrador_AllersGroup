using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Clasification { get; set; }
        public List<Transaction> Transactions { get; set; }
        /**
         * Creates and Item.
         * info: Array of the information of the item; code, name and clasification.
         **/

        public Item(String[] info)
        {
            Code = int.Parse(info[0]);
            Name = info[1];
            Clasification = info[2];
            Transactions = new List<Transaction>();
        }
        public void AddTransaction(Transaction t)
        {
            if (t != null)
            {
                Transactions.Add(t);
            }
            else
            {
                throw new Exception("Null transaction. (Class: Client).");
            }
        }

        public override string ToString()
        {
            return this.Code+";"+Name+";"+Clasification;
        }

    }
}
