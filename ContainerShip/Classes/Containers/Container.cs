using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes.Containers
{
    public enum Containertypes
    {
        Regular = 1,
        Valuable = 2,
        Coolable = 3,
        ValuableCoolable = 4
    }

    public class Container : IContainer
    {
        public int Weight { get; private set; }
        public bool IsEmpty { get; private set; }
        public Containertypes Containertype { get; private set; }

        public Container(int weight, bool isEmpty)
            : this(weight, isEmpty, Containertypes.Regular)
        {
        }

        protected Container(int weight, bool isEmpty, Containertypes type)
        {
            Weight = isEmpty ? 4 : weight;
            IsEmpty = isEmpty;
            Containertype = type;
        }

        public virtual bool CanBePlaced(IStack stack)
        {
            return true;
        }

        // placing rule for regualar container is 
        public virtual void PlaceInStack(IStack stack)
        {
            stack.Containers.Insert(0, this);
        }
    }
}
