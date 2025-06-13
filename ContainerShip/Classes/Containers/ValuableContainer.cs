using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes.Containers
{
    public class ValuableContainer : Container
    {
        public ValuableContainer(int weight, bool isEmpty)
            : base(weight, isEmpty, Containertypes.Valuable)
        {
        }

        public override bool CanBePlaced(IStack stack)
        {
            // only last row
            if (!stack.IsInFirstRow && !stack.IsInLastRow) return false;
            // not on valuable 
            if (stack.Containers.Any() && stack.Containers.Last().Containertype == Containertypes.Valuable)
                return false;
            return true;
        }

        public override void PlaceInStack(IStack stack)
        {
            stack.Containers.Add(this);
        }
    }
}
