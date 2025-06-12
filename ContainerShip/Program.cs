using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ContainerShip.Classes;
using ContainerShip.Classes.Containers;
using ContainerShip.Interfaces;

class Program
{
    static void Main()
    {
        Console.WriteLine(("Enter the length of the ship: "));
        int length = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(("Enter the width of the ship: "));
        int width = Convert.ToInt32(Console.ReadLine());
        IGridPrinter gridPrinter = new GridPrinter();

        List<IContainer> containers = new List<IContainer>();
        containers.Add(new Container(30, false));  // Regular container, 20 tons
        containers.Add(new CoolableContainer(30, false));  // Coolable container, 15 tons
        containers.Add(new CoolableContainer(30, false));  // Coolable container, 15 tons
        containers.Add(new ValuableContainer(30, false));  // Valuable container, 25 tons
        containers.Add(new CoolableContainer(30, false));  // Coolable container, 18 tons
        containers.Add(new ValuableContainer(30, false));  // Valuable container, 22 tons

        // Additional containers
        containers.Add(new Container(30, false));
        containers.Add(new ValuableContainer(30, false));
        containers.Add(new CoolableContainer(30, false));
        containers.Add(new ValuableContainer(27, false));
        containers.Add(new CoolableContainer(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(28, false));
        containers.Add(new ValuableContainer(30, false));
        containers.Add(new CoolableContainer(30, false));
        containers.Add(new ValuableContainer(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, true));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(10, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(20, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(25, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(20, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(20, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(30, false));
        containers.Add(new Container(15, false));
        containers.Add(new Container(10, false));
        containers.Add(new Container(20, true));
        containers.Add(new Container(28, false));


        // Create the ship with 4 rows and 5 columns
        IShip ship = new Ship(length, width, 90, containers, gridPrinter);

        // Arrange the containers in the ship
        ship.ArrangeContainers();

        // Generate the URL based on the arranged containers
        string url = UrlGenerator.GetUrl(ship);

        // Copy the generated URL to the clipboard
       
        Console.WriteLine(url);
    }
}
