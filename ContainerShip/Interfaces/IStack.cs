using ContainerShip.Classes.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Interfaces
{
    public interface IStack
    {
        int CurrentWeight { get; }
        bool IsInFirstRow { get; }
        bool IsInLastRow { get; }
        List<IContainer> Containers { get;}
        bool PlaceableInStack(IContainer container);
        bool AddToStack(IContainer container);
    }
}
