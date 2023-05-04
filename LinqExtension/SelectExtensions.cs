// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class SelectExtensions
{
    /// <summary>
    ///     Project each element from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to project</param>
    /// <param name="method">Transform function</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <typeparam name="TResult">Return type of transform method</typeparam>
    /// <returns>Asynchronous enumeration of transformed elements</returns>
    public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source,
        Func<TSource, TResult> method)
    {
        return (await source).Select(method);
    }

    /// <summary>
    ///     Project each element from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to project</param>
    /// <param name="method">Transform function</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <typeparam name="TResult">Return type of transform method</typeparam>
    /// <returns>Asynchronous enumeration of transformed elements</returns>
    public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source,
        Func<TSource, TResult> method)
    {
        await foreach(TSource element in source) 
            yield return method(element);
    }

    /// <summary>
    ///     Project each element using an asynchronous transformation from a source
    /// </summary>
    /// <param name="source">Source to project</param>
    /// <param name="method">Asynchronous transform function</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <typeparam name="TResult">Return type of transform method</typeparam>
    /// <returns>Asynchronous enumeration of transformed elements</returns>
    public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, Task<TResult>> method)
    {
        foreach (TSource element in source) yield return await method(element);
    }

    /// <summary>
    ///     Project each element using an asynchronous transformation from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to project</param>
    /// <param name="method">Asynchronous transform function</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <typeparam name="TResult">Return type of transform method</typeparam>
    /// <returns>Asynchronous enumeration of transformed elements</returns>
    public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<TResult>> method)
    {
        foreach (TSource element in await source) yield return await method(element);
    }


    /// <summary>
    ///     Project each element using an asynchronous transformation from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to project</param>
    /// <param name="method">Asynchronous transform function</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <typeparam name="TResult">Return type of transform method</typeparam>
    /// <returns>Asynchronous enumeration of transformed elements</returns>
    public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source,
        Func<TSource, Task<TResult>> method)
    {
        await foreach(TSource element in source)
            yield return await method(element);
    }
}