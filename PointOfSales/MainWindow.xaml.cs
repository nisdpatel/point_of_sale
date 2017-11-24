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
            Categories.Add(new Category { Name = "Books", Items = new List<String> { "Harry Potter and The Philosopher's Stone", "Cat and The Hat", "C# For Dummies" } });
            Categories.Add(new Category { Name = "Electronics", Items = new List<String> { "Dell Laptop", "Iphone", "eReader" } });
            Categories.Add(new Category { Name = "Homegoods", Items = new List<String> { "Microwave", "Vacuum", "Lamp" } });
            Categories.Add(new Category { Name = "Groceries", Items = new List<String> { "Milk", "Bread", "Cereal" } });
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


}