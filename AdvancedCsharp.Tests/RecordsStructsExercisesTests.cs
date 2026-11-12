using AdvancedCsharp;
using Xunit;

namespace AdvancedCsharp.Tests;

public class RecordsStructsExercisesTests
{
    // ============================================================
    // PART 1: VALUE TYPES VS REFERENCE TYPES
    // ============================================================

    [Fact]
    public void Exercise401_ModifyPointCopy_OriginalUnchanged()
    {
        var original = new Point2D(10, 20);
        var modified = RecordsStructsExercises.ModifyPointCopy(original, 99);

        Assert.Equal(10, original.X); // Original should be unchanged
        Assert.Equal(99, modified.X); // Copy should have new value
        Assert.Equal(20, modified.Y); // Y should be same
    }

    [Fact]
    public void Exercise402_ModifyPlayerScore_OriginalChanged()
    {
        var player = new PlayerClass { Name = "Alice", Score = 100 };
        var returned = RecordsStructsExercises.ModifyPlayerScore(player, 500);

        Assert.Equal(500, player.Score);    // Original is modified (reference type)
        Assert.Same(player, returned);       // Same object returned
    }

    // ============================================================
    // PART 2: WORKING WITH STRUCTS
    // ============================================================

    [Fact]
    public void Exercise403_DistanceFromOrigin_CalculatesCorrectly()
    {
        var point = new Point2D(3, 4);
        var distance = RecordsStructsExercises.DistanceFromOrigin(point);

        Assert.Equal(5.0, distance, precision: 5); // 3-4-5 triangle
    }

    [Fact]
    public void Exercise403_DistanceFromOrigin_AtOrigin()
    {
        var point = new Point2D(0, 0);
        var distance = RecordsStructsExercises.DistanceFromOrigin(point);

        Assert.Equal(0.0, distance);
    }

    [Fact]
    public void Exercise404_AddPoints_AddsComponents()
    {
        var a = new Point2D(1, 2);
        var b = new Point2D(3, 4);
        var result = RecordsStructsExercises.AddPoints(a, b);

        Assert.Equal(4, result.X);
        Assert.Equal(6, result.Y);
    }

    [Fact]
    public void Exercise404_AddPoints_WithNegatives()
    {
        var a = new Point2D(5, 5);
        var b = new Point2D(-3, -2);
        var result = RecordsStructsExercises.AddPoints(a, b);

        Assert.Equal(2, result.X);
        Assert.Equal(3, result.Y);
    }

    [Fact]
    public void Exercise405_FindClosestToOrigin_FindsClosest()
    {
        var points = new[]
        {
            new Point2D(10, 10),
            new Point2D(1, 1),    // Closest (distance ~1.41)
            new Point2D(5, 5),
        };

        var closest = RecordsStructsExercises.FindClosestToOrigin(points);

        Assert.Equal(1, closest.X);
        Assert.Equal(1, closest.Y);
    }

    [Fact]
    public void Exercise405_FindClosestToOrigin_EmptyArray()
    {
        var points = Array.Empty<Point2D>();
        var closest = RecordsStructsExercises.FindClosestToOrigin(points);

        Assert.Equal(default(Point2D), closest);
    }

    // ============================================================
    // PART 3: WORKING WITH RECORDS
    // ============================================================

    [Fact]
    public void Exercise406_UpgradeWeaponDamage_CreatesNewWithDamage()
    {
        var original = new WeaponStats(10, 5.0f, 1.0f);
        var upgraded = RecordsStructsExercises.UpgradeWeaponDamage(original, 25);

        Assert.Equal(10, original.Damage);  // Original unchanged
        Assert.Equal(25, upgraded.Damage);  // New has upgraded damage
        Assert.Equal(5.0f, upgraded.Range); // Other properties same
        Assert.Equal(1.0f, upgraded.FireRate);
    }

