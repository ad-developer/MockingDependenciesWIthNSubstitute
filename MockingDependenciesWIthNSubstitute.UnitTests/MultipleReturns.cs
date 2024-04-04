using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class MultipleReturns
{
    [Fact]
    public void MultipleReturnsTest()
    {
        var calculator = Substitute.For<ICalculator>();
        
        calculator.Mode.Returns("DEC", "HEX", "BIN");
        
        Assert.True("DEC" == calculator.Mode);
        Assert.True("HEX" == calculator.Mode);
        Assert.True("BIN" == calculator.Mode);

        calculator.Mode.Returns(x => "DEC", x => "HEX", x => { throw new Exception(); });
        
        // Using callbacks (lambda expressions)
        Assert.True("DEC" ==  calculator.Mode);
        Assert.True("HEX" == calculator.Mode);
        Assert.Throws<Exception>(() => { var result = calculator.Mode; });
    }
}
