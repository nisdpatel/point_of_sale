using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class Department
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
    }
}
