using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Zaliczenie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Store
    {
        private List<Product> products = new List<Product>();

        // Inicjalizacja listy produktów
        public Store()
        {
            products.Add(new Product(1, "Bialko serwatkowe o smaku czekoladowym 1 kg", 79.99m, 10));
            products.Add(new Product(2, "Kreatyna 500g", 49.99m, 8));
            products.Add(new Product(3, "Witamina D3 2000 IU w kroplach", 19.99m, 15));
            products.Add(new Product(4, "Omega-3, 30 kapsulek", 18.99m, 12));
            products.Add(new Product(5, "Soplowka jezowata, 30 kapsulek", 34.99m, 7));
            products.Add(new Product(6, "BCAA 500g", 54.99m, 9));
            products.Add(new Product(7, "Ashwagandha, 60 kapsulek", 26.99m, 11));
        }

        // Wyświetlanie listy produktów
        public void ShowProducts()
        {
            Console.WriteLine("=== DOSTEPNE PRODUKTY ===");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        // Pobieranie produktu po ID
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        // Aktualizacja stanu magazynowego po zakupie
        public void UpdateStock(List<CartItem> purchasedItems)
        {
            foreach (var item in purchasedItems)
            {
                var product = GetProductById(item.Product.Id);
                if (product != null)
                {
                    product.StockQuantity -= item.Quantity;
                }
            }
        }
    }

}
