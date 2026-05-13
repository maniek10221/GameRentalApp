using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    public class PcGame : Game
    {
        public RequirementsLevel Requirements { get; set; }
        public PcGame(string title, RequirementsLevel requirements)
            : base(title, "PC")
        {
            Requirements = requirements;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"{Title} | Platforma: PC | Wymagania: {Requirements} | Status: {Status}"
            );
        }
    }
}
