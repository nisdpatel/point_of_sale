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
            InitializeComponent();
           

            Products laptop = new Products("Dell", "$600", "I-5 Intel processor");
            Categories.Add(new Category { Name = "Electronics", Items = new List<String> { laptop.Name + " "+ laptop.Price + "" + laptop.Description} });
            //Categories.Add(new Category { Name = "Books", Items = new List<Products> { "Harry Potter and The Philosopher's Stone", "Cat and The Hat", "C# For Dummies" } });
            //Categories.Add(new Category { Name = "Electronics", Items = new List<Products> { "Dell Laptop", "Iphone", "eReader" } });
            //Categories.Add(new Category { Name = "Homegoods", Items = new List<Products> { "Microwave", "Vacuum", "Lamp" } });
            //Categories.Add(new Category { Name = "Groceries", Items = new List<Products> { "Milk", "Bread", "Cereal" } });
        }
        private ObservableCollection<Category> categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Category
    {
        public string Name { get; set; }
        public List<String> Items { get; set; }
        
        
        
    }
    public class Products
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public Products(string Name, String Price, String Description)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
        }
        
    }

}