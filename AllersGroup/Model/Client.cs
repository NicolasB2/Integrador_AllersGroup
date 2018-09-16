using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        private List<string> itemsRelacionados;

        public Client(String[] info)
        {
            this.Transactions = new HashSet<Transaction>();

            itemsRelacionados = new List<string>();
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
        public List<string> ItemsRelacionados { get; set; }

        public ICollection<Transaction> Transactions { get; set; }




    }

}