    [Fact]
    public void Exercise407_AreWeaponsEqual_SameStats_ReturnsTrue()
    {
        var a = new WeaponStats(10, 5.0f, 1.0f);
        var b = new WeaponStats(10, 5.0f, 1.0f);

        Assert.True(RecordsStructsExercises.AreWeaponsEqual(a, b));
    }

    [Fact]
    public void Exercise407_AreWeaponsEqual_DifferentStats_ReturnsFalse()
    {
        var a = new WeaponStats(10, 5.0f, 1.0f);
        var b = new WeaponStats(20, 5.0f, 1.0f);

        Assert.False(RecordsStructsExercises.AreWeaponsEqual(a, b));
    }

    [Fact]
    public void Exercise408_RenameAndRevalue_ChangesNameAndValue()
    {
        var original = new GameItem("Old Sword", 100, 5.0f);
        var modified = RecordsStructsExercises.RenameAndRevalue(original, "Epic Sword", 500);

        Assert.Equal("Old Sword", original.Name);  // Original unchanged
        Assert.Equal("Epic Sword", modified.Name);
        Assert.Equal(500, modified.Value);
        Assert.Equal(5.0f, modified.Weight);       // Weight preserved
    }

    [Fact]
    public void Exercise409_FindMostValuable_FindsHighestValue()
    {
        var items = new[]
        {
            new GameItem("Bronze", 50, 1.0f),
            new GameItem("Gold", 500, 2.0f),
            new GameItem("Silver", 200, 1.5f),
        };

        var result = RecordsStructsExercises.FindMostValuable(items);

        Assert.NotNull(result);
        Assert.Equal("Gold", result.Name);
    }

    [Fact]
    public void Exercise409_FindMostValuable_EmptyArray_ReturnsNull()
    {
        var items = Array.Empty<GameItem>();
        var result = RecordsStructsExercises.FindMostValuable(items);

        Assert.Null(result);
    }

    [Fact]
    public void Exercise410_ApplyDiscount_ReducesPrices()
    {
        var items = new[]
        {
            new GameItem("Item1", 100, 1.0f),
            new GameItem("Item2", 200, 2.0f),
        };

        var discounted = RecordsStructsExercises.ApplyDiscount(items, 20); // 20% off

        Assert.Equal(80, discounted[0].Value);
        Assert.Equal(160, discounted[1].Value);
        Assert.Equal("Item1", discounted[0].Name); // Names preserved
    }

    [Fact]
    public void Exercise410_ApplyDiscount_OriginalUnchanged()
    {
        var items = new[] { new GameItem("Sword", 100, 1.0f) };
        RecordsStructsExercises.ApplyDiscount(items, 50);

        Assert.Equal(100, items[0].Value); // Original unchanged
    }

    // ============================================================
    // PART 4: RECORD STRUCTS
    // ============================================================

    [Fact]
    public void Exercise411_ManhattanDistance_Calculates()
    {
        var a = new GridPosition(1, 2);
        var b = new GridPosition(4, 6);

        var distance = RecordsStructsExercises.ManhattanDistance(a, b);

        Assert.Equal(7, distance); // |4-1| + |6-2| = 3 + 4 = 7
    }

    [Fact]
    public void Exercise411_ManhattanDistance_SamePosition()
    {
        var a = new GridPosition(5, 5);
        var b = new GridPosition(5, 5);

        Assert.Equal(0, RecordsStructsExercises.ManhattanDistance(a, b));
    }

    [Fact]
    public void Exercise412_GetAdjacentPositions_Returns4Neighbors()
    {
        var pos = new GridPosition(5, 5);
        var adjacent = RecordsStructsExercises.GetAdjacentPositions(pos);

        Assert.Equal(4, adjacent.Length);
        Assert.Contains(new GridPosition(5, 4), adjacent); // Up
        Assert.Contains(new GridPosition(5, 6), adjacent); // Down
        Assert.Contains(new GridPosition(4, 5), adjacent); // Left
        Assert.Contains(new GridPosition(6, 5), adjacent); // Right
    }

