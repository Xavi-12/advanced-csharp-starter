namespace AdvancedCsharp;

/// <summary>
/// Generics Practice Exercises
///
/// Generics let you write code that works with any type while maintaining type safety.
/// Instead of writing separate methods for int, string, Player, etc., you write ONE
/// generic method that works with all of them.
///
/// Type parameter naming conventions:
/// - T = Type (general purpose)
/// - TKey, TValue = for dictionary-like structures
/// - TInput, TOutput = for transformations
/// </summary>
public static class GenericsExercises
{
    // ============================================================
    // PART 1: GENERIC METHODS
    // A generic method declares its own type parameter(s).
    // The type is determined when you call the method.
    //
    // Example:
    // public static T GetFirst<T>(T[] items) => items[0];
    //
    // Usage:
    // int first = GetFirst<int>(new[] { 1, 2, 3 });      // returns 1
    // string first = GetFirst<string>(new[] { "a", "b" }); // returns "a"
    // ============================================================

    /// <summary>
    /// Exercise 201: Return the last element of an array.
    ///
    /// This method should work with ANY type: int[], string[], Player[], etc.
    /// </summary>
    public static T GetLast<T>(T[] items)
    {
        return items[items.Length - 1];
    }

    /// <summary>
    /// Exercise 202: Swap two values.
    ///
    /// After calling Swap(ref a, ref b), the values of a and b should be exchanged.
    /// </summary>
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    /// <summary>
    /// Exercise 203: Create an array containing the same item repeated n times.
    ///
    /// Example: CreateArray("hello", 3) returns ["hello", "hello", "hello"]
    /// Example: CreateArray(42, 2) returns [42, 42]
    /// </summary>
    public static T[] CreateArray<T>(T item, int count)
    {
        T[] result = new T[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = item;
        }

        return result;
    }

