using ContainerShip.Classes.Containers;
using FluentAssertions;
using Xunit;

public class ContainerTests
{
    [Fact]
    public void Constructor_ShouldInitializeContainerCorrectly()
    {
        var container = new Container(50, false, Containertypes.Coolable);

        container.Weight.Should().Be(50);
        container.IsEmpty.Should().BeFalse();
        container.Containertype.Should().Be(Containertypes.Coolable);
    }

    [Fact]
    public void Constructor_ShouldSetDefaultWeightForEmptyContainer()
    {
        var container = new Container(0, true);

        container.Weight.Should().Be(4);
        container.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void Constructor_ShouldInitializeCoolableContainerCorrectly()
    {
        var coolableContainer = new CoolableContainer(40, false);

        coolableContainer.Weight.Should().Be(40);
        coolableContainer.Containertype.Should().Be(Containertypes.Coolable);
    }

    [Fact]
    public void Constructor_ShouldInitializeValuableContainerCorrectly()
    {
        var valuableContainer = new ValuableContainer(60, false);

        valuableContainer.Weight.Should().Be(60);
        valuableContainer.Containertype.Should().Be(Containertypes.Valuable);
    }

    [Fact]
    public void Constructor_ShouldInitializeValuableCoolableContainerCorrectly()
    {
        var valuableCoolableContainer = new ValuableCoolableContainer(80, false);

        valuableCoolableContainer.Weight.Should().Be(80);
        valuableCoolableContainer.Containertype.Should().Be(Containertypes.ValuableCoolable);
    }
}
