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
        private const int MaxWeight = 120;
        public List<IContainer> Containers { get; private set; }
        public int CurrentWeight => Containers.Sum(c => c.Weight);
        public bool IsInFirstRow { get; private set; }
        public bool IsInLastRow { get; private set; }

        public Stack(bool isInFirstRow, bool isInLasttRow)
        {
            IsInFirstRow = isInFirstRow;
            IsInLastRow = isInLasttRow;
            Containers = new List<IContainer>();
        }

        public bool PlaceableInStack(IContainer container)
        {
            if (CurrentWeight + container.Weight > MaxWeight)
                return false;
            return container.CanBePlaced(this);
        }

        public bool AddToStack(IContainer container)
        {
            if (!PlaceableInStack(container))
                return false;

            container.PlaceInStack(this);
            return true;
        }
    }
}
