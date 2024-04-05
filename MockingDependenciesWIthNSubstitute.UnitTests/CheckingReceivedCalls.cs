using System.Windows.Input;
using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class CheckingReceivedCalls
{
    [Fact]
    public void CheckingReceivedCallsTest()
    {
        //Arrange
        var command = Substitute.For<Application.ICommand>();
        var something = new SomethingThatNeedsACommand(command);
        
        //Act
        something.DoSomething();
        
        //Assert
        command.Received().Execute();
    }

    [Fact]
    public void CheckingNotReceivedCallsTest()
    {
        //Arrange
        var command = Substitute.For<Application.ICommand>();
        var something = new SomethingThatNeedsACommand(command);
        
        //Act
        something.DontDoAnything();
        
        //Assert
        command.DidNotReceive().Execute();
    }

    [Fact]
    public void Should_execute_command_the_number_of_times_specified() 
    {
        var command = Substitute.For<Application.ICommand>();
        var repeater = new CommandRepeater(command, 3);
        //Act
        repeater.Execute();
        //Assert
        command.Received(3).Execute(); // << This will fail if 2 or 4 calls were received
    }
}
