using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerShip.Interfaces;

namespace ContainerShip.Classes
{
    public class GridPrinter : IGridPrinter
    {
        public virtual void PrintGrid(IShip ship)
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
