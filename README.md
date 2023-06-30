# C# LINQ Async Extensions

This project provides a set of extension methods that enhance the LINQ (Language Integrated Query) functionality in C# by adding support for asynchronous operations. It includes extensions for common LINQ operations such as Select, SelectMany, and Where, allowing developers to work with asynchronous sources and transformations.

## ForeachExtensions
The ForeachExtensions class contains extension methods for asynchronous iteration over collections using foreach loops. It includes the following methods:

- ForEach: Iterates over an enumerable and executes an action synchronously.
- ForEachAsync: Iterates over an enumerable and executes an asynchronous action.
- ForEach (for IAsyncEnumerable): Iterates over an async enumerable and executes an action.
## ListExtensions
The ListExtensions class provides an extension method for converting an IAsyncEnumerable or Task<IEnumerable> to a List asynchronously. It includes the following method:

- ToListAsync: Converts an asynchronous enumerable to a list.
## SelectExtensions
The SelectExtensions class adds async projection capabilities to the Select operation. It offers various overloads to handle synchronous and asynchronous transform functions. The methods included are:

- Select (for Task<IEnumerable>): Projects elements asynchronously using a synchronous transform function.
- Select (for IAsyncEnumerable): Projects elements asynchronously using a synchronous transform function.
- SelectAsync (for IEnumerable): Projects elements asynchronously using an asynchronous transform function.
- SelectAsync (for Task<IEnumerable>): Projects elements asynchronously using an asynchronous transform function.
- SelectAsync (for IAsyncEnumerable): Projects elements asynchronously using an asynchronous transform function.
## SelectManyExtensions
The SelectManyExtensions class extends the SelectMany operation with async support. It allows flattening and transforming collections asynchronously using synchronous and asynchronous transform functions. The methods provided are:

- SelectMany (for Task<IEnumerable>): Flattens and transforms elements asynchronously using a synchronous transform function.
- SelectManyAsync (for Task<IEnumerable>): Flattens and transforms elements asynchronously using an asynchronous transform function.
- SelectManyAsync (for IEnumerable): Flattens and transforms elements asynchronously using an asynchronous transform function.
- SelectManyAsync (for IAsyncEnumerable): Flattens and transforms elements asynchronously using an asynchronous transform function.
- SelectMany (for IAsyncEnumerable): Flattens and transforms elements asynchronously using a synchronous transform function.
## WhereExtensions
The WhereExtensions class adds async filtering capabilities to the Where operation. It allows filtering elements from asynchronous sources based on synchronous and asynchronous conditions. The methods included are:

- Where (for Task<IEnumerable>): Filters elements asynchronously using a synchronous condition.
- Where (for IAsyncEnumerable): Filters elements asynchronously using a synchronous condition.
- WhereAsync (for IEnumerable): Filters elements asynchronously using an asynchronous condition.
- WhereAsync (for Task<IEnumerable>): Filters elements asynchronously using an asynchronous condition.
- WhereAsync (for IAsyncEnumerable): Filters elements asynchronously using an asynchronous condition.

# Usage
To use these extensions, include the provided code in your C# project and ensure that the appropriate namespaces (System.Linq, etc.) are referenced. Make sure that you have the necessary dependencies and target framework version set correctly.

Feel free to explore and leverage these extensions to incorporate async operations into your LINQ queries.

### Note: This code snippet is a standalone C# implementation and can be integrated into your project to extend the LINQ