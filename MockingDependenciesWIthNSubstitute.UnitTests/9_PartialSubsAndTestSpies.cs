using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;
using NSubstitute.Extensions;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class PartialSubsAndTestSpies
{
    [Fact]
    public void ReplacingASingleMethodTest()
    {
        var reader = Substitute.ForPartsOf<SummingReader>();
        reader.Configure().ReadFile("foo.txt").Returns("1,2,3,4,5"); // CAUTION: real code warning!

        var result = reader.Read("foo.txt");

        Assert.True(result == 15);
    }

    [Fact]
    public void VoidMethodsAndDoNotCallBase()
    {
         var server = Substitute.ForPartsOf<EmailServer>();
         server.WhenForAnyArgs(x => x.Send(default, default, default)).DoNotCallBase(); // Make sure Send won't call real implementation

         server.SendMultiple(
            new [] { "alice", "bob", "charlie" },
            "nsubstitute",
            "Partial subs should be used with caution."); // This won't run the real Send now, thanks to DoNotCallBase().

        server.Received().Send("alice", "nsubstitute", Arg.Any<string>());
        server.Received().Send("bob", "nsubstitute", Arg.Any<string>());
        server.Received().Send("charlie", "nsubstitute", Arg.Any<string>());
    }
}
