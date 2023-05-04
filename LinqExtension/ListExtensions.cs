// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class ListExtensions
{
    public static async Task<List<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source)
    {
        List<TSource> result = new();
        await foreach (TSource element in source)
        {
            result.Add(element);
        }

        return result;
    }

    public static async Task<List<TSource>> ToList<TSource>(this Task<IEnumerable<TSource>> source)
    {
        return (await source).ToList();
    }
}