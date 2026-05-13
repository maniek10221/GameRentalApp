using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalApp
{
    internal interface IRentable
    {
        void Rent();
        void ReturnItem();
    }
}
