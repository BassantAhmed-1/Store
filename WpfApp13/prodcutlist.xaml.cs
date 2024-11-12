using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class prodcutlist : Page
    {
        OnlineShoppingDBEntities db = new OnlineShoppingDBEntities();
        private List<CartItem> cartItems = new List<CartItem>(); // List to hold cart items

        public prodcutlist()
        {
            InitializeComponent();
            LoadProductsFromDatabase();
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                var products = db.Products.ToList();
                datagrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage(cartItems));
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(ProductIdTextBox.Text, out int productId))
                {
                    MessageBox.Show("Please enter a valid product ID.");
                    return;
                }

                if (!int.TryParse(CountTextBox.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                var foundProduct = db.Products.FirstOrDefault(product => product.ProductID == productId);

                if (foundProduct != null)
                {
                    // Add item to cart
                    cartItems.Add(new CartItem { ProductName = foundProduct.ProductName, Quantity = quantity });
                    MessageBox.Show($"Added {quantity} of {foundProduct.ProductName} to cart.");
                }
                else
                {
                    MessageBox.Show("Product not found. Please check the product ID.");
                }

                datagrid.ItemsSource = db.Products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        //private void GoToCart_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new CartPage(cartItems)); // Navigate to the cart page with current cart items
        //}
    }
}