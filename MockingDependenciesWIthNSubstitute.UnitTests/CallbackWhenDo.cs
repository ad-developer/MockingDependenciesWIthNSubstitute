using MockingDependenciesWIthNSubstitute.Application;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class CallbackWhenDo
{
    [Fact]
    public void CallbackWehnDoTest()
    {
        var counter = 0;
        var foo = Substitute.For<IFoo>();
        foo.When(x => x.SayHello("World"))
            .Do(x => counter++);

        foo.SayHello("World");
        foo.SayHello("World");

        Assert.True(2 == counter);
    }

    [Fact]
    public void CallbacksTest()
    {
        //The Callback builder lets us create more complex Do() scenarios. 
        // We can use Callback.First() followed by Then(), ThenThrow() and ThenKeepDoing() to build chains of callbacks. 
        // We can also use Always() and AlwaysThrow() to specify callbacks called every time. Note that a callback set by an 
        // Always() method will be called even if other callbacks will throw an exception.
        var sub = Substitute.For<ISomething>();

        var calls = new List<string>();
        var counter = 0;

        sub
        .When(x => x.Something())
        .Do(
            Callback.First(x => calls.Add("1"))
                .Then(x => calls.Add("2"))
                .Then(x => calls.Add("3"))
                .ThenKeepDoing(x => calls.Add("+"))
                .AndAlways(x => counter++)
        );

        for (int i = 0; i < 5; i++)
        {
            sub.Something();
        }
        Assert.True(String.Concat(calls) == "123++");
        Assert.True(counter ==  5);
    }
}
