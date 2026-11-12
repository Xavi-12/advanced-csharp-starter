# 🛠️ Advanced C# Practice

In this assignment you'll practice the C# concepts from the side quest by solving a series of small coding exercises. Each exercise is verified by a unit test, so you'll know immediately whether your solution is correct.

## AI Use

🔴 **AI tools not allowed**

The goal of this assignment is for you to practice these concepts yourself. Using AI to generate solutions will leave you unprepared for the quiz and for real-world programming. Disable autocomplete in your IDE as well.

If you get stuck: re-read the course materials, check the hints in the code comments, or ask your instructor or a classmate (discuss concepts, not solutions).

## Hand-in

Submit the following via the next available **Side Quest Assignment** on the DLO:

- A .zip of your project folder with all tests passing

---

## Project Structure

```
AdvancedCsharp/
├── LinqExercises.cs              <-- LINQ exercises
├── GenericsExercises.cs          <-- Generics exercises
├── DelegatesEventsExercises.cs   <-- Delegates & Events exercises
├── RecordsStructsExercises.cs    <-- Records & Structs exercises
├── Models/
│   └── Player.cs                 <-- Data model
AdvancedCsharp.Tests/
├── LinqExercisesTests.cs
├── GenericsExercisesTests.cs
├── DelegatesEventsExercisesTests.cs
└── RecordsStructsExercisesTests.cs
```

## What Are Unit Tests?

Unit tests are small pieces of code that automatically verify your implementation is correct. Each test calls one of your methods with specific input, checks if the output matches what's expected, and reports "Pass" or "Fail". When all tests pass, you know your implementation is correct.

---

## Step 1 - Set Up the Project

Make sure you have installed:
- [.NET SDK 10.0 (LTS)](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) with the [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

Open the project folder in VS Code, then run the following in the terminal:

```bash
dotnet restore
dotnet build
```

You should see "Build succeeded" with 0 errors. Run `dotnet test` to see the full list of failing tests. Your goal is to make them all pass.

### If `dotnet test` says "Zero tests ran"

Run it with no extra flags. These projects use Microsoft.Testing.Platform (that is
what the `test` block in `global.json` selects), and `dotnet test` forwards any option
it does not recognise itself straight to the test application. The VSTest-era flags
`--nologo`, `--logger` and `--collect:` are rejected there, and a rejected argument is
reported as "Zero tests ran" with `Exit code: 5` instead of as a bad option — so it
looks like your tests vanished when in fact the run never started. `--filter`,
`--no-build`, `--list-tests` and `-v` all work as expected.

---

## Step 2 - LINQ Exercises

Open `AdvancedCsharp/LinqExercises.cs` and implement the 33 exercises:

- **Part 1-3**: `Where`, `Select`, `OrderBy` (filtering, transforming, sorting)
- **Part 4**: `First`, `FirstOrDefault` (finding single elements)
- **Part 5**: `Any`, `All` (checking conditions)
- **Part 6**: `Count`, `Sum`, `Average`, `Max` (aggregating)
- **Part 7**: `Take`, `Skip` (subsetting)
- **Part 8**: Chaining multiple operations
- **Part 9**: `Distinct`, `GroupBy`
- **Part 10**: `ToList`, `ToArray`, deferred execution
- **Bonus**: 3 challenging exercises

```bash
dotnet test --filter "Linq"
```

**Quick reference**
```csharp
player => player.IsOnline        // Single expression
(a, b) => a + b                  // Multiple parameters
```

---

## Step 3 - Generics Exercises

Open `AdvancedCsharp/GenericsExercises.cs` and implement the 13 exercises:

- **Part 1**: Generic methods (`GetLast`, `Swap`, `CreateArray`, `IndexOf`)
- **Part 2**: Constraints (`FindMax`, `FindMin`, `IsSorted` with `IComparable`)
- **Part 3**: Multiple type parameters (`MakePair`, `Transform`)
- **Part 4**: Generic classes (`Pair`, `SimpleStack`, `Result`)

```bash
dotnet test --filter "Generics"
```

**Quick reference**
```csharp
public static T GetLast<T>(T[] items)           // Generic method
public class Box<T> { public T Value; }         // Generic class
where T : IComparable<T>                        // Constraint
```

---

## Step 4 - Delegates & Events Exercises

Open `AdvancedCsharp/DelegatesEventsExercises.cs` and implement the 17 exercises:

- **Part 1**: Working with `Action` and `Func` delegates
- **Part 2**: Creating your own delegates
- **Part 3**: Filtering and processing with predicates
- **Part 4**: Classes with events (`ValuePublisher`, `CountdownTimer`, `EventTracker`)

```bash
dotnet test --filter "DelegatesEvents"
```

**Quick reference**
```csharp
Action                    // void method, no parameters
Action<int>               // void method, one int parameter
Func<int>                 // returns int, no parameters
Func<string, int>         // takes string, returns int

public event Action<int>? OnValueChanged;       // Declare event
OnValueChanged?.Invoke(42);                     // Fire event (only owner can)
publisher.OnValueChanged += HandleChange;       // Subscribe
publisher.OnValueChanged -= HandleChange;       // Unsubscribe
```

---

## Step 5 - Records & Structs Exercises

Open `AdvancedCsharp/RecordsStructsExercises.cs` and implement the 16 exercises:

- **Part 1**: Value types vs reference types
- **Part 2**: Working with structs (`Point2D` operations)
- **Part 3**: Working with records (`with` expressions, value equality)
- **Part 4**: Record structs (`GridPosition`)
- **Part 5**: Implementing your own types (`Temperature`, `Money`, `OperationResult`)

```bash
dotnet test --filter "RecordsStructs"
```

**Quick reference**
```csharp
struct Point { public int X, Y; }               // Value type (copied on assignment)
class Player { public int Score; }              // Reference type (shared reference)

record WeaponStats(int Damage, float Range);    // Immutable, value equality
var upgraded = weapon with { Damage = 50 };     // Create modified copy
```
