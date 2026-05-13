using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameRentalService service = new GameRentalService();

            //Tworzenie gier
            Game game1 = GameFactory.CreateGame(
                "pc",
                "Cyberpunk 2077",
                "High"
            );

            Game game2 = GameFactory.CreateGame(
                "console",
                "FIFA 23",
                "PlayStation"
            );
          
            //Tworzenie użytkownika
            User customer = new User("Customer", UserRole.Customer);
            User admin = new User("Admin", UserRole.Admin);

            //Dodanie systemu
            service.AddGame(game1);
            service.AddGame(game2);
            service.AddUser(customer);
            service.AddUser(admin);
            Console.WriteLine("Wybierz użytkownika: ");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine();

            Console.WriteLine("Twój wybór: ");
            string userChoice = Console.ReadLine();

            User currentUser;

            switch (userChoice)
            {
                case "1":
                    currentUser = customer;
                    break;
                case "2":
                    currentUser = admin;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór");
                    return;
            }

            while (true)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("\n=== WYPOŻYCZALNIA GIER ===");
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("1. Pokaż gry");
                Console.WriteLine("2. Wypożycz grę");
                Console.WriteLine("3. Zwróć grę");
                Console.WriteLine("4. Dodaj nową grę do systemu");
                Console.WriteLine("5. Wyjście");
                Console.WriteLine();

                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        service.ShowAllGames(); 
                        break;
                    
                    case "2":
                        Console.WriteLine();
                        List<Game> games = service.GetGames();
                        Console.WriteLine("\n----------- LISTA GIER -----------");
                        
                        for (int i = 0; i < games.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {games[i].Title}");
                        }

                        Console.WriteLine("Wybierz numer gry: ");
                        if (int.TryParse(Console.ReadLine(), out int gameChoice))
                        {
                            if (gameChoice >= 1 && gameChoice <= games.Count)
                            {
                                service.RentGame(currentUser, games[gameChoice - 1]);
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy numer gry.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Musisz wpisać liczbę");
                        }
                        break;

                    case "3":
                        Console.WriteLine();
                        List<Game> rentedGames = currentUser.RentedGames;
                        if (rentedGames.Count == 0)
                        {
                            Console.WriteLine("Brak wypożyczonych gier.");
                            break;
                        }

                        Console.WriteLine("\n-------- WYPOŻYCZONE GRY --------");

                        for (int i = 0; i < rentedGames.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {rentedGames[i].Title}");
                        }

                        Console.WriteLine("Wybierz numer gry do zwrotu: ");

                        if (int.TryParse(Console.ReadLine(), out int returnChoice))
                        {
                            if (returnChoice >= 1 && returnChoice <= rentedGames.Count)
                            {
                                service.ReturnGame(currentUser, rentedGames[returnChoice - 1]);
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy numer gry.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Musisz wpisać liczbę.");
                        }
                        break;

                    case "4":
                        Console.WriteLine();
                        if (currentUser.Role != UserRole.Admin)
                        {
                            Console.WriteLine("Brak uprawnień administratora.");
                            break;
                        }
                        Console.WriteLine("\n=== DODAWANIE GRY ===");

                        Console.Write("Tytuł gry: ");
                        string title = Console.ReadLine();

                        Console.Write("Typ gry (pc/console): ");
                        string type = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Tytuł gry nie może być pusty.");
                            break;
                        }

                        string extraInfo = "";
                        if (type.ToLower() == "pc")
                        {
                            Console.WriteLine("Poziom wymagań");
                            Console.WriteLine("1. Low");
                            Console.WriteLine("2. Medium");
                            Console.WriteLine("3. High");
                            Console.Write("Twój wybór: ");

                            string choiceLevel = Console.ReadLine();

                            switch (choiceLevel)
                            {
                                case "1":
                                    extraInfo = "Low";
                                    break;
                                case "2":
                                    extraInfo = "Medium";
                                    break;
                                case "3":
                                    extraInfo = "High";
                                    break;
                                default:
                                    Console.WriteLine("Nieprawidłowy wybór.");
                                    break ;
                            }
                            if (choiceLevel != "1" &&
                                choiceLevel != "2" &&
                                choiceLevel != "3")
                            {
                                break;
                            }
                        }
                        else if (type.ToLower() == "console")
                        {
                            Console.Write("Typ konsoli: ");
                            extraInfo = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Nieznany typ gry.");
                            break;
                        }

                        try
                        {
                            Game newGame = GameFactory.CreateGame(type, title, extraInfo);
                            service.AddGame(newGame);
                            Console.WriteLine("Gra została dodana.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break ;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;

                }
            }
         
        }
    }
}
