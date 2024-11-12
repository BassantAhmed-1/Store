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
                // Check if ProductIdTextBox is not empty
                if (string.IsNullOrWhiteSpace(ProductIdTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid product ID.");
                    return;
                }

                // Check if CountTextBox is not empty
                if (string.IsNullOrWhiteSpace(CountTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                // Attempt to parse the inputs
                int productId = int.Parse(ProductIdTextBox.Text);
                int quantity = int.Parse(CountTextBox.Text);
               
                if (quantity <= 0)
                {
                    MessageBox.Show("Quantity requred ");
                    return;
                }

                var foundProduct = db.Products.FirstOrDefault(product => product.ProductID == productId);
                decimal prices = quantity*foundProduct.Price;
                if (foundProduct != null)
                {
                    // Add item to cart
                    cartItems.Add(new CartItem { ProductName = foundProduct.ProductName, Quantity = quantity,Price= prices });
                    MessageBox.Show($"Added {quantity} of {foundProduct.ProductName} to cart");
                }
                else
                {
                    MessageBox.Show("Product not found. Please check the product ID.");
                }

                datagrid.ItemsSource = db.Products.ToList();
            }
            //catch (FormatException)
            //{
            //    MessageBox.Show("Please enter valid numeric values for product ID and quantity.");
            //}
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