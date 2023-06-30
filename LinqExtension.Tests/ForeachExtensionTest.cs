namespace LinqExtension.Tests;

public class ForeachExtensionTest
{
    [Test]
    public void ForeachShouldCrossTheEnumerable()
    {
        ForeachSpy spy = new();
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        source.ForEach(spy.Increment);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }

    [Test]
    public async Task ForeachShouldCrossTheAsyncEnumerable()
    {
        ForeachSpy spy = new();
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        await source.ForEachAsync(spy.Increment);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheEnumerable()
    {
        ForeachSpy spy = new();
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        await source.ForEachAsync(spy.IncrementAsync);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheAsyncEnumerable()
    {
        ForeachSpy spy = new();
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        await source.ForEachAsync(spy.IncrementAsync);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }

    [Test]
    public async Task ForeachShouldCrossTheTaskEnumerable()
    {
        ForeachSpy spy = new();
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        await source.ForEachAsync(spy.Increment);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheTaskEnumerable()
    {
        ForeachSpy spy = new();
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        await source.ForEachAsync(spy.IncrementAsync);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(5));
    }


    private class ForeachSpy
    {
        public Int32 NbTimeIncremented { get; private set; }

        public void Increment(Int32 arg)
        {
            NbTimeIncremented++;
        }

        public Task IncrementAsync(Int32 arg)
        {
            NbTimeIncremented++;
            return Task.CompletedTask;
        }
    }
}