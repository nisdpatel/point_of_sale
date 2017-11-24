using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class Product
    {
        string name { get; set; }
        string price { get; set; }
        string description { get; set; }

        public Product(string myName, string myPrice, string myDescription)
        {
            this.name = myName;
            this.price = myPrice;
            this.description = myDescription;
        }
    }
}
