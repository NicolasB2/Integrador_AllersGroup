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

        public virtual ICollection<Transaction> Transactions { get; set; }

        public Item(String[] info)
        {
            Code = int.Parse(info[0]);
            Name = info[1];
            Clasification = info[2];
            this.Transactions = new HashSet<Transaction>();

        }

    }
}
