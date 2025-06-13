using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes.Containers
{
    public class CoolableContainer : Container
    {
        public CoolableContainer(int weight, bool isEmpty)
            : base(weight, isEmpty, Containertypes.Coolable)
        {
        }

        public override bool CanBePlaced(IStack stack)
        {
            if (!stack.IsInFirstRow) return false;
            if (stack.Containers.Any() && stack.Containers.Last().Containertype == Containertypes.Valuable)
                return false;
            return true;
        }
        public override void PlaceInStack(IStack stack)
        {
            // Coolable gaat achteraan
            stack.Containers.Add(this);
        }
    }
}
