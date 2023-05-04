namespace LinqExtension.Tests;

public static class TestsExtensions
{
    public static async IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
    {
        foreach (TSource element in source) yield return await Task.FromResult(element);
    }
}