using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class ReturnFromAFunction
{
    [Fact]
    public void ReturnForAnyArgTest()
    {
        var calculator = Substitute.For<ICalculator>();

        // The return value for a call to a property or method can be set to the result of a function. 
        // This allows more complex logic to be put into the substitute. Although this is normally a bad practice, 
        // there are some situations in which it is useful.
        calculator
            .Add(Arg.Any<int>(), Arg.Any<int>())
            .Returns(x => (int)x[0] + (int)x[1]);

        Assert.True(calculator.Add(1, 1) == 2);
        Assert.True(calculator.Add(20, 30) == 50);
        Assert.True(calculator.Add(-73, 9348) == 9275);
    }
}
