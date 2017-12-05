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
using System.Data.Entity;
using POSData;

namespace PointOfSales
{
    public partial class MainWindow : Window
    {
        private ProductContext _context = new ProductContext();
        public MainWindow()

        {/*****creating new books and adding to book category ******
            Product c_tutor = new Product("C# For Dummies", "54.78", "C# tutorial", 0.0975);
            Product cat_hat = new Product("Cat and the Hat", "2.00", "Children's book from Dr.Suess", 0.0975);

            List<Product> new_books = new List<Product> {cat_hat};
            new_books.Add(c_tutor);

            Category books = new Category("Books", new_books, 0.0975);
        **************************************************************/

            InitializeComponent();
            
          //  Categories.Add();//adding book category to observable collection
        }

        /************* creating our observable list and defining its getter and setter (listing is bounded to "category_box")************/
        private ObservableCollection<Category> categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categories
       {
         get { return categories; }
         set { categories = value; }
        }

        /******************************************************************************************/




        private void UI_Loaded_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));

            // Load is an extension method on IQueryable, 
            // defined in the System.Data.Entity namespace.
            // This method enumerates the results of the query, 
            // similar to ToList but without creating a list.
            // When used with Linq to Entities this method 
            // creates entity objects and adds them to the context.
            _context.Categories.Load();

            // After the data is loaded call the DbSet<T>.Local property 
            // to use the DbSet<T> as a binding source.
            categoryViewSource.Source = _context.Categories.Local;


            // Load data by setting the CollectionViewSource.Source property:
            categoryViewSource.Source = _context.Categories.Local;
        }



        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            // When you delete an object from the related entities collection 
            // (in this case Products), the Entity Framework doesn’t mark 
            // these child entities as deleted.
            // Instead, it removes the relationship between the parent and the child
            // by setting the parent reference to null.
            // So we manually have to delete the products 
            // that have a Category reference set to null.

            // The following code uses LINQ to Objects 
            // against the Local collection of Products.
            // The ToList call is required because otherwise the collection will be modified
            // by the Remove call while it is being enumerated.
            // In most other situations you can use LINQ to Objects directly 
            // against the Local property without using ToList first.
            foreach (var product in _context.Products.Local.ToList())
            {
                if (product.Category == null)
                {
                    _context.Products.Remove(product);
                }
            }

            _context.SaveChanges();
            // Refresh the grids so the database generated values show up.
            this.categoryDataGrid.Items.Refresh();
            this.productsDataGrid.Items.Refresh();

        }

        private void Shopping_Click(object sender, RoutedEventArgs e)
        {
            Checkout chkout = new Checkout();
            chkout.Show();
            this.Close();
        }
        /***********************************************************************************************************/
    }
}