using Project_Zaliczenie;
using System;

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();       // Sklep z produktami
        Cart cart = new Cart();          // Koszyk użytkownika
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== SKLEP Z SUPLEMENTAMI DIETY ===");
            Console.WriteLine("1. Wyświetl produkty");
            Console.WriteLine("2. Dodaj produkt do koszyka");
            Console.WriteLine("3. Usuń produkt z koszyka");
            Console.WriteLine("4. Pokaż koszyk");
            Console.WriteLine("5. Finalizuj zakup");
            Console.WriteLine("0. Wyjdź");
            Console.Write("Wybierz opcję: ");

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
                            Console.Write("Podaj ilość: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                cart.AddProduct(productToAdd, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowa ilość.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Produkt o podanym ID nie istnieje.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy ID.");
                    }
                    break;

                case "3":
                    Console.Write("Podaj ID produktu do usunięcia: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                    {
                        cart.RemoveProduct(removeId);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy ID.");
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
                    Console.WriteLine("Dziękujemy za zakupy!");
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Zamykam sklep. Do zobaczenia!");
                    break;

                default:
                    Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
