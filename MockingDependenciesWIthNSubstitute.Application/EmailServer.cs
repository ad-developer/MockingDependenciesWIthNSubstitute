namespace MockingDependenciesWIthNSubstitute.Application;

public class EmailServer {
  public virtual void Send(string to, string from, string message) {
    // Insert real email sending code here
    throw new NotImplementedException();
  }

  public virtual void SendMultiple(IEnumerable<string> recipients, string from, string message) {
    foreach (var recipient in recipients) {
        Send(recipient, from, message);
    }
  }
}
