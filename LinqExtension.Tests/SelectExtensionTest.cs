namespace LinqExtension.Tests;

public class SelectExtensionTest
{
    [Test]
    public void EnumerableShouldBeTransformedAsynchronous()
    {
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        IEnumerable<String> result = source.SelectAsync(ToStringAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }


    [Test]
    public void AsynchronousEnumerableShouldBeTransformedAsynchronous()
    {
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        IEnumerable<String> result = source.SelectAsync(ToStringAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }

    [Test]
    public async Task AsynchronousEnumerableShouldBeTransformed()
    {
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        IEnumerable<String> result = await source.SelectAsync(ToString);
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }

    [Test]
    public void IAsyncEnumerableShouldBeTransformedAsynchronous()
    {
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        IEnumerable<String> result = source.SelectAsync(ToStringAsync).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }

    [Test]
    public void IAsyncEnumerableShouldBeTransformed()
    {
        IAsyncEnumerable<Int32> source = new[] {1, 2, 3, 4, 5}.ToAsyncEnumerable();
        IEnumerable<String> result = source.SelectAsync(ToString).ToBlockingEnumerable();
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }

    private static String ToString(Int32 arg)
    {
        return arg.ToString();
    }

    private static Task<String> ToStringAsync(Int32 arg)
    {
        return Task.FromResult(arg.ToString());
    }
}