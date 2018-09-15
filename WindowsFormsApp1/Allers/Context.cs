using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    class Context
    {
        public List<Client> Clients { get; set; }
        public List<Item> items { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
