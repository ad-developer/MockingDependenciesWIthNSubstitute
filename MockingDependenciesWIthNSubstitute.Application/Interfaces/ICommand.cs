namespace MockingDependenciesWIthNSubstitute.Application;

public interface ICommand {
    void Execute();
    event EventHandler Executed;
}
