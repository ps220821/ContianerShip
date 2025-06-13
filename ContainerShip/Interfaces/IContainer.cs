using ContainerShip.Classes.Containers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContainerShip.Interfaces
{
    public interface IContainer
    {
        int Weight { get; }
        bool IsEmpty { get; }
        Containertypes Containertype { get; }
        bool CanBePlaced(IStack stack);
        void PlaceInStack(IStack stack);
    }
}
