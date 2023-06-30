namespace LinqExtension.Tests;

public class WhereExtensionTest
{
    [Test]
    public void EnumerableShouldBeFilteredAsynchronous()
    {
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        IEnumerable<Int32> result = source.WhereAsync(GreaterThan2Async).ToBlockingEnumerable();
        Assert.That(result.Count(), Is.EqualTo(3));
    }


    [Test]
    public void AsynchronousEnumerableShouldBeFilteredAsynchronous()
    {
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        IEnumerable<Int32> result = source.WhereAsync(GreaterThan2Async).ToBlockingEnumerable();
        Assert.That(result.Count(), Is.EqualTo(3));
    }

    [Test]
    public async Task AsynchronousEnumerableShouldBeFiltered()
    {
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        IEnumerable<Int32> result = await source.WhereAsync(GreaterThan2);
        Assert.That(result.Count(), Is.EqualTo(3));
    }

    [Test]
    public void IAsyncEnumerableShouldBeFiltered()
    {
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        IEnumerable<Int32> result = source.WhereAsync(GreaterThan2).ToBlockingEnumerable();
        Assert.That(result.Count(), Is.EqualTo(3));
    }

    [Test]
    public void IAsyncEnumerableShouldBeFilteredAsynchronous()
    {
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        IEnumerable<Int32> result = source.WhereAsync(GreaterThan2Async).ToBlockingEnumerable();
        Assert.That(result.Count(), Is.EqualTo(3));
    }

    private static Boolean GreaterThan2(Int32 arg)
    {
        return arg > 2;
    }

    private static Task<Boolean> GreaterThan2Async(Int32 arg)
    {
        return Task.FromResult(arg > 2);
    }
}