    [Fact]
    public void Exercise413_IsInBounds_InsideBounds()
    {
        var pos = new GridPosition(3, 4);

        Assert.True(RecordsStructsExercises.IsInBounds(pos, 10, 10));
    }

    [Fact]
    public void Exercise413_IsInBounds_OnEdge()
    {
        Assert.True(RecordsStructsExercises.IsInBounds(new GridPosition(0, 0), 10, 10));
        Assert.False(RecordsStructsExercises.IsInBounds(new GridPosition(10, 10), 10, 10)); // At width/height
    }

    [Fact]
    public void Exercise413_IsInBounds_OutsideBounds()
    {
        Assert.False(RecordsStructsExercises.IsInBounds(new GridPosition(-1, 5), 10, 10));
        Assert.False(RecordsStructsExercises.IsInBounds(new GridPosition(5, -1), 10, 10));
        Assert.False(RecordsStructsExercises.IsInBounds(new GridPosition(15, 5), 10, 10));
    }

    // ============================================================
    // IMPLEMENT YOUR OWN TYPES
    // ============================================================

    [Fact]
    public void Exercise414_Temperature_Celsius()
    {
        var temp = new Temperature(100);

        Assert.Equal(100, temp.Celsius);
    }

    [Fact]
    public void Exercise414_Temperature_Fahrenheit()
    {
        var temp = new Temperature(0);
        Assert.Equal(32, temp.Fahrenheit, precision: 1);

        var boiling = new Temperature(100);
        Assert.Equal(212, boiling.Fahrenheit, precision: 1);
    }

    [Fact]
    public void Exercise414_Temperature_FromFahrenheit()
    {
        var temp = Temperature.FromFahrenheit(32);
        Assert.Equal(0, temp.Celsius, precision: 1);

        var hot = Temperature.FromFahrenheit(212);
        Assert.Equal(100, hot.Celsius, precision: 1);
    }

    [Fact]
    public void Exercise415_Money_Add_SameCurrency()
    {
        var a = new Money(100.50m, "USD");
        var b = new Money(50.25m, "USD");
        var result = a.Add(b);

        Assert.Equal(150.75m, result.Amount);
        Assert.Equal("USD", result.Currency);
    }

    [Fact]
    public void Exercise415_Money_Add_DifferentCurrency_Throws()
    {
        var usd = new Money(100m, "USD");
        var eur = new Money(50m, "EUR");

        Assert.Throws<InvalidOperationException>(() => usd.Add(eur));
    }

    [Fact]
    public void Exercise415_Money_ToString()
    {
        var money = new Money(1234.56m, "USD");

        Assert.Equal("1234.56 USD", money.ToString());
    }

    [Fact]
    public void Exercise415_Money_Equality()
    {
        var a = new Money(100.50m, "USD");
        var b = new Money(50.25m, "USD");
        var sum = a.Add(b);

        // Money is a record, so you get value equality for free: a Money you build
        // yourself is Equal to one Add produced, as long as both fields match.
        Assert.Equal(new Money(150.75m, "USD"), sum);
        Assert.NotEqual(new Money(150.75m, "EUR"), sum);

        // Add must return a *new* Money. If it mutated its operands instead, these
        // two would no longer hold.
        Assert.Equal(new Money(100.50m, "USD"), a);
        Assert.Equal(new Money(50.25m, "USD"), b);
    }

    [Fact]
    public void Exercise416_OperationResult_Ok()
    {
        var result = OperationResult.Ok();

        Assert.True(result.Success);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void Exercise416_OperationResult_Error()
    {
        var result = OperationResult.Error("Something went wrong");

        Assert.False(result.Success);
        Assert.Equal("Something went wrong", result.ErrorMessage);
    }

    [Fact]
    public void Exercise416_OperationResult_Equality()
    {
        var ok1 = OperationResult.Ok();
        var ok2 = OperationResult.Ok();
        var error = OperationResult.Error("error");

        Assert.Equal(ok1, ok2);
        Assert.NotEqual(ok1, error);
    }
}