    /// <summary>
    /// Exercise 204: Find the index of an item in an array, or -1 if not found.
    ///
    /// Use .Equals() for comparison (not ==) to work with any type.
    ///
    /// Example: IndexOf(new[] { 10, 20, 30 }, 20) returns 1
    /// Example: IndexOf(new[] { "a", "b", "c" }, "x") returns -1
    /// </summary>
    public static int IndexOf<T>(T[] items, T target)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]!.Equals(target))
            {
                return i;
            }
        }

        return -1;
    }

    // ============================================================
    // PART 2: GENERIC METHODS WITH CONSTRAINTS
    // Constraints restrict which types can be used with a generic.
    // This allows you to call specific methods on the type parameter.
    //
    // Common constraints:
    // - where T : class          (T must be a reference type)
    // - where T : struct         (T must be a value type)
    // - where T : new()          (T must have a parameterless constructor)
    // - where T : SomeClass      (T must inherit from SomeClass)
    // - where T : IComparable<T> (T must implement IComparable<T>)
    // ============================================================

    /// <summary>
    /// Exercise 205: Find the maximum value in an array.
    ///
    /// The constraint "where T : IComparable<T>" means T must implement CompareTo().
    /// Use item.CompareTo(other) which returns:
    ///   - negative if item &lt; other
    ///   - zero if item == other
    ///   - positive if item &gt; other
    /// </summary>
    public static T FindMax<T>(T[] items) where T : IComparable<T>
    {
        T max = items[0];

        foreach (T item in items)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }

    /// <summary>
    /// Exercise 206: Find the minimum value in an array.
    /// </summary>
    public static T FindMin<T>(T[] items) where T : IComparable<T>
    {
        T min = items[0];

        foreach (T item in items)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    /// <summary>
    /// Exercise 207: Check if an array is sorted in ascending order.
    ///
    /// Example: IsSorted(new[] { 1, 2, 3 }) returns true
    /// Example: IsSorted(new[] { 1, 3, 2 }) returns false
    /// Example: IsSorted(new[] { 1 }) returns true (single element is sorted)
    /// </summary>
    public static bool IsSorted<T>(T[] items) where T : IComparable<T>
    {
        for (int i = 1; i < items.Length; i++)
        {
            if (items[i - 1].CompareTo(items[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Exercise 208: Create a new instance of type T and return it.
    ///
    /// The "new()" constraint means T must have a parameterless constructor.
    /// You can then write: new T()
    /// </summary>
    public static T CreateInstance<T>() where T : new()
    {
        return new T();
    }

    // ============================================================
    // PART 3: MULTIPLE TYPE PARAMETERS
    // Generic methods can have multiple type parameters.
    //
    // Example:
    // public static TOutput Convert<TInput, TOutput>(TInput input) { ... }
    // ============================================================

    /// <summary>
    /// Exercise 209: Create a KeyValuePair from two values.
    ///
    /// KeyValuePair<TKey, TValue>; is a built-in struct with Key and Value properties.
    /// </summary>
    public static KeyValuePair<TKey, TValue> MakePair<TKey, TValue>(TKey key, TValue value)
    {
        return new KeyValuePair<TKey, TValue>(key, value);
    }

    /// <summary>
    /// Exercise 210: Transform each element in an array using a provided function.
    ///
    /// This is like LINQ's Select(), but implemented with generics.
    /// Func<TInput, TOutput>; is a delegate that takes TInput and returns TOutput.
    ///
    /// Example: Transform(new[] { 1, 2, 3 }, x => x * 2) returns [2, 4, 6]
    /// Example: Transform(new[] { 1, 2, 3 }, x => x.ToString()) returns ["1", "2", "3"]
    /// </summary>
    public static TOutput[] Transform<TInput, TOutput>(TInput[] items, Func<TInput, TOutput> transformer)
    {
        TOutput[] result = new TOutput[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            result[i] = transformer(items[i]);
        }

        return result;
    }
}

// ============================================================
// PART 4: GENERIC CLASSES
// A generic class is a blueprint that works with any type.
// The type is specified when creating an instance.
//
// Example:
// public class Box<T> { public T Value { get; set; } }
// var intBox = new Box<int> { Value = 42 };
// var stringBox = new Box<string> { Value = "hello" };
// ============================================================

/// <summary>
/// Exercise 211: Implement a generic Pair class that holds two values of potentially different types.
///
/// Usage:
/// var pair = new Pair<string, int>("age", 25);
/// Console.WriteLine(pair.First);  // "age"
/// Console.WriteLine(pair.Second); // 25
/// </summary>
public class Pair<TFirst, TSecond>
{
    // TODO: Add a constructor that takes (TFirst first, TSecond second)
    // TODO: Add properties First and Second

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    public TFirst First { get; }
    public TSecond Second { get; }
}

/// <summary>
/// Exercise 212: Implement a generic Stack (LIFO - Last In, First Out).
///
/// A stack supports:
/// - Push(item): Add an item to the top
/// - Pop(): Remove and return the top item (throw if empty)
/// - Peek(): Return the top item without removing it (throw if empty)
/// - Count: Number of items in the stack
/// - IsEmpty: True if the stack has no items
///
/// Hint: Use a List<T> internally to store the items.
/// </summary>
public class SimpleStack<T>
{
    private readonly List<T> _items = [];

    public int Count => _items.Count;

    public bool IsEmpty => _items.Count == 0;

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        T top = Peek();
        _items.RemoveAt(_items.Count - 1);
        return top;
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("It's empty.");
        }

        return _items[_items.Count - 1];
    }
}

/// <summary>
/// Exercise 213: Implement a generic Result type that represents either success or failure.
///
/// This is a common pattern for error handling without exceptions.
///
/// Usage:
/// var success = Result<int>.Ok(42);
/// var failure = Result<int>.Fail("Something went wrong");
///
/// if (success.IsSuccess) Console.WriteLine(success.Value);  // 42
/// if (failure.IsFailure) Console.WriteLine(failure.Error);  // "Something went wrong"
/// </summary>
public class Result<T>
{
    // TODO: Implement private constructor(s)
    // TODO: Implement IsSuccess, IsFailure, Value, and Error properties
    // TODO: Implement static Ok() and Fail() factory methods

    private readonly T? _value;
    private readonly string? _error;

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        _value = value;
        _error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    // Value should throw InvalidOperationException if IsFailure
    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("No value.");
            }

            return _value!;
        }
    }

    // Error should throw InvalidOperationException if IsSuccess
    public string Error
    {
        get
        {
            if (IsSuccess)
            {
                throw new InvalidOperationException("No error.");
            }

            return _error!;
        }
    }

    public static Result<T> Ok(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> Fail(string error)
    {
        return new Result<T>(false, default, error);
    }
}
