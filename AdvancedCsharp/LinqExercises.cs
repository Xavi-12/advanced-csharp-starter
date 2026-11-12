using AdvancedCsharp.Models;

namespace AdvancedCsharp;

/// <summary>
/// LINQ Practice Exercises
///
/// Complete each method by writing the appropriate LINQ query.
/// Don't use regular while- and for-loops.
/// Each method has a description of what it should return.
/// You completed an exercise when the related unit test(s) pass.
///
/// REMEMBER: Add "using System.Linq;" at the top of this file!
///
/// Tips:
/// - Lambda syntax: parameter => expression
/// - Example: player => player.Score > 100
/// - You can chain multiple LINQ methods: .Where(...).OrderBy(...).Take(...)
/// </summary>
public static class LinqExercises
{
    // ============================================================
    // PART 1: BASIC FILTERING WITH WHERE
    // The Where() method filters a collection based on a condition.
    // It returns all elements where the condition is true.
    //
    // For example .Where(player => player.GamesPlayed == 10)
    // ============================================================

    /// <summary>
    /// Exercise 301: Get all players who are currently online.
    ///
    /// Example: If players contains [{Name: "Alice", IsOnline: true}, {Name: "Bob", IsOnline: false}]
    /// Should return: [{Name: "Alice", IsOnline: true}]
    /// </summary>
    public static IEnumerable<Player> GetOnlinePlayers(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 302: Get all players with a score greater than the given minimum.
    /// </summary>
    public static IEnumerable<Player> GetPlayersWithScoreAbove(IEnumerable<Player> players, int minScore)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 303: Get all players who are on a specific team AND are online.
    /// </summary>
    public static IEnumerable<Player> GetOnlinePlayersOnTeam(IEnumerable<Player> players, string teamName)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 2: TRANSFORMING WITH SELECT
    // The Select() method transforms each element into something else.
    // It's like a "map" operation - apply a function to each element.
    // 
    // For example: .Select(player => player.Property)
    // ============================================================

    /// <summary>
    /// Exercise 304: Get a list of all player names.
    ///
    /// Example: If players contains [{Name: "Alice", Score: 100}, {Name: "Bob", Score: 200}]
    /// Should return: ["Alice", "Bob"]
    /// </summary>
    public static IEnumerable<string> GetPlayerNames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 305: Get a list of all player scores.
    /// </summary>
    public static IEnumerable<int> GetPlayerScores(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 306: Create a formatted string for each player showing "Name: Score"
    ///
    /// Example: If a player has Name="Alice" and Score=100
    /// Should return: "Alice: 100"
    ///
    /// Hint: Use string interpolation
    /// </summary>
    public static IEnumerable<string> GetPlayerScoreStrings(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 3: SORTING WITH ORDERBY
    // OrderBy() sorts elements in ascending order.
    // OrderByDescending() sorts in descending order.
    //
    // For example: .OrderBy(player => property)
    // ============================================================

    /// <summary>
    /// Exercise 307: Get all players sorted by their score (lowest first).
    /// </summary>
    public static IEnumerable<Player> GetPlayersSortedByScore(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 308: Get all players sorted by their score (highest first).
    /// </summary>
    public static IEnumerable<Player> GetPlayersSortedByScoreDescending(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 309: Get all players sorted alphabetically by name.
    /// </summary>
    public static IEnumerable<Player> GetPlayersSortedByName(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 4: FINDING SINGLE ELEMENTS
    // First() returns the first element (throws if empty)
    // FirstOrDefault() returns the first element or default value if empty
    // Last() / LastOrDefault() work similarly for the last element
    // ============================================================

    /// <summary>
    /// Exercise 310: Get the player with the highest score.
    /// </summary>
    public static Player? GetTopScorer(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 311: Get the first online player, or null if none are online.
    ///
    /// Hint: You can pass a lambda directly to FirstOrDefault: .FirstOrDefault(player => condition)
    /// </summary>
    public static Player? GetFirstOnlinePlayer(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 312: Get the player with the lowest score who has played at least one game.
    /// </summary>
    public static Player? GetLowestScorerWithGames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 5: CHECKING CONDITIONS WITH ANY AND ALL
    // Any() returns true if at least one element matches
    // All() returns true if every element matches
    // ============================================================

    /// <summary>
    /// Exercise 313: Check if there are any online players.
    /// </summary>
    public static bool HasOnlinePlayers(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 314: Check if any player has a score above 1000.
    /// </summary>
    public static bool HasHighScorer(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 315: Check if ALL players have played at least one game.
    /// </summary>
    public static bool AllPlayersHavePlayedGames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 316: Check if all online players have a positive score.
    /// </summary>
    public static bool AllOnlinePlayersHavePositiveScore(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 6: COUNTING AND AGGREGATING
    // Count() returns the number of elements
    // Sum() adds up all values
    // Average() returns the average value
    // Min() / Max() return the smallest/largest value
    // ============================================================

    /// <summary>
    /// Exercise 317: Count how many players are online.
    /// </summary>
    public static int CountOnlinePlayers(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 318: Get the total score of all players combined.
    /// </summary>
    public static int GetTotalScore(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 319: Get the average score of all players.
    /// Note: Returns 0 if the collection is empty (use DefaultIfEmpty)
    /// </summary>
    public static double GetAverageScore(IEnumerable<Player> players)
    {
        // Hint: Use .Average(), .Select() and .DefaultIfEmpty() in the right order
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 320: Get the highest score among all players.
    /// Note: Returns 0 if the collection is empty (use DefaultIfEmpty)
    /// </summary>
    public static int GetHighestScore(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 7: TAKE AND SKIP
    // Take(n) returns the first n elements
    // Skip(n) skips the first n elements and returns the rest
    // ============================================================

    /// <summary>
    /// Exercise 321: Get the top 3 players by score.
    /// </summary>
    public static IEnumerable<Player> GetTop3Players(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 322: Get all players except the top 3 scorers.
    /// </summary>
    public static IEnumerable<Player> GetPlayersExceptTop3(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 323: Get players ranked 4th to 6th by score.
    /// </summary>
    public static IEnumerable<Player> GetPlayersRanked4To6(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 8: CHAINING MULTIPLE OPERATIONS
    // The real power of LINQ comes from combining methods.
    // Each method returns a new collection that can be queried further.
    // ============================================================

    /// <summary>
    /// Exercise 324: Get the names of the top 5 online players by score.
    /// </summary>
    public static IEnumerable<string> GetTop5OnlinePlayerNames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 325: Get the total score of online players on a specific team.
    /// </summary>
    public static int GetTeamOnlineScore(IEnumerable<Player> players, string teamName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 326: Get the average level of the top 10 scorers.
    /// </summary>
    public static double GetAverageLevelOfTopScorers(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 9: DISTINCT AND GROUPBY
    // Distinct() removes duplicate values
    // GroupBy() groups elements by a key
    // ============================================================

    /// <summary>
    /// Exercise 327: Get a list of all unique team names.
    /// </summary>
    public static IEnumerable<string> GetAllTeamNames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 328: Get all unique levels that players have achieved and sort them in ascending order.
    /// </summary>
    public static IEnumerable<int> GetAllLevels(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 329: Count how many players are on each team.
    /// Returns a dictionary where the key is the team name and the value is the player count.
    ///
    /// Hint: Use GroupBy() to group players by team, then convert to dictionary with .ToDictionary()
    /// </summary>
    public static Dictionary<string, int> GetPlayerCountByTeam(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 330: Get the highest score for each team.
    /// Returns a dictionary where the key is the team name and the value is the highest score on that team.
    /// </summary>
    public static Dictionary<string, int> GetHighestScoreByTeam(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // PART 10: TOLIST AND IMMEDIATE EXECUTION
    // LINQ queries use "deferred execution" - they don't run until you
    // iterate over them. ToList() forces immediate execution and
    // creates a snapshot of the results.
    // ============================================================

    /// <summary>
    /// Exercise 331: Get a list (not IEnumerable) of online players.
    ///
    /// The difference: IEnumerable is lazy (executes when iterated),
    /// List is eager (executes immediately and stores results).
    /// </summary>
    public static List<Player> GetOnlinePlayersAsList(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 332: Get an array of all player names sorted alphabetically.
    /// </summary>
    public static string[] GetSortedPlayerNamesAsArray(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exercise 333: Get players with a score above the given minimum.
    ///
    /// IMPORTANT: The source collection can only be enumerated ONCE.
    /// (Imagine it's coming from a database or network stream)
    ///
    /// Your query will be iterated multiple times by the caller, so you must
    /// ensure the source is only read once by materializing the results.
    /// </summary>
    public static IEnumerable<Player> GetHighScorersSingleEnumeration(IEnumerable<Player> players, int minScore)
    {
        throw new NotImplementedException();
    }

    // ============================================================
    // BONUS CHALLENGES
    // These exercises combine multiple concepts and are more difficult.
    // ============================================================

    /// <summary>
    /// BONUS 301: Find the team with the most online players.
    /// Return the team name, or null if no players are online.
    /// </summary>
    public static string? GetTeamWithMostOnlinePlayers(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// BONUS 302: Get the names of players who have above-average scores.
    /// </summary>
    public static IEnumerable<string> GetAboveAveragePlayerNames(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// BONUS 303: For each team, get the name of their top scorer.
    /// Returns a dictionary where key is team name and value is the name of their best player.
    /// </summary>
    public static Dictionary<string, string> GetTopScorerPerTeam(IEnumerable<Player> players)
    {
        throw new NotImplementedException();
    }
}
