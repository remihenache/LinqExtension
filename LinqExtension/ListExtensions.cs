// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class ListExtensions
{
    public static async Task<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source)
    {
        List<TSource> result = new();
        await foreach (TSource element in source)
        {
            result.Add(element);
        }

        return result;
    }

    public static async Task<List<TSource>> ToListAsync<TSource>(this Task<IEnumerable<TSource>> source)
    {
        return (await source).ToList();
    }
    
    public static async Task<TSource[]> ToArrayAsync<TSource>(this IAsyncEnumerable<TSource> source)
    {
        List<TSource> result = new();
        await foreach (TSource element in source)
        {
            result.Add(element);
        }

        return result.ToArray();
    }

    public static async Task<TSource[]> ToArrayAsync<TSource>(this Task<IEnumerable<TSource>> source)
    {
        return (await source).ToArray();
    }
}