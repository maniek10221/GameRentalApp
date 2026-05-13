using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    internal class GameFactory
    {
        public static Game CreateGame(string type, string title, string extraInfo)
        {
            switch (type.ToLower())
            {
                case "pc":
                    RequirementsLevel level = 
                        (RequirementsLevel)Enum.Parse(
                            typeof(RequirementsLevel),
                            extraInfo,
                            true
                        );
                    return new PcGame(title, level);
                        
                case "console":
                    return new ConsoleGame(title, extraInfo);
                default:
                    throw new Exception("Nieznany typ gry.");
            }
        }
    }
}
