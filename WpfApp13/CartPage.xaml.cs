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

namespace WpfApp13
{
    public partial class CartPage: Page
    {
        public List<CartItem> CartItems { get; set; }

        public CartPage(List<CartItem> cartItems)
        {
            InitializeComponent();
            CartItems = cartItems;
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            CartDataGrid.ItemsSource = CartItems; // Bind the cart items to the DataGrid
        }

        private void BackToProducts_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack(); // Navigate back to the product list
        }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
