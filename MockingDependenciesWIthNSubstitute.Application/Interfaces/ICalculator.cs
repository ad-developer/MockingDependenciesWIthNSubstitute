namespace MockingDependenciesWIthNSubstitute.Application;

public interface ICalculator {
	int Add(int a, int b);
	string Mode { get; set; }
	bool LoadMemory(int first, out int second);
}
