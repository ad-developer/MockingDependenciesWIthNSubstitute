namespace MockingDependenciesWIthNSubstitute.Application;

public class SummingReader {
  public virtual int Read(string path) 
  {
    var s = ReadFile(path);
    return s.Split(',').Select(int.Parse).Sum();
  }
  public virtual string ReadFile(string path) 
  { 
        return "the result of reading the file here"; 
  }
}
