namespace MockingDependenciesWIthNSubstitute.Application;

public class SomethingThatNeedsACommand {
    private ICommand command;
    public SomethingThatNeedsACommand(ICommand command) { 
        this.command = command;
    }
    public void DoSomething() 
    { 
        command.Execute(); 
    }
    public void DontDoAnything() 
    { 
        
    }
}
