using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    class Transaction
    {
            public int Code { get; set; }
            public System.DateTime Date { get; set; }
            public string Total { get; set; }
            public string QuantityItems { get; set; }
            public string ItemPrice { get; set; }
            public string Subtotal { get; set; }
            public string ClientCode { get; set; }
            public int ItemCode { get; set; }

            public virtual Client Client { get; set; }
            public virtual Item Item { get; set; }
        }
    }

