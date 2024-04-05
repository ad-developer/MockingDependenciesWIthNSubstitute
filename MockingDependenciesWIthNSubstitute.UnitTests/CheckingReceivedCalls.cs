﻿using System.Windows.Input;
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
    public void ShouldExecuteCommandTheNumberOfTimesSpecified() 
    {
        var command = Substitute.For<Application.ICommand>();
        var repeater = new CommandRepeater(command, 3);
        //Act
        repeater.Execute();
        //Assert
        command.Received(3).Execute(); // << This will fail if 2 or 4 calls were received
    }

    [Fact]
    public void ReceivedForSpecificArgumentTest()
    {
        var calculator = Substitute.For<ICalculator>();
        calculator.Add(1, 2);
        calculator.Add(-100, 100);

        //Check received with second arg of 2 and any first arg:
        calculator.Received().Add(Arg.Any<int>(), 2);
        
        //Check received with first arg less than 0, and second arg of 100:
        calculator.Received().Add(Arg.Is<int>(x => x < 0), 100);
        
        //Check did not receive a call where second arg is >= 500 and any first arg:
        calculator
        .DidNotReceive()
        .Add(Arg.Any<int>(), Arg.Is<int>(x => x >= 500));
    }

    [Fact]
    public void CheckingCallsForPropertiesTest()
    {
         var calculator = Substitute.For<ICalculator>();
         var mode = calculator.Mode;
        calculator.Mode = "TEST";

        //Check received call to property getter
        //We need to assign the result to a variable to keep
        //the compiler happy or use discards (since C# 7.0).
        _ = calculator.Received().Mode;

        //Check received call to property setter with arg of "TEST"
        calculator.Received().Mode = "TEST";
    } 
    
}
