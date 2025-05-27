using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Zaliczenie
{
    public class Product
    {
        public int Id { get; set; }              // Unikalny identyfikator
        public string Name { get; set; }         // Nazwa produktu
        public decimal Price { get; set; }       // Cena jednostkowa
        public int StockQuantity { get; set; }   // Ilość dostępna w magazynie

        // Konstruktor
        public Product(int id, string name, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        // Metoda do wyświetlania informacji o produkcie
        public override string ToString()
        {
            return $"{Id}. {Name} - {Price:C} (Dostępne: {StockQuantity})";
        }
    }

}
