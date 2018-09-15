using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    class Item
    {
        public Item()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Clasification { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
