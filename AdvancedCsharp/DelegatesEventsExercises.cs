namespace AdvancedCsharp;

/// <summary>
/// Delegates and Events Practice Exercises
///
/// A delegate is a type that holds a reference to a method.
/// An event is a delegate with restricted access (subscribers can only += and -=).
///
/// Built-in delegate types:
/// - Action               : void method with no parameters
/// - Action<T>;           : void method with one parameter
/// - Action<T1, T2>;      : void method with two parameters
/// - Func<TResult>;       : method that returns TResult, no parameters
/// - Func<T, TResult>;    : method that takes T and returns TResult
/// </summary>
public static class DelegatesEventsExercises
{
    // ============================================================
    // PART 1: WORKING WITH DELEGATES
    // ============================================================

    /// <summary>
    /// Exercise 101: Execute an action.
    /// Call the provided action delegate.
    /// </summary>
    public static void ExecuteAction(Action action)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 102: Execute an action with a parameter.
    /// Call the provided action with the given value.
    /// </summary>
    public static void ExecuteActionWithValue(Action<int> action, int value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 103: Execute a function and return its result.
    /// Call the provided func and return what it returns.
    /// </summary>
    public static int ExecuteFunc(Func<int> func)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 104: Transform a value using a function.
    /// Apply the transformer function to the input and return the result.
    /// </summary>
    public static TOutput Transform<TInput, TOutput>(TInput input, Func<TInput, TOutput> transformer)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 105: Execute an action only if it's not null.
    /// Use the null-conditional operator.
    /// </summary>
    public static void ExecuteIfNotNull(Action? action)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 2: CREATING AND USING DELEGATES
    // ============================================================

    /// <summary>
    /// Exercise 106: Create and return an Action that increments the counter.
    /// The returned action should add 1 to counter.Value each time it's called.
    /// </summary>
    public static Action CreateIncrementAction(Counter counter)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 107: Create and return a Func that calculates the sum of two integers.
    /// </summary>
    public static Func<int, int, int> CreateAddFunc()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 108: Create a Func that checks if a number is positive.
    /// Should return true if the number is greater than zero.
    /// </summary>
    public static Func<int, bool> CreateIsPositiveFunc()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 109: Combine two actions into one that executes both.
    /// Return a new action that calls first, then second.
    /// </summary>
    public static Action CombineActions(Action first, Action second)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 3: FILTERING AND PROCESSING WITH DELEGATES
    // ============================================================

    /// <summary>
    /// Exercise 110: Filter an array using a predicate.
    /// Return all items where the predicate returns true.
    /// (This is basically implementing Where without using LINQ)
    /// </summary>
    public static T[] Filter<T>(T[] items, Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 111: Apply an action to each item in an array.
    /// (This is basically implementing ForEach)
    /// </summary>
    public static void ForEach<T>(T[] items, Action<T> action)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 112: Find the first item matching a predicate, or return default.
    /// </summary>
    public static T? FindFirst<T>(T[] items, Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 113: Count how many items match a predicate.
    /// </summary>
    public static int CountWhere<T>(T[] items, Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }
}

// ============================================================
// PART 4: CLASSES WITH EVENTS
// ============================================================

/// <summary>
/// Helper class for Exercise 6.
/// </summary>
public class Counter
{
    public int Value { get; set; }
}

/// <summary>
/// Exercise 114: Implement a simple event publisher.
///
/// This class should:
/// - Have an event called OnValueChanged of type Action&lt;int&gt;
/// - When Value is set, invoke the event with the new value (if there are subscribers)
/// </summary>
public class ValuePublisher
{
    private int _value;

    public event Action<int>? OnValueChanged;

    public int Value
    {
        get => _value;
        set
        {
            // TODO: Set _value and invoke OnValueChanged with the new value
            throw new NotImplementedException();
        }
    }
}

/// <summary>
/// Exercise 115: Implement a countdown timer that fires events.
///
/// The Start(int from) method should:
/// 1. Fire OnTick for each number from 'from' down to 1
/// 2. Fire OnComplete when the countdown finishes
/// </summary>
public class CountdownTimer
{
    public event Action<int>? OnTick;
    public event Action? OnComplete;

    public void Start(int from)
    {
        // TODO: Fire OnTick for each number (from, from-1, ..., 1)
        // TODO: Fire OnComplete at the end
        throw new NotImplementedException();
    }
}

/// <summary>
/// Exercise 116: Implement a calculator that notifies subscribers of operations.
///
/// Each operation should:
/// 1. Perform the calculation
/// 2. Fire OnCalculation with a description (e.g., "5 + 3 = 8")
/// 3. Return the result
/// </summary>
public class NotifyingCalculator
{
    public event Action<string>? OnCalculation;

    public int Add(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Subtract(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Multiply(int a, int b)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Exercise 117: Implement event subscription tracking.
///
/// This class tracks how many times events have been fired.
/// - SubscribeToValueChanged: subscribes to publisher.OnValueChanged and increments EventsFired each time
/// - Unsubscribe: removes the subscription
/// </summary>
public class EventTracker
{
    private Action<int>? _handler;
    private ValuePublisher? _publisher;

    public int EventsFired { get; private set; }

    public void SubscribeToValueChanged(ValuePublisher publisher)
    {
        // TODO: Create a handler that increments EventsFired
        // TODO: Subscribe to publisher.OnValueChanged
        // TODO: Store references so we can unsubscribe later
        throw new NotImplementedException();
    }

    public void Unsubscribe()
    {
        // TODO: Unsubscribe from the publisher's event
        throw new NotImplementedException();
    }
}
