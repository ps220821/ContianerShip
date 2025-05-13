using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes
{
    public class GridPrinter
    {
        public virtual void PrintGrid(Ship ship)
        {
            Console.WriteLine("Ship Grid Layout (Container Count Per Stack):\n");
            for (int row = 0; row < ship.Lenght; row++)
            {
                for (int column = 0; column < ship.Width; column++)
                {
                    int containerCount = ship.Grid[row, column].CurrentWeight;
                    Console.Write($"[{containerCount}] ");
                }
                Console.WriteLine();
            }
        }
    }
}
