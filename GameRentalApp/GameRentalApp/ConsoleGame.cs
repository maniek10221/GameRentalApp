using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    public class ConsoleGame : Game
    {
        public string ConsoleType { get; set; }
        public ConsoleGame(string title, string consoleType)
            : base(title, "Console")
        {
            ConsoleType = consoleType;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"{Title} | Platforma: Console | Konsola: {ConsoleType} | Status: {Status}"
            );
        }
    }
}