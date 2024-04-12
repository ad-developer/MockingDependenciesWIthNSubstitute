using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class ReplacingReturnValues
{
    [Fact]
    public void ReplacingReturnValuesTest()
    {
         var calculator = Substitute.For<ICalculator>();

        calculator.Mode.Returns("DEC,HEX,OCT");
        calculator.Mode.Returns(x => "???");
        calculator.Mode.Returns("HEX");
        calculator.Mode.Returns("BIN");
        
        Assert.True(calculator.Mode == "BIN");
    }
}
