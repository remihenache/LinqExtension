namespace LinqExtension.Tests;

public class ListExtensionTest
{
    [Test]
    public async Task AsyncEnumerableShouldBeTransformedAsynchronousToList()
    {
        IEnumerable<Int32> source = new[] {1, 2, 3, 4, 5};
        List<String> result = await source.SelectAsync(ToStringAsync).ToListAsync();
        Assert.That(result, Is.EquivalentTo(new[] {"1", "2", "3", "4", "5"}));
    }


    [Test]
    public async Task TaskEnumerableShouldBeTransformedAsynchronousToList()
    {
        Task<IEnumerable<Int32>> source = Task.FromResult<IEnumerable<Int32>>(new[] {1, 2, 3, 4, 5});
        List<Int32> result = await source.ToListAsync();
        Assert.That(result, Is.EquivalentTo(new[] {1, 2, 3, 4, 5}));
    }

    private static Task<String> ToStringAsync(Int32 arg)
    {
        return Task.FromResult(arg.ToString());
    }
}