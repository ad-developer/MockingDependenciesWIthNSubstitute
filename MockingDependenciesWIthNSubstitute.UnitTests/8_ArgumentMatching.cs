using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class ArgumentMatching
{
    [Fact]
    public void ArgumentMatchingTest()
    {
        var calculator = Substitute.For<ICalculator>();
        calculator.Add(1, -10);

        //Received call with first arg 1 and second arg less than 0:
        calculator.Received().Add(1, Arg.Is<int>(x => x < 0));

        //Received call with first arg 1 and second arg of -2, -5, or -10:
        calculator
            .Received()
            .Add(1, Arg.Is<int>(x => new[] {-2,-5,-10}.Contains(x)));
        
        //Did not receive call with first arg greater than 10:
        calculator.DidNotReceive().Add(Arg.Is<int>(x => x > 10), -10);
    }

     [Fact]
    public void ArgumentMatchingOutAndRefTest()
    {
        // Arrange
        var calculator = Substitute.For<ICalculator>();
            calculator
                .LoadMemory(1, out Arg.Any<int>())
                .Returns(x => {
                    x[1] = 42;
                    return true;
                });

        // Act
        var hasEntry = calculator.LoadMemory(1, out var memoryValue);
        
        //Assert
        Assert.True(hasEntry);
        Assert.True(memoryValue == 42);
    }
}
