using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes.Containers
{
    public class CoolableContainer : Container
    {
        public  CoolableContainer (int weight, bool isEmpty) : base( weight, isEmpty, Containertypes.Coolable)
        {

        }
    }
}
