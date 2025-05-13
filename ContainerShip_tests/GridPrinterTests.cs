using ContainerShip.Classes;
using ContainerShip.Interfaces;
using Moq;
using Xunit;

public class GridPrinterTests
{
    [Fact]
    public void PrintGrid_ShouldCallPrintOnce()
    {
        var gridPrinterMock = new Mock<GridPrinter>();
        var ship = new Ship(2, 2, 1000, new List<IContainer>(), gridPrinterMock.Object);

        gridPrinterMock.Object.PrintGrid(ship);

        gridPrinterMock.Verify(g => g.PrintGrid(It.IsAny<Ship>()), Times.Once);
    }
}
