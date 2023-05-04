// ReSharper disable once CheckNamespace

namespace System.Linq;

public static class WhereExtensions
{
    /// <summary>
    ///     Find elements that match the condition from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to filter</param>
    /// <param name="method">Filter method</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <returns>Task having the filtered elements</returns>
    public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source,
        Func<TSource, Boolean> method)
    {
        return (await source).Where(method);
    }

    /// <summary>
    ///     Find elements that match the condition from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to filter</param>
    /// <param name="method">Filter method</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <returns>Task having the filtered elements</returns>
    public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source,
        Func<TSource, Boolean> method)
    {
        await foreach(TSource element in source)
            if (method(element))
                yield return element;
    }

    /// <summary>
    ///     Find elements that match an asynchronous condition from a source
    /// </summary>
    /// <param name="source">Source to filter</param>
    /// <param name="method">Asynchronous Filter method</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <returns>Task having the filtered elements</returns>
    public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source,
        Func<TSource, Task<Boolean>> method)
    {
        foreach (TSource element in source)
            if (await method(element))
                yield return element;
    }

    /// <summary>
    ///     Find elements that match an asynchronous condition from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to filter</param>
    /// <param name="method">Asynchronous Filter method</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <returns>Task having the filtered elements</returns>
    public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<Boolean>> method)
    {
        foreach (TSource element in await source)
            if (await method(element))
                yield return element;
    }


    /// <summary>
    ///     Find elements that match an asynchronous condition from an asynchronous source
    /// </summary>
    /// <param name="source">Asynchronous source to filter</param>
    /// <param name="method">Asynchronous Filter method</param>
    /// <typeparam name="TSource">Type of source elements</typeparam>
    /// <returns>Task having the filtered elements</returns>
    public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source,
        Func<TSource, Task<Boolean>> method)
    {
        await foreach(TSource element in source)
            if (await method(element))
                yield return element;
    }
}