namespace MockingDependenciesWIthNSubstitute.Application;

public interface ICalculator {
	int Add(int a, int b);
	string Mode { get; set; }
}
