using ContainerShip.Classes.Containers;
using ContainerShip.Classes;
using FluentAssertions;
using Moq;
using Xunit;
using ContainerShip.Interfaces;

public class ShipTests
{
    [Fact]
    public void ArrangeContainers_ShouldArrangeContainersCorrectly()
    {
        var containers = new List<IContainer>
        {
            new Container(50, false),
            new CoolableContainer(40, false),
            new ValuableContainer(60, false),
        };

        var gridPrinterMock = new Mock<IGridPrinter>();
        var ship = new Ship(2, 2, 1000, containers, gridPrinterMock.Object);

        ship.ArrangeContainers();

        // We can verify if PrintGrid was called once after arranging containers.
        gridPrinterMock.Verify(g => g.PrintGrid(It.IsAny<IShip>()), Times.Once);

        // You may add more assertions to ensure containers are placed in the grid correctly.
        ship.Containers.Should().HaveCount(3);  // We have 3 containers.
    }

    [Fact]
    public void GetLeastLoadedRow_ShouldReturnCorrectStack()
    {
        var gridPrinterMock = new Mock<IGridPrinter>();
        var ship = new Ship(2, 2, 1000, new List<IContainer>(), gridPrinterMock.Object);

        var stack = ship.GetLeastLoadedRow(0);

        stack.Should().NotBeNull();
        stack.CurrentWeight.Should().BeLessThanOrEqualTo(ship.Grid[0, 1].CurrentWeight); // Ensure it's the least loaded stack
    }
     
    [Fact]

    public void ArrangeContainers_ShouldNotPlaceContainerIfNoRoom()
    {
        var containers = new List<IContainer>
        {
            new Container(150, false),  // Exceeds weight capacity
            new Container(100, false)
        };

        var gridPrinterMock = new Mock<IGridPrinter>();
        var ship = new Ship(2, 2, 1000, containers, gridPrinterMock.Object);

        ship.ArrangeContainers();

        // In this case, if containers can't be arranged, check the behavior.
        gridPrinterMock.Verify(g => g.PrintGrid(It.IsAny<IShip>()), Times.Once);
    }
}