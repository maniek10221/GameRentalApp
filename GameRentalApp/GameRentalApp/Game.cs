using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    public abstract class Game : IRentable, IDisplayable
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public GameStatus Status { get; set; }

        public Game(string title, string platform)
        {
            Title = title;
            Platform = platform;
            Status = GameStatus.Available;
        }
        public virtual void Rent()
        {
            Status = GameStatus.Rented;
        }
        public virtual void ReturnItem()
        {
            Status = GameStatus.Available;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Title} | {Platform} | {Status}");
        }
    }
}
