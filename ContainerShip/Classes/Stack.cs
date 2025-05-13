using ContainerShip.Classes.Containers;
using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes
{
    public class Stack : IStack
    {
        private int MaxWeight = 120;
        public List<IContainer> Containers { get; private set; }
        public int CurrentWeight => Containers.Sum(c => c.Weight);
        public bool IsInFirstRow { get; private set; }
        public bool IsInLasttRow { get; private set; }

        public Stack(bool isInFirstRow, bool isInlastRow)
        {
            IsInFirstRow = isInFirstRow;
            IsInLasttRow = isInlastRow;
            Containers = new List<IContainer>();
        }

        private bool CheckIfEceedsWeight(IContainer container)
        {
            return CurrentWeight + container.Weight <= MaxWeight;
        }

        public bool PlaceableInStack(IContainer container)
        {
            if (!CheckIfEceedsWeight(container)) return false;

            if (Containers.Any() && Containers.Last().Containertype == Containertypes.Valuable)
            {
                if (container.Containertype == Containertypes.Regular)
                {
                    return true;
                }
                return false;
            }

            if (container.Containertype == Containertypes.Valuable)
            {
                if (!IsInFirstRow && !IsInLasttRow) return false; // Must be in at least one of them
            }

            if (container.Containertype == Containertypes.Coolable || container.Containertype == Containertypes.ValuableCoolable)
            {
                if (!IsInFirstRow) return false;
            }
            return true;
        }

        public bool AddToStack(IContainer container)
        {
            if (PlaceableInStack(container))
            {
                if (container.Containertype == Containertypes.Regular)
                {
                    Containers.Insert(0, container);
                }
                else
                {
                    Containers.Add(container);
                }
                return true;
            }
            return false;
        }
    }
}
