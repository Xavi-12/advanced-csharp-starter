namespace AdvancedCsharp.Models;

/// <summary>
/// Represents a player in a game with various stats.
/// Used for practicing LINQ queries.
/// </summary>
public class Player
{
    public required string Name { get; init; }
    public required int Score { get; init; }
    public required int Level { get; init; }
    public required bool IsOnline { get; init; }
    public required string Team { get; init; }
    public required int GamesPlayed { get; init; }
}
