using System.Windows.Input;
using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class ClearReceivedCalls
{
    [Fact]
    public void ClearReceivedCallsTest()
    {
        var command = Substitute.For<Application.ICommand>();
        var runner = new OnceOffCommandRunner(command);

        //First run
        runner.Run();
        command.Received().Execute();

        //Forget previous calls to command
        command.ClearReceivedCalls();

        //Second run
        runner.Run();
        command.DidNotReceive().Execute();
    }
}
