using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Zaliczenie
{
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();  // Lista pozycji w koszyku

        // Dodawanie produktu do koszyka
        public void AddProduct(Product product, int quantity)
        {
            var existingItem = items.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity + quantity <= product.StockQuantity)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    Console.WriteLine("Nie można dodać więcej niż dostępna ilość.");
                }
            }
            else
            {
                if (quantity <= product.StockQuantity)
                {
                    items.Add(new CartItem(product, quantity));
                }
                else
                {
                    Console.WriteLine("Nie można dodać więcej niż dostępna ilość.");
                }
            }
        }

        // Usuwanie produktu z koszyka
        public void RemoveProduct(int productId)
        {
            var item = items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    // Zmniejszamy ilość o 1
                    item.Quantity--;
                }
                else
                {
                    // Jeśli ilość to 1, usuwamy pozycję z koszyka
                    items.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("Produkt nie znaleziony w koszyku.");
            }
        }


        // Wyświetlanie zawartości koszyka
        public void ShowCart()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Koszyk jest pusty.");
            }
            else
            {
                Console.WriteLine("=== ZAWARTOŚĆ KOSZYKA ===");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Łączna kwota: {GetTotal():C}");
            }
        }

        // Obliczanie łącznej wartości koszyka
        public decimal GetTotal()
        {
            return items.Sum(item => item.Product.Price * item.Quantity);
        }

        // Zwracanie listy wszystkich pozycji (do finalizacji)
        public List<CartItem> GetItems()
        {
            return items;
        }

        // Czyszczenie koszyka
        public void Clear()
        {
            items.Clear();
        }
    }

}
