namespace LinqExtension.Tests;

public class SelectManyExtensionTest
{
    [Test]
    public void EnumerableShouldBeAppendedAsynchronous()
    {
        IEnumerable<ObjectHavingInt> source = new[]
        {
            new ObjectHavingInt
            {
                Ints = new[] {1, 1, 1}
            },
            new ObjectHavingInt
            {
                Ints = new[] {2, 2, 2}
            }
        };
        IEnumerable<Int32> result = source.SelectManyAsync(GetIntAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {1, 1, 1, 2, 2, 2}));
    }


    [Test]
    public void AsynchronousEnumerableShouldBeAppendedAsynchronous()
    {
        IEnumerable<ObjectHavingInt> source = new[]
        {
            new ObjectHavingInt
            {
                Ints = new[] {1, 1, 1}
            },
            new ObjectHavingInt
            {
                Ints = new[] {2, 2, 2}
            }
        };
        Task<IEnumerable<ObjectHavingInt>> sourceTask = Task.FromResult(source);
        IEnumerable<Int32> result = sourceTask.SelectManyAsync(GetIntAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {1, 1, 1, 2, 2, 2}));
    }

    [Test]
    public void AsynchronousEnumerableShouldBeAppended()
    {
        IEnumerable<ObjectHavingInt> source = new[]
        {
            new ObjectHavingInt
            {
                Ints = new[] {1, 1, 1}
            },
            new ObjectHavingInt
            {
                Ints = new[] {2, 2, 2}
            }
        };
        Task<IEnumerable<ObjectHavingInt>> sourceTask = Task.FromResult(source);
        IEnumerable<Int32> result = sourceTask.SelectMany(GetInt).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {1, 1, 1, 2, 2, 2}));
    }

    [Test]
    public void IAsyncEnumerableShouldBeAppendedAsynchronous()
    {
        IEnumerable<ObjectHavingInt> intsArray = new[]
        {
            new ObjectHavingInt
            {
                Ints = new[] {1, 1, 1}
            },
            new ObjectHavingInt
            {
                Ints = new[] {2, 2, 2}
            }
        };
        IAsyncEnumerable<ObjectHavingInt> source = intsArray.ToAsyncEnumerable();
        IEnumerable<Int32> result = source.SelectManyAsync(GetIntAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {1, 1, 1, 2, 2, 2}));
    }

    [Test]
    public void IAsyncEnumerableShouldBeAppended()
    {
        IEnumerable<ObjectHavingInt> intsArray = new[]
        {
            new ObjectHavingInt
            {
                Ints = new[] {1, 1, 1}
            },
            new ObjectHavingInt
            {
                Ints = new[] {2, 2, 2}
            }
        };
        IAsyncEnumerable<ObjectHavingInt> source = intsArray.ToAsyncEnumerable();
        IEnumerable<Int32> result = source.SelectMany(GetInt).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {1, 1, 1, 2, 2, 2}));
    }

    private static IEnumerable<Int32> GetInt(ObjectHavingInt arg)
    {
        return arg.Ints;
    }

    private static Task<IEnumerable<Int32>> GetIntAsync(ObjectHavingInt arg)
    {
        return Task.FromResult(arg.Ints);
    }

    private class ObjectHavingInt
    {
        public IEnumerable<Int32> Ints { get; init; } = ArraySegment<Int32>.Empty;
    }
}