using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    internal class GameRentalService
    {
        private List<Game> games = new List<Game>();
        private List<User> users = new List<User>();

        //Dodawanie gry
        public void AddGame(Game game)
        {
            games.Add(game);
        }

        //Dodawanie użytkowanika
        public void AddUser(User user)
        {
            users.Add(user);
        }

        //Wyświetlanie wszystkich gier
        public void ShowAllGames()
        {
            foreach (var game in games)
            {
                game.DisplayInfo();
            }
        }
        //Wypożyczenie gry
        public void RentGame(User user, Game game)
        {
            if (game.Status == GameStatus.Available)
            {
                game.Rent();
                user.RentGame(game);
            }
            else
            {
                Console.WriteLine("Gra jest już wypożyczona.");
            }
        }

        //Zwrot gry
        public void ReturnGame(User user, Game game)
        {
            game.ReturnItem();
            user.ReturnGame(game);
        }
        public List<Game> GetGames()
        {
            return new List<Game>(games);
        }


    }
}
