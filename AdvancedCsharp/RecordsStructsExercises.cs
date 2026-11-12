namespace AdvancedCsharp;

/// <summary>
/// Records, Structs, and Value Types Practice Exercises
///
/// Value Types (struct): Data is copied when assigned. Each variable has its own copy.
/// Reference Types (class): Variables hold references. Multiple variables can point to the same object.
/// Records: Immutable by default, value-based equality, support 'with' expressions.
/// </summary>
public static class RecordsStructsExercises
{
    // ============================================================
    // PART 1: UNDERSTANDING VALUE TYPES VS REFERENCE TYPES
    // ============================================================

    /// <summary>
    /// Exercise 401: Demonstrate that structs are copied.
    /// Create a copy of the point, modify the copy's X to newX, and return the copy.
    /// The original point should remain unchanged (verified by the test).
    /// </summary>
    public static Point2D ModifyPointCopy(Point2D original, int newX)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 402: Demonstrate that classes share references.
    /// Modify the player's score directly and return the same object.
    /// The test verifies that the original reference is also modified.
    /// </summary>
    public static PlayerClass ModifyPlayerScore(PlayerClass player, int newScore)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 2: WORKING WITH STRUCTS
    // ============================================================

    /// <summary>
    /// Exercise 403: Calculate the distance from the origin (0,0) to the given point.
    /// Use Math.Sqrt(x*x + y*y).
    /// </summary>
    public static double DistanceFromOrigin(Point2D point)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 404: Add two points together (component-wise addition).
    /// Return a new Point2D with X = a.X + b.X and Y = a.Y + b.Y.
    /// </summary>
    public static Point2D AddPoints(Point2D a, Point2D b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 405: Find the point closest to the origin in an array.
    /// Return default(Point2D) if the array is empty.
    /// </summary>
    public static Point2D FindClosestToOrigin(Point2D[] points)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 3: WORKING WITH RECORDS
    // ============================================================

    /// <summary>
    /// Exercise 406: Create a modified copy of a weapon using 'with'.
    /// Return a new WeaponStats with the damage changed to newDamage.
    /// </summary>
    public static WeaponStats UpgradeWeaponDamage(WeaponStats weapon, int newDamage)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 407: Check if two weapons have the same stats (value equality).
    /// Records automatically implement value-based equality.
    /// </summary>
    public static bool AreWeaponsEqual(WeaponStats a, WeaponStats b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 408: Create a copy of an item with multiple properties changed.
    /// Return a new GameItem with the given name and value, keeping the original's weight.
    /// </summary>
    public static GameItem RenameAndRevalue(GameItem item, string newName, int newValue)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 409: Find the most valuable item in an array.
    /// Return null if the array is empty.
    /// </summary>
    public static GameItem? FindMostValuable(GameItem[] items)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 410: Create a discounted copy of all items.
    /// Return a new array where each item has its Value reduced by the discount percentage.
    /// Example: 20% discount on value 100 = new value 80.
    /// </summary>
    public static GameItem[] ApplyDiscount(GameItem[] items, int discountPercent)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 4: RECORD STRUCTS
    // ============================================================

    /// <summary>
    /// Exercise 411: Calculate the Manhattan distance between two grid positions.
    /// Manhattan distance = |x1 - x2| + |y1 - y2|
    /// Use Math.Abs() for absolute value.
    /// </summary>
    public static int ManhattanDistance(GridPosition a, GridPosition b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 412: Get all grid positions adjacent to the given position (up, down, left, right).
    /// Return an array of 4 GridPosition values.
    /// </summary>
    public static GridPosition[] GetAdjacentPositions(GridPosition pos)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 413: Check if a position is within a rectangular bounds.
    /// The position is valid if X is in [0, width) and Y is in [0, height).
    /// </summary>
    public static bool IsInBounds(GridPosition pos, int width, int height)
    {
        throw new NotImplementedException();
    }
}

// ============================================================
// TYPE DEFINITIONS
// ============================================================

/// <summary>
/// A simple 2D point as a STRUCT (value type).
/// When you assign a struct to another variable, you get a copy.
/// </summary>
public struct Point2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }
}

/// <summary>
/// A player class (reference type).
/// When you assign a class to another variable, both point to the same object.
/// </summary>
public class PlayerClass
{
    public required string Name { get; set; }
    public int Score { get; set; }
}

/// <summary>
/// A record representing weapon statistics.
/// Records use positional syntax: record Name(Type Property, ...)
/// Records automatically get: constructor, equality, ToString, with-expressions.
/// </summary>
public record WeaponStats(int Damage, float Range, float FireRate);

/// <summary>
/// A record representing a game item with name, value, and weight.
/// </summary>
public record GameItem(string Name, int Value, float Weight);

/// <summary>
/// A record struct for grid coordinates.
/// Record structs combine value type semantics (copied on assignment)
/// with record features (equality, with-expressions).
/// </summary>
public record struct GridPosition(int X, int Y);

// ============================================================
// EXERCISES: IMPLEMENT YOUR OWN TYPES
// ============================================================

/// <summary>
/// Exercise 414: Implement a Temperature struct that stores a value in Celsius.
///
/// Requirements:
/// - Property: Celsius (double)
/// - Property: Fahrenheit (calculated: Celsius * 9/5 + 32)
/// - Constructor that takes celsius value
/// - Static method: FromFahrenheit(double f) that creates a Temperature from Fahrenheit
/// </summary>
public struct Temperature
{
    // TODO: Implement
    public double Celsius { get; }
    public double Fahrenheit => throw new NotImplementedException();

    public Temperature(double celsius)
    {
        throw new NotImplementedException();
    }

    public static Temperature FromFahrenheit(double fahrenheit)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Exercise 415: Implement a Money record for handling currency.
///
/// Requirements:
/// - Properties: Amount (decimal), Currency (string)
/// - Method: Add(Money other) - returns new Money with amounts added (must be same currency, throw if not)
/// - Method: ToString() - returns the amount with exactly two decimals, a space, then
///   the currency code: "1234.56 USD". Format with CultureInfo.InvariantCulture, or on
///   a Dutch-locale PC you will get "1234,56 USD" and fail the test on that one comma.
///
/// Add must leave both operands untouched and hand back a new Money. You do not write
/// any equality code: Money is a record, so two Money values with the same Amount and
/// Currency already compare as Equal.
/// </summary>
public record Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Exercise 416: Implement a Result record that represents success or failure.
///
/// This is similar to the generics exercise but using records.
/// The constructor should be private - use Ok() and Error() factory methods.
/// </summary>
public record OperationResult
{
    public bool Success { get; }
    public string? ErrorMessage { get; }

    private OperationResult(bool success, string? errorMessage)
    {
        throw new NotImplementedException();
    }

    public static OperationResult Ok()
    {
        throw new NotImplementedException();
    }

    public static OperationResult Error(string message)
    {
        throw new NotImplementedException();
    }
}
