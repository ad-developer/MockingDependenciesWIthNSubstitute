namespace MockingDependenciesWIthNSubstitute.Application;

public class CommandWatcher {
    private ICommand command;
    public CommandWatcher(ICommand command) { 
    	command.Executed += OnExecuted;
    }
    public bool DidStuff { get; private set; }
    public void OnExecuted(object o, EventArgs e) 
    { 
        DidStuff = true; 
    }
} 
