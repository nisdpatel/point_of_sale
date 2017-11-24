using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;



namespace PointOfSales
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summ
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            Product harry_potter = new Product("Harry Potter and the Philosopher's Stone", "26.00", "First Book in the Harry Potter Series");
            List<Product> new_products = new List<Product> { harry_potter };

            Category books = new Category("Books", new_products);


            InitializeComponent();
            Products.Add(books);
            // Categories.Add(new Category { Name = "Electronics", Items = new List<String> { "Dell Laptop", "Iphone", "eReader" } });
            // Categories.Add(new Category { Name = "Homegoods", Items = new List<String> { "Microwave", "Vacuum", "Lamp" } });
            // Categories.Add(new Category { Name = "Groceries", Items = new List<String> { "Milk", "Bread", "Cereal" } });
        }
        private ObservableCollection<Category> products = new ObservableCollection<Category>();
        public ObservableCollection<Category> Products
        {
            get { return products; }
            set { products = value; }
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Add(Shop_Items.SelectedItem);
        }

        private void RemoveCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Remove(Cart.SelectedItem);

        }

        private void EmptyCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Clear();
        }

        public class Category
        {
            public string Cname { get; set; }
            public List<Product> Cproducts { get; set; }

            public Category(string cname, List<Product> cproducts)
            {
                this.Cname = cname;
                this.Cproducts = cproducts;
            }

            public override string ToString()
            {
                return this.Cname;
            }

            // public ObservableCollection<Category> products = new ObservableCollection<Category>();
        }

            public class Product
            {
                public string Pname { get; set; }
                public string Pprice { get; set; }
                public string Pdescription { get; set; }


                public Product(string pname, string pprice, string pdescription)
                {
                    this.Pname = pname;
                    this.Pprice = pprice;
                    this.Pdescription = pdescription;

                }

                public override string ToString()
                {
                    return this.Pname + " | Price: $" + this.Pprice + " | Description: " + this.Pdescription;
                }
            }
        

    }
}