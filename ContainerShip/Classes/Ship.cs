using ContainerShip.Classes.Containers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerShip.Interfaces;

namespace ContainerShip.Classes
{
    public class Ship : IShip
    {

        public int Lenght { get; private set; }
        public int Width { get; private set; }
        public int Weight { get; private set; }
        public List<IContainer> Containers { get; private set; }
        public IStack[,] Grid { get; private set; }

        private readonly IGridPrinter gridPrinter;

        public Ship(int lenght, int width, int weight, List<IContainer> containers, IGridPrinter gridPrinter)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Weight = weight;
            this.Containers = containers;
            this.Grid = new IStack[lenght, width];

            for (int row = 0; row < this.Lenght; row++)
            {
                for (int column = 0; column < this.Width; column++)
                {
                    Grid[row, column] = new Stack(row == 0, row == 3);
                }
            }

            this.gridPrinter = gridPrinter;
        }

        private void SortContainers()
        {
            Containers = Containers.OrderByDescending(c => c.Containertype == Containertypes.Coolable || c.Containertype == Containertypes.ValuableCoolable)
                .ThenByDescending(c => c.Containertype == Containertypes.Valuable || c.Containertype == Containertypes.ValuableCoolable)
                .ThenByDescending(c => c.Weight) // Heaviest containers first
                .ToList();
        }


        public void ArrangeContainers()
        {
            SortContainers();
            foreach (IContainer container in Containers)
            {
                PlaceContainersInStack(container);
            }
            gridPrinter.PrintGrid(this);
        }

        private void PlaceContainersInStack(IContainer container)
        {
            for (int row = 0; row < this.Lenght; row++)
            {
                IStack leastLoadedStack = GetLeastLoadedRow(row);

                if (leastLoadedStack.AddToStack(container))
                {
                    return;
                }
            }
        }

        public IStack GetLeastLoadedRow(int row)
        {
            return Enumerable.Range(0, this.Width)
                .Select(col => Grid[row, col])
                .OrderBy(s => s.CurrentWeight)
                .First();
        }
    }
}
