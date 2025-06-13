using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes.Containers
{
    public class ValuableCoolableContainer : Container
    {
        public ValuableCoolableContainer(int weight, bool isEmpty)
            : base(weight, isEmpty, Containertypes.ValuableCoolable)
        {
        }

        public override bool CanBePlaced(IStack stack)
        {
            // Koelregel
            if (!stack.IsInFirstRow) return false;
            // Waardevolregel
            if (!stack.IsInFirstRow && !stack.IsInLastRow) return false;
            // Niet bovenop waardevolle
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
