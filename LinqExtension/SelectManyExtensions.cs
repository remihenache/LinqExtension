// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class SelectManyExtensions
{
    public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source,
        Func<TSource, IEnumerable<TResult>> method)
    {
        foreach (TSource element in await source)
        {
            IEnumerable<TResult> results = method(element);
            foreach (TResult result in results) yield return result;
        }
    }

    public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<IEnumerable<TResult>>> method)
    {
        foreach (TSource element in await source)
        {
            IEnumerable<TResult> results = await method(element);
            foreach (TResult result in results) yield return result;
        }
    }

    public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, Task<IEnumerable<TResult>>> method)
    {
        foreach (TSource element in source)
        {
            IEnumerable<TResult> results = await method(element);
            foreach (TResult result in results) yield return result;
        }
    }

    public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(
        this IAsyncEnumerable<TSource> source,
        Func<TSource, Task<IEnumerable<TResult>>> method)
    {
        await foreach (TSource element in source)
        {
            IEnumerable<TResult> results = await method(element);
            foreach (TResult result in results) yield return result;
        }
    }

    public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source,
        Func<TSource, IEnumerable<TResult>> method)
    {
        await foreach(TSource element in source)
        {
            IEnumerable<TResult> results = method(element);
            foreach (TResult result in results) yield return result;
        }
    }
}