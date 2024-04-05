namespace MockingDependenciesWIthNSubstitute.Application;

public class CommandRepeater {
    private ICommand command;
    int numberOfTimesToCall;
    public CommandRepeater(ICommand command, int numberOfTimesToCall) 
    {
      this.command = command;
      this.numberOfTimesToCall = numberOfTimesToCall;
    }

    public void Execute() { 
      
      for (var i=0; i<numberOfTimesToCall; i++) 
      {
        command.Execute();
      }
      
    }
}
