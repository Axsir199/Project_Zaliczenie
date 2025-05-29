using Project_Zaliczenie;
using System;

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();       // Sklep z produktami
        Cart cart = new Cart();          // Koszyk kupca
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== SKLEP Z SUPLEMENTAMI DIETY ===");
            Console.WriteLine("\n1. Wyswietl produkty");
            Console.WriteLine("2. Dodaj produkt do koszyka");
            Console.WriteLine("3. Usun produkt z koszyka");
            Console.WriteLine("4. Pokaz koszyk");
            Console.WriteLine("5. Finalizuj zakup");
            Console.WriteLine("0. Wyjdz");
            Console.Write("\nWybierz opcje: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    store.ShowProducts();
                    break;

                case "2":
                    Console.Write("Podaj ID produktu do dodania: ");
                    if (int.TryParse(Console.ReadLine(), out int addId))
                    {
                        Product productToAdd = store.GetProductById(addId);
                        if (productToAdd != null)
                        {
                            Console.Write("Podaj ilosc: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                cart.AddProduct(productToAdd, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidlowa ilosc.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Produkt o podanym ID nie istnieje.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowy ID.");
                    }
                    break;

                case "3":
                    Console.Write("Podaj ID produktu do usuniecia: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                    {
                        cart.RemoveProduct(removeId);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowy ID.");
                    }
                    break;

                case "4":
                    cart.ShowCart();
                    break;

                case "5":
                    Console.WriteLine("Finalizacja zakupu:");
                    cart.ShowCart();
                    store.UpdateStock(cart.GetItems());
                    cart.Clear();
                    Console.WriteLine("Dziekujemy za zakupy!");
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Zamykam sklep. Do zobaczenia!");
                    break;

                default:
                    Console.WriteLine("Nieznana opcja. Sprobuj ponownie.");
                    break;
            }
        }
    }
}
