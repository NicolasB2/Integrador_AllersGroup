using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
       

        public Client(String[] info)
        {
            this.Transactions = new List<Transaction>();

            Code = info[0];
            Name = info[1];
            City = info[2];
            Departament = info[3];
            Payment = info[4];
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Payment { get; set; }

        public List <Transaction>Transactions { get; set; }

        public Client FindClient(String c)
        {
            if (Code.Equals(c))
            {
                return this;
            }
            else
            {
            return null;
            }
        }

        public void addTransaction(Transaction t)
        {
            if (t != null)
            {
                Transactions.Add(t);
            }
            else
            {
                throw new Exception("Null transaction. (Class: Client) ");
            }
        }

    }

}
