using AdvancedCsharp;
using Xunit;

namespace AdvancedCsharp.Tests;

public class DelegatesEventsExercisesTests
{
    // ============================================================
    // PART 1: WORKING WITH DELEGATES
    // ============================================================

    [Fact]
    public void Exercise101_ExecuteAction_CallsTheAction()
    {
        bool wasCalled = false;
        DelegatesEventsExercises.ExecuteAction(() => wasCalled = true);
        Assert.True(wasCalled);
    }

    [Fact]
    public void Exercise102_ExecuteActionWithValue_PassesValue()
    {
        int receivedValue = 0;
        DelegatesEventsExercises.ExecuteActionWithValue(v => receivedValue = v, 42);
        Assert.Equal(42, receivedValue);
    }

    [Fact]
    public void Exercise103_ExecuteFunc_ReturnsResult()
    {
        var result = DelegatesEventsExercises.ExecuteFunc(() => 123);
        Assert.Equal(123, result);
    }

    [Fact]
    public void Exercise104_Transform_AppliesFunction()
    {
        var result = DelegatesEventsExercises.Transform(5, x => x * 2);
        Assert.Equal(10, result);
    }

    [Fact]
    public void Exercise104_Transform_WorksWithDifferentTypes()
    {
        var result = DelegatesEventsExercises.Transform(42, x => x.ToString());
        Assert.Equal("42", result);
    }

    [Fact]
    public void Exercise105_ExecuteIfNotNull_CallsWhenNotNull()
    {
        bool wasCalled = false;
        DelegatesEventsExercises.ExecuteIfNotNull(() => wasCalled = true);
        Assert.True(wasCalled);
    }

    [Fact]
    public void Exercise105_ExecuteIfNotNull_DoesNothingWhenNull()
    {
        // Should not throw
        DelegatesEventsExercises.ExecuteIfNotNull(null);
    }

    // ============================================================
    // PART 2: CREATING AND USING DELEGATES
    // ============================================================

    [Fact]
    public void Exercise106_CreateIncrementAction_IncrementsCounter()
    {
        var counter = new Counter { Value = 0 };
        var increment = DelegatesEventsExercises.CreateIncrementAction(counter);

        increment();
        Assert.Equal(1, counter.Value);

        increment();
        increment();
        Assert.Equal(3, counter.Value);
    }

    [Fact]
    public void Exercise107_CreateAddFunc_AddsTwoNumbers()
    {
        var add = DelegatesEventsExercises.CreateAddFunc();

        Assert.Equal(5, add(2, 3));
        Assert.Equal(0, add(-5, 5));
        Assert.Equal(100, add(40, 60));
    }

    [Fact]
    public void Exercise108_CreateIsPositiveFunc_ChecksPositive()
    {
        var isPositive = DelegatesEventsExercises.CreateIsPositiveFunc();

        Assert.True(isPositive(1));
        Assert.True(isPositive(100));
        Assert.False(isPositive(0));
        Assert.False(isPositive(-5));
    }

    [Fact]
    public void Exercise109_CombineActions_ExecutesBoth()
    {
        var results = new List<string>();
        var combined = DelegatesEventsExercises.CombineActions(
            () => results.Add("first"),
            () => results.Add("second")
        );

        combined();

        Assert.Equal(2, results.Count);
        Assert.Equal("first", results[0]);
        Assert.Equal("second", results[1]);
    }

    // ============================================================
    // PART 3: FILTERING AND PROCESSING WITH DELEGATES
    // ============================================================

