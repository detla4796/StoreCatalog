using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog<Product> catalog = new Catalog<Product>();
            catalog.AddItem(new Product("Apple", 1.5m, 10, DateTime.Now.AddDays(7)));
            catalog.AddItem(new Product("Banana", 0.5m, 20, DateTime.Now.AddDays(3)));
            catalog.AddItem(new Product("Orange", 2.5m, 5, DateTime.Now.AddDays(5)));
            Console.WriteLine($"Products in the catalog:\n{string.Join(", ", catalog.GetItems().Select(p => p.Name))}");
            Console.WriteLine($"Products prices:\n{string.Join(", ", catalog.GetItems().Select(p => p.Price))}");
            Console.WriteLine($"Products quantity:\n{string.Join(", ", catalog.GetItems().Select(p => p.Quantity))}");
            Console.WriteLine($"\nEnter the product name to purchase: ");
            string productName = Console.ReadLine();
            Console.WriteLine("\nEnter the quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Product product = catalog.GetItems().FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                if (product.Quantity >= quantity)
                {
                    Receipt(product, quantity);
                }
                else
                {
                    Console.WriteLine("Product is out of stock");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }
        static void Receipt(Product product, int quantity)
        {
            Console.WriteLine("\nReceipt");
            Console.WriteLine("Product Name: " + product.Name);
            Console.WriteLine("Price: " + product.Price);
            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Total Price: " + product.Price * quantity);
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Product(string name, decimal price, int quantity, DateTime expiryDate)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }
    }
    public class Catalog<T>
    {
        private List<T> items = new List<T>();
        public void AddItem(T item)
        {
            items.Add(item);
        }
        public void RemoveItem(T item)
        {
            items.Remove(item);
        }
        public IEnumerable<T> GetItems()
        {
            return items;
        }
    }
}
