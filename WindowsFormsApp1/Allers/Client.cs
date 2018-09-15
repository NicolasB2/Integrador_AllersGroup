using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    class Client
    {
        public Client()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Payment { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
