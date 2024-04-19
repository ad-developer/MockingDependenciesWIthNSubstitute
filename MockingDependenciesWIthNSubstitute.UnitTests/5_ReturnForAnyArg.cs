using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class ReturnForAnyArg
{
    [Fact]
    public void ReturnForAnyArTest()
    {
        var calculator = Substitute.For<ICalculator>();
        
        calculator.Add(1, 2).ReturnsForAnyArgs(100); 
        
        Assert.Equal(100, calculator.Add(1, 2));
        Assert.Equal(100, calculator.Add(-7, 15));


        calculator.Add(default, default).ReturnsForAnyArgs(100);

        Assert.Equal(100, calculator.Add(1, 2));
        Assert.Equal(100, calculator.Add(-7, 15));
    }
}
