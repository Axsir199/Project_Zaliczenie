using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Zaliczenie
{
    public class CartItem
    {
        public Product Product { get; set; }   // Produkt w koszyku
        public int Quantity { get; set; }      // Ilość sztuk

        // Konstruktor
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // Metoda do wyświetlania informacji o pozycji w koszyku
        public override string ToString()
        {
            decimal totalPrice = Product.Price * Quantity;
            return $"{Product.Name} x {Quantity} = {totalPrice:C}";
        }
    }

}
