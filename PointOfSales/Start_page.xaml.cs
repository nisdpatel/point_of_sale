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
using System.Windows.Shapes;

namespace PointOfSales
{
    /// <summary>
    /// Interaction logic for Start_page.xaml
    /// </summary>
    public partial class Start_page : Window
    {
        public Start_page()
        {
            InitializeComponent();
        }
        private void admin_btn_Click(object sender, RoutedEventArgs e)
        {
            Checkout chkout = new Checkout();
            chkout.Show();
            this.Close();


        }

        private void user_btn_Click(object sender, RoutedEventArgs e)
        {
            Checkout chkout = new Checkout();
            chkout.inventory.Visibility = Visibility.Hidden;
            chkout.Show();

            this.Close();

        }
    }
}
