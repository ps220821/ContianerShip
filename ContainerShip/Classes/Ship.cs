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
        public int MaxWeight { get; private set; }
        public List<IContainer> Containers { get; private set; }
        public IStack[,] Grid { get; private set; }
        private readonly IGridPrinter gridPrinter;

        public Ship(int lenght, int width, int maxWeight, IEnumerable<IContainer> containers, IGridPrinter gridPrinter)
        {
            Lenght = lenght;
            Width = width;
            MaxWeight = maxWeight;
            Containers = containers.ToList();
            Grid = new IStack[Lenght, Width];
            InitializeGrid();
            this.gridPrinter = gridPrinter;
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < Lenght; row++)
            {
                bool first = row == 0;
                bool last = row == Lenght - 1;
                for (int col = 0; col < Width; col++)
                    Grid[row, col] = new Stack(first, last);
            }
        }

        public void ArrangeContainers()
        {
            var sorted = Containers
                .OrderByDescending(c => c.Containertype == Containertypes.Coolable || c.Containertype == Containertypes.ValuableCoolable)
                .ThenByDescending(c => c.Containertype == Containertypes.Valuable || c.Containertype == Containertypes.ValuableCoolable)
                .ThenByDescending(c => c.Weight)
                .ToList();

            foreach (var container in sorted)
                PlaceContainer(container);

            gridPrinter.PrintGrid(this);
        }

        private void PlaceContainer(IContainer container)
        {
            var candidates = Grid.Cast<IStack>()
                .OrderBy(s => s.CurrentWeight)
                .ThenBy(s => s.IsInFirstRow ? 0 : 1)
                .ToList();

            foreach (var stack in candidates)
            {
                if (stack.AddToStack(container))
                    return;
            }

            throw new InvalidOperationException(
                $"Kan container niet plaatsen: {container.Containertype} (gewicht {container.Weight})");
        }
    }
}