    [Fact]
    public void Exercise110_Filter_ReturnsMatchingItems()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6 };
        var evens = DelegatesEventsExercises.Filter(numbers, n => n % 2 == 0);

        Assert.Equal(new[] { 2, 4, 6 }, evens);
    }

    [Fact]
    public void Exercise110_Filter_EmptyResult()
    {
        var numbers = new[] { 1, 3, 5 };
        var evens = DelegatesEventsExercises.Filter(numbers, n => n % 2 == 0);

        Assert.Empty(evens);
    }

    [Fact]
    public void Exercise110_Filter_WorksWithStrings()
    {
        var words = new[] { "apple", "banana", "apricot", "cherry" };
        var aWords = DelegatesEventsExercises.Filter(words, w => w.StartsWith("a"));

        Assert.Equal(new[] { "apple", "apricot" }, aWords);
    }

    [Fact]
    public void Exercise111_ForEach_AppliesActionToEach()
    {
        var numbers = new[] { 1, 2, 3 };
        var results = new List<int>();

        DelegatesEventsExercises.ForEach(numbers, n => results.Add(n * 10));

        Assert.Equal(new[] { 10, 20, 30 }, results);
    }

    [Fact]
    public void Exercise112_FindFirst_ReturnsFirstMatch()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var result = DelegatesEventsExercises.FindFirst(numbers, n => n > 3);

        Assert.Equal(4, result);
    }

    [Fact]
    public void Exercise112_FindFirst_ReturnsDefaultWhenNoMatch()
    {
        var numbers = new[] { 1, 2, 3 };
        var result = DelegatesEventsExercises.FindFirst(numbers, n => n > 10);

        Assert.Equal(0, result); // default(int)
    }

    [Fact]
    public void Exercise112_FindFirst_WorksWithReferenceTypes()
    {
        var words = new[] { "short", "longer", "longest" };
        var result = DelegatesEventsExercises.FindFirst(words, w => w.Length > 5);

        Assert.Equal("longer", result);
    }

    [Fact]
    public void Exercise113_CountWhere_CountsMatches()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var count = DelegatesEventsExercises.CountWhere(numbers, n => n % 2 == 0);

        Assert.Equal(5, count);
    }

    [Fact]
    public void Exercise113_CountWhere_ZeroMatches()
    {
        var numbers = new[] { 1, 3, 5, 7 };
        var count = DelegatesEventsExercises.CountWhere(numbers, n => n % 2 == 0);

        Assert.Equal(0, count);
    }

    // ============================================================
    // PART 4: CLASSES WITH EVENTS
    // ============================================================

    [Fact]
    public void Exercise114_ValuePublisher_FiresEventOnChange()
    {
        var publisher = new ValuePublisher();
        var receivedValues = new List<int>();

        publisher.OnValueChanged += v => receivedValues.Add(v);

        publisher.Value = 10;
        publisher.Value = 20;
        publisher.Value = 30;

        Assert.Equal(new[] { 10, 20, 30 }, receivedValues);
    }

    [Fact]
    public void Exercise114_ValuePublisher_NoSubscribers_DoesNotThrow()
    {
        var publisher = new ValuePublisher();
        publisher.Value = 42; // Should not throw even without subscribers
        Assert.Equal(42, publisher.Value);
    }

    [Fact]
    public void Exercise115_CountdownTimer_FiresTickEvents()
    {
        var timer = new CountdownTimer();
        var ticks = new List<int>();

        timer.OnTick += t => ticks.Add(t);
        timer.Start(5);

        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, ticks);
    }

    [Fact]
    public void Exercise115_CountdownTimer_FiresCompleteEvent()
    {
        var timer = new CountdownTimer();
        bool completed = false;

        timer.OnComplete += () => completed = true;
        timer.Start(3);

        Assert.True(completed);
    }

    [Fact]
    public void Exercise115_CountdownTimer_TickBeforeComplete()
    {
        var timer = new CountdownTimer();
        var events = new List<string>();

        timer.OnTick += t => events.Add($"tick:{t}");
        timer.OnComplete += () => events.Add("complete");
        timer.Start(2);

        Assert.Equal(new[] { "tick:2", "tick:1", "complete" }, events);
    }

    [Fact]
    public void Exercise116_NotifyingCalculator_Add()
    {
        var calc = new NotifyingCalculator();
        string? notification = null;

        calc.OnCalculation += msg => notification = msg;
        var result = calc.Add(5, 3);

        Assert.Equal(8, result);
        Assert.Equal("5 + 3 = 8", notification);
    }

    [Fact]
    public void Exercise116_NotifyingCalculator_Subtract()
    {
        var calc = new NotifyingCalculator();
        string? notification = null;

        calc.OnCalculation += msg => notification = msg;
        var result = calc.Subtract(10, 4);

        Assert.Equal(6, result);
        Assert.Equal("10 - 4 = 6", notification);
    }

    [Fact]
    public void Exercise116_NotifyingCalculator_Multiply()
    {
        var calc = new NotifyingCalculator();
        string? notification = null;

        calc.OnCalculation += msg => notification = msg;
        var result = calc.Multiply(6, 7);

        Assert.Equal(42, result);
        Assert.Equal("6 * 7 = 42", notification);
    }

    [Fact]
    public void Exercise117_EventTracker_TracksEventCount()
    {
        var publisher = new ValuePublisher();
        var tracker = new EventTracker();

        tracker.SubscribeToValueChanged(publisher);

        publisher.Value = 1;
        publisher.Value = 2;
        publisher.Value = 3;

        Assert.Equal(3, tracker.EventsFired);
    }

    [Fact]
    public void Exercise117_EventTracker_Unsubscribe_StopsTracking()
    {
        var publisher = new ValuePublisher();
        var tracker = new EventTracker();

        tracker.SubscribeToValueChanged(publisher);
        publisher.Value = 1;
        publisher.Value = 2;

        tracker.Unsubscribe();
        publisher.Value = 3; // Should not increment

        Assert.Equal(2, tracker.EventsFired);
    }

    [Fact]
    public void Exercise117_EventTracker_MultipleTrackers()
    {
        var publisher = new ValuePublisher();
        var tracker1 = new EventTracker();
        var tracker2 = new EventTracker();

        tracker1.SubscribeToValueChanged(publisher);
        tracker2.SubscribeToValueChanged(publisher);

        publisher.Value = 42;

        Assert.Equal(1, tracker1.EventsFired);
        Assert.Equal(1, tracker2.EventsFired);
    }
}
