// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class ForeachExtensions
{
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (TSource element in source) action(element);
    }

    public static async Task ForEach<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource> action)
    {
        foreach (TSource element in await source) action(element);
    }

    public static async Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
    {
        foreach (TSource element in source) await action(element);
    }

    public static async Task ForEachAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
    {
        foreach (TSource element in await source) await action(element);
    }

    public static async Task ForEach<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
    {
        await foreach(TSource element in source) action(element);
    }

    public static async Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action)
    {
        await foreach(TSource element in source) await action(element);
    }
}