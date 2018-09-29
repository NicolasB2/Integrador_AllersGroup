using System;
using System.Collections.Generic;

namespace Model
{
    public class Client
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Payment { get; set; }

        public List<Transaction> Transactions { get; set; }

        /**
         * Creates a client.
         * info: Array of the information of a client; code, name, city, department and payment.
         **/
        public Client(String[] info)
        {
            this.Transactions = new List<Transaction>();

            Code = info[0];
            Name = info[1];
            City = info[2];
            Departament = info[3];
            Payment = info[4];
        }

        /**
         * Adds a given transaction to the list of transactions of a client.
         * t: transaction that is added to the list. 
         **/
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

    }

}
