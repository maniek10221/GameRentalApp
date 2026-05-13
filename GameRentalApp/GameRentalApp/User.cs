using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    internal class User
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public List<Game> RentedGames { get; set; } = new List<Game>();
        public User(string name, UserRole role)
        {
            Name = name;
            Role = role;
        }
        
        public void RentGame(Game game)
        {
            RentedGames.Add(game);
            Console.WriteLine($"{Name} wypożyczył/a {game.Title}");
        }

        public void ReturnGame(Game game)
        {
            RentedGames.Remove(game);
            Console.WriteLine($"{Name} zwrócił/a {game.Title}");
        }
    }
}
