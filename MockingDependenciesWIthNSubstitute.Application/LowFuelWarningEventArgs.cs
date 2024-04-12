namespace MockingDependenciesWIthNSubstitute.Application;

public class LowFuelWarningEventArgs : EventArgs {
	public int PercentLeft { get; }
	public LowFuelWarningEventArgs(int percentLeft)
    {
		PercentLeft = percentLeft;
	}
}
