namespace MockingDependenciesWIthNSubstitute.Application;

public class OnceOffCommandRunner {
    private ICommand command;
    public OnceOffCommandRunner(ICommand command) {
        this.command = command;
    }
    public void Run() {
        if (command == null) return;
        command.Execute();
        command = null;
    }
}
