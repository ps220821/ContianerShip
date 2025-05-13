using ContainerShip.Classes;
using ContainerShip.Classes.Containers;
using FluentAssertions;
using Moq;
using Xunit;

public class StackTests
{
    [Fact]
    public void AddToStack_ShouldAddContainerWhenValid()
    {
        var stack = new Stack(true, false);
        var container = new Container(50, false);

        bool result = stack.AddToStack(container);

        result.Should().BeTrue();
        stack.Containers.Should().Contain(container);
    }

    [Fact]
    public void AddToStack_ShouldNotAddContainerIfWeightLimitExceeded()
    {
        var stack = new Stack(true, false);
        var container = new Container(130, false); // Exceeds max weight

        bool result = stack.AddToStack(container);

        result.Should().BeFalse();
        stack.Containers.Should().BeEmpty();
    }

    [Fact]
    public void PlaceableInStack_ShouldReturnFalseIfNotInCorrectRow()
    {
        var stack = new Stack(false, false); // Not in the first or last row
        var container = new ValuableContainer(40, false);

        bool result = stack.PlaceableInStack(container);

        result.Should().BeFalse();
    }

    [Fact]
    public void PlaceableInStack_ShouldReturnTrueForRegularContainers()
    {
        var stack = new Stack(true, false);
        var container = new Container(50, false);

        bool result = stack.PlaceableInStack(container);

        result.Should().BeTrue();
    }

    [Fact]
    public void PlaceableInStack_ShouldReturnFalseForValuableContainersInMiddleRow()
    {
        var stack = new Stack(false, false); // Not in first or last row
        var container = new ValuableContainer(60, false);

        bool result = stack.PlaceableInStack(container);

        result.Should().BeFalse();
    }

    [Fact]
    public void PlaceableInStack_ShouldReturnTrueForValuableContainersInFirstOrLastRow()
    {
        var stack = new Stack(true, false); // First row
        var container = new ValuableContainer(60, false);

        bool result = stack.PlaceableInStack(container);

        result.Should().BeTrue();
    }
}