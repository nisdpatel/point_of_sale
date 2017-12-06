using POSData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace PointOfSales
{
    /// <summary>
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        private ProductContext _context = new ProductContext();

        public Checkout()
        {
            InitializeComponent();
        }



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
                subtotal += Convert.ToDouble(cartitem.Price);
                taxes += Convert.ToDouble(cartitem.Price) * Convert.ToDouble(cartitem.Category.TaxRate);

            }

            total = subtotal + taxes;

            MessageBox.Show("Sub-Total: $" + Math.Truncate(subtotal * 100) / 100 + "\n" + "Taxes: $" + +Math.Truncate(taxes * 100) / 100 + "\n" + "Total: $"
                + +Math.Truncate(total * 100) / 100 + "\n");//display subtotal taxes and total for all items in shopping cart
        }


        private void UI_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));


            _context.Categories.Load();


            categoryViewSource.Source = _context.Categories.Local;


            categoryViewSource.Source = _context.Categories.Local;
        }

        private void inventory_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
