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
        {
            Weight = isEmpty ? 4 : weight;
            IsEmpty = isEmpty;
            Containertype = Containertypes.Regular ;
        } 
        
        public Container(int weight, bool isEmpty, Containertypes containertype) 
        {
            Weight = isEmpty ? 4 : weight;
            IsEmpty = isEmpty;
            Containertype = containertype;
        }
    }
}
