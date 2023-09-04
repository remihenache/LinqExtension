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

    [Test]
    public void ForeachShouldCrossTheEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        source.ForEach(spy.IncrementWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    [Test]
    public async Task ForeachShouldCrossTheAsyncEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        await source.ForEachAsync(spy.IncrementWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        await source.ForEachAsync(spy.IncrementAsyncWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheAsyncEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        await source.ForEachAsync(spy.IncrementAsyncWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    [Test]
    public async Task ForeachShouldCrossTheTaskEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        await source.ForEachAsync(spy.IncrementWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    [Test]
    public async Task AsyncForeachShouldCrossTheTaskEnumerableWithIndex()
    {
        ForeachSpy spy = new();
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        await source.ForEachAsync(spy.IncrementAsyncWithIndex);
        Assert.That(spy.NbTimeIncremented, Is.EqualTo(10));
    }

    
    
    
    

    private class ForeachSpy
    {
        public Int32 NbTimeIncremented { get; private set; }

        public void Increment(Int32 arg)
        {
            NbTimeIncremented++;
        }
        public void IncrementWithIndex(Int32 arg, Int32 index)
        {
            NbTimeIncremented += index;
        }

        public Task IncrementAsync(Int32 arg)
        {
            NbTimeIncremented++;
            return Task.CompletedTask;
        }
        public Task IncrementAsyncWithIndex(Int32 arg, Int32 index)
        {
            NbTimeIncremented += index;
            return Task.CompletedTask;
        }
    }
}