using ContainerShip.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Interfaces
{
    public interface IShip
    {
        int Lenght { get; }
        int Width { get; }
        IStack[,]Grid  { get; }

        void ArrangeContainers();
        IStack GetLeastLoadedRow(int row);
    }

}
