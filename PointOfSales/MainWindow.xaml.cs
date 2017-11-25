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
    public partial class MainWindow : Window
    {
        public MainWindow()

        {/*****creating new books and adding to book category ******/
            Product c_tutor = new Product("C# For Dummies", "54.78", "C# tutorial", 0.0975);
            Product cat_hat = new Product("Cat and the Hat", "2.00", "Children's book from Dr.Suess", 0.0975);

            List<Product> new_books = new List<Product> {cat_hat};
            new_books.Add(c_tutor);

            Category books = new Category("Books", new_books, 0.0975);
        /**************************************************************/

            InitializeComponent();

            Categories.Add(books);//adding book category to observable collection
        }

        /************* creating our observable list and defining its getter and setter (listing is bounded to "category_box")************/
        private ObservableCollection<Category> categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        /******************************************************************************************/

        /************Button Events*****************************************************************/

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Add(Shop_Items.SelectedItem);//add items to shopping cart
        }

        private void RemoveCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Remove(Cart.SelectedItem);// remove selected item from shopping cart

        }

        private void EmptyCart_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Clear();//clear all items from shopping cart
        }

        private void ChckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            double subtotal = 0;
            double total = 0;
            double taxes = 0;

            for (int i = 0; i < Cart.Items.Count; i++)
            {
                Product cartitem = (Product)Cart.Items[i];
                subtotal += Convert.ToDouble(cartitem.Pprice);
                taxes += Convert.ToDouble(cartitem.Pprice) * cartitem.PtaxRate;

            }

            total = subtotal + taxes;

            MessageBox.Show("Sub-Total: $" + subtotal.ToString() + "\n" + "Taxes: $" + taxes.ToString() + "\n" + "Total: $"
                + total.ToString() + "\n");//display subtotal for all items in shopping cart
        }
        //*******************************************************************/

        /*****************Custom category and product classes****************/
        public class Category
        {
            public string Cname { get; set; }
            public List<Product> Cproducts { get; set; }

            public Category(string cname, List<Product> cproducts, double ctaxRate)
            {
                this.Cname = cname;
                this.Cproducts = cproducts;
            }

            public override string ToString()
            {
                return this.Cname;
            }
        }

        public class Product
        {
              public string Pname { get; set; }
              public string Pprice { get; set; }
              public string Pdescription { get; set; }
              public string Pcategory;
              public double PtaxRate;

              public Product(string pname, string pprice, string pdescription, double ptaxRate)
              {
                  this.Pname = pname;
                  this.Pprice = pprice;
                  this.Pdescription = pdescription;
                  this.PtaxRate = ptaxRate;

              }

            public double toPrice(string cart_item)
            {

                return Convert.ToDouble(cart_item);
            }

              public override string ToString()
              {
                  return this.Pname + " | Price: $" + this.Pprice + " | Description: " + this.Pdescription;
              }
        }
        /***********************************************************************************************************/
    }
}