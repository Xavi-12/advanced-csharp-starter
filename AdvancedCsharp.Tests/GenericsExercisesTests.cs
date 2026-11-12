using AdvancedCsharp;
using AdvancedCsharp.Models;
using Xunit;

namespace AdvancedCsharp.Tests;

public class GenericsExercisesTests
{
    // ============================================================
    // PART 1: GENERIC METHODS
    // ============================================================

    [Fact]
    public void Exercise201_GetLast_WithInts_ReturnsLastInt()
    {
        var result = GenericsExercises.GetLast(new[] { 1, 2, 3, 4, 5 });
        Assert.Equal(5, result);
    }

    [Fact]
    public void Exercise201_GetLast_WithStrings_ReturnsLastString()
    {
        var result = GenericsExercises.GetLast(new[] { "apple", "banana", "cherry" });
        Assert.Equal("cherry", result);
    }

    [Fact]
    public void Exercise201_GetLast_WithPlayers_ReturnsLastPlayer()
    {
        var players = new[]
        {
            new Player { Name = "Alice", Score = 100, Level = 1, IsOnline = true, Team = "Red", GamesPlayed = 10 },
            new Player { Name = "Bob", Score = 200, Level = 2, IsOnline = false, Team = "Blue", GamesPlayed = 20 }
        };
        var result = GenericsExercises.GetLast(players);
        Assert.Equal("Bob", result.Name);
    }

    [Fact]
    public void Exercise202_Swap_WithInts_SwapsValues()
    {
        int a = 10, b = 20;
        GenericsExercises.Swap(ref a, ref b);
        Assert.Equal(20, a);
        Assert.Equal(10, b);
    }

    [Fact]
    public void Exercise202_Swap_WithStrings_SwapsValues()
    {
        string a = "hello", b = "world";
        GenericsExercises.Swap(ref a, ref b);
        Assert.Equal("world", a);
        Assert.Equal("hello", b);
    }

    [Fact]
    public void Exercise203_CreateArray_WithString_CreatesRepeatedArray()
    {
        var result = GenericsExercises.CreateArray("test", 4);
        Assert.Equal(4, result.Length);
        Assert.All(result, item => Assert.Equal("test", item));
    }

    [Fact]
    public void Exercise203_CreateArray_WithInt_CreatesRepeatedArray()
    {
        var result = GenericsExercises.CreateArray(42, 3);
        Assert.Equal(new[] { 42, 42, 42 }, result);
    }

    [Fact]
    public void Exercise203_CreateArray_WithZeroCount_ReturnsEmptyArray()
    {
        var result = GenericsExercises.CreateArray("x", 0);
        Assert.Empty(result);
    }

    [Fact]
    public void Exercise204_IndexOf_ItemExists_ReturnsIndex()
    {
        var result = GenericsExercises.IndexOf(new[] { 10, 20, 30, 40 }, 30);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Exercise204_IndexOf_ItemNotFound_ReturnsMinusOne()
    {
        var result = GenericsExercises.IndexOf(new[] { "a", "b", "c" }, "x");
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise204_IndexOf_FirstOccurrence_ReturnsFirstIndex()
    {
        var result = GenericsExercises.IndexOf(new[] { 1, 2, 3, 2, 1 }, 2);
        Assert.Equal(1, result); // First occurrence
    }

    // ============================================================
    // PART 2: GENERIC METHODS WITH CONSTRAINTS
    // ============================================================

    [Fact]
    public void Exercise205_FindMax_WithInts_ReturnsMax()
    {
        var result = GenericsExercises.FindMax(new[] { 3, 1, 4, 1, 5, 9, 2, 6 });
        Assert.Equal(9, result);
    }

    [Fact]
    public void Exercise205_FindMax_WithStrings_ReturnsMax()
    {
        var result = GenericsExercises.FindMax(new[] { "banana", "apple", "cherry" });
        Assert.Equal("cherry", result); // Alphabetically last
    }

    [Fact]
    public void Exercise205_FindMax_SingleElement_ReturnsThatElement()
    {
        var result = GenericsExercises.FindMax(new[] { 42 });
        Assert.Equal(42, result);
    }

    [Fact]
    public void Exercise206_FindMin_WithInts_ReturnsMin()
    {
        var result = GenericsExercises.FindMin(new[] { 3, 1, 4, 1, 5, 9, 2, 6 });
        Assert.Equal(1, result);
    }

    [Fact]
    public void Exercise206_FindMin_WithStrings_ReturnsMin()
    {
        var result = GenericsExercises.FindMin(new[] { "banana", "apple", "cherry" });
        Assert.Equal("apple", result); // Alphabetically first
    }

    [Fact]
    public void Exercise207_IsSorted_SortedArray_ReturnsTrue()
    {
        var result = GenericsExercises.IsSorted(new[] { 1, 2, 3, 4, 5 });
        Assert.True(result);
    }

    [Fact]
    public void Exercise207_IsSorted_UnsortedArray_ReturnsFalse()
    {
        var result = GenericsExercises.IsSorted(new[] { 1, 3, 2, 4, 5 });
        Assert.False(result);
    }

    [Fact]
    public void Exercise207_IsSorted_SingleElement_ReturnsTrue()
    {
        var result = GenericsExercises.IsSorted(new[] { 42 });
        Assert.True(result);
    }

    [Fact]
    public void Exercise207_IsSorted_EmptyArray_ReturnsTrue()
    {
        var result = GenericsExercises.IsSorted(Array.Empty<int>());
        Assert.True(result);
    }

    [Fact]
    public void Exercise207_IsSorted_WithDuplicates_ReturnsTrue()
    {
        var result = GenericsExercises.IsSorted(new[] { 1, 2, 2, 3, 3, 3 });
        Assert.True(result);
    }

    [Fact]
    public void Exercise208_CreateInstance_WithList_CreatesEmptyList()
    {
        var result = GenericsExercises.CreateInstance<List<int>>();
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Exercise208_CreateInstance_WithDictionary_CreatesEmptyDictionary()
    {
        var result = GenericsExercises.CreateInstance<Dictionary<string, int>>();
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ============================================================
    // PART 3: MULTIPLE TYPE PARAMETERS
    // ============================================================

    [Fact]
    public void Exercise209_MakePair_CreatesKeyValuePair()
    {
        var result = GenericsExercises.MakePair("name", 42);
        Assert.Equal("name", result.Key);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Exercise209_MakePair_WithDifferentTypes_Works()
    {
        var result = GenericsExercises.MakePair(1, "one");
        Assert.Equal(1, result.Key);
        Assert.Equal("one", result.Value);
    }

    [Fact]
    public void Exercise210_Transform_DoublesNumbers()
    {
        var result = GenericsExercises.Transform(new[] { 1, 2, 3 }, x => x * 2);
        Assert.Equal(new[] { 2, 4, 6 }, result);
    }

    [Fact]
    public void Exercise210_Transform_IntsToStrings()
    {
        var result = GenericsExercises.Transform(new[] { 1, 2, 3 }, x => x.ToString());
        Assert.Equal(new[] { "1", "2", "3" }, result);
    }

    [Fact]
    public void Exercise210_Transform_StringsToLengths()
    {
        var result = GenericsExercises.Transform(new[] { "a", "bb", "ccc" }, s => s.Length);
        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void Exercise210_Transform_EmptyArray_ReturnsEmptyArray()
    {
        var result = GenericsExercises.Transform(Array.Empty<int>(), x => x * 2);
        Assert.Empty(result);
    }

    // ============================================================
    // PART 4: GENERIC CLASSES
    // ============================================================

    [Fact]
    public void Exercise211_Pair_StoresTwoValues()
    {
        var pair = new Pair<string, int>("score", 100);
        Assert.Equal("score", pair.First);
        Assert.Equal(100, pair.Second);
    }

    [Fact]
    public void Exercise211_Pair_WorksWithSameType()
    {
        var pair = new Pair<string, string>("hello", "world");
        Assert.Equal("hello", pair.First);
        Assert.Equal("world", pair.Second);
    }

    [Fact]
    public void Exercise212_SimpleStack_PushAndPop()
    {
        var stack = new SimpleStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
    }

    [Fact]
    public void Exercise212_SimpleStack_Count()
    {
        var stack = new SimpleStack<string>();
        Assert.Equal(0, stack.Count);

        stack.Push("a");
        Assert.Equal(1, stack.Count);

        stack.Push("b");
        Assert.Equal(2, stack.Count);

        stack.Pop();
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Exercise212_SimpleStack_IsEmpty()
    {
        var stack = new SimpleStack<int>();
        Assert.True(stack.IsEmpty);

        stack.Push(1);
        Assert.False(stack.IsEmpty);

        stack.Pop();
        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Exercise212_SimpleStack_Peek_ReturnsTopWithoutRemoving()
    {
        var stack = new SimpleStack<int>();
        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
        Assert.Equal(20, stack.Peek()); // Still 20, not removed
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Exercise212_SimpleStack_PopEmpty_Throws()
    {
        var stack = new SimpleStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Exercise212_SimpleStack_PeekEmpty_Throws()
    {
        var stack = new SimpleStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Exercise213_Result_OkResult_HasValue()
    {
        var result = Result<int>.Ok(42);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Exercise213_Result_FailResult_HasError()
    {
        var result = Result<int>.Fail("Something went wrong");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal("Something went wrong", result.Error);
    }

    [Fact]
    public void Exercise213_Result_AccessingValueOnFailure_Throws()
    {
        var result = Result<int>.Fail("error");
        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }

    [Fact]
    public void Exercise213_Result_AccessingErrorOnSuccess_Throws()
    {
        var result = Result<int>.Ok(42);
        Assert.Throws<InvalidOperationException>(() => _ = result.Error);
    }

    [Fact]
    public void Exercise213_Result_WorksWithReferenceTypes()
    {
        var success = Result<string>.Ok("hello");
        var failure = Result<string>.Fail("error");

        Assert.Equal("hello", success.Value);
        Assert.Equal("error", failure.Error);
    }
}
