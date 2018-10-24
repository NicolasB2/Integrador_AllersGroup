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

        /**
         * Creates and Item.
         * info: Array of the information of the item; code, name and clasification.
         **/

        public Item(String[] info)
        {
            Code = int.Parse(info[0]);
            Name = info[1];
            Clasification = info[2];
        }

        public override string ToString()
        {
            return this.Code+";"+Name+";"+Clasification;
        }

    }
}
