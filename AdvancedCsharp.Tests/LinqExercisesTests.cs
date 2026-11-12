using AdvancedCsharp;
using AdvancedCsharp.Models;
using Xunit;

namespace AdvancedCsharp.Tests;

public class LinqExercisesTests
{
    // Test data that simulates a multiplayer game scenario
    private readonly List<Player> _players =
    [
        new Player { Name = "Alice", Score = 1500, Level = 25, IsOnline = true, Team = "Red", GamesPlayed = 100 },
        new Player { Name = "Bob", Score = 800, Level = 15, IsOnline = false, Team = "Blue", GamesPlayed = 50 },
        new Player { Name = "Charlie", Score = 2200, Level = 30, IsOnline = true, Team = "Red", GamesPlayed = 150 },
        new Player { Name = "Diana", Score = 950, Level = 18, IsOnline = true, Team = "Blue", GamesPlayed = 75 },
        new Player { Name = "Eve", Score = 1100, Level = 20, IsOnline = false, Team = "Green", GamesPlayed = 80 },
        new Player { Name = "Frank", Score = 600, Level = 12, IsOnline = true, Team = "Green", GamesPlayed = 30 },
        new Player { Name = "Grace", Score = 1800, Level = 28, IsOnline = false, Team = "Red", GamesPlayed = 120 },
        new Player { Name = "Henry", Score = 450, Level = 8, IsOnline = true, Team = "Blue", GamesPlayed = 20 },
        new Player { Name = "Ivy", Score = 3000, Level = 35, IsOnline = true, Team = "Green", GamesPlayed = 200 },
        new Player { Name = "Jack", Score = 750, Level = 14, IsOnline = false, Team = "Red", GamesPlayed = 45 }
    ];

    // ============================================================
    // PART 1: BASIC FILTERING WITH WHERE
    // ============================================================

    [Fact]
    public void Exercise301_GetOnlinePlayers_ReturnsOnlyOnlinePlayers()
    {
        var result = LinqExercises.GetOnlinePlayers(_players).ToList();

        Assert.Equal(6, result.Count);
        Assert.All(result, player => Assert.True(player.IsOnline));
        Assert.Contains(result, p => p.Name == "Alice");
        Assert.Contains(result, p => p.Name == "Charlie");
        Assert.Contains(result, p => p.Name == "Diana");
        Assert.Contains(result, p => p.Name == "Frank");
        Assert.Contains(result, p => p.Name == "Henry");
        Assert.Contains(result, p => p.Name == "Ivy");
    }

    [Fact]
    public void Exercise301_GetOnlinePlayers_EmptyList_ReturnsEmpty()
    {
        var result = LinqExercises.GetOnlinePlayers([]);

        Assert.Empty(result);
    }

    [Fact]
    public void Exercise302_GetPlayersWithScoreAbove_ReturnsCorrectPlayers()
    {
        var result = LinqExercises.GetPlayersWithScoreAbove(_players, 1000).ToList();

        Assert.Equal(5, result.Count);
        Assert.All(result, player => Assert.True(player.Score > 1000));
        Assert.Contains(result, p => p.Name == "Alice");
        Assert.Contains(result, p => p.Name == "Charlie");
        Assert.Contains(result, p => p.Name == "Eve");
        Assert.Contains(result, p => p.Name == "Grace");
        Assert.Contains(result, p => p.Name == "Ivy");
    }

    [Fact]
    public void Exercise302_GetPlayersWithScoreAbove_HighThreshold_ReturnsEmpty()
    {
        var result = LinqExercises.GetPlayersWithScoreAbove(_players, 5000);

        Assert.Empty(result);
    }

    [Fact]
    public void Exercise303_GetOnlinePlayersOnTeam_ReturnsCorrectPlayers()
    {
        var result = LinqExercises.GetOnlinePlayersOnTeam(_players, "Red").ToList();

        Assert.Equal(2, result.Count);
        Assert.All(result, p => Assert.True(p.IsOnline && p.Team == "Red"));
        Assert.Contains(result, p => p.Name == "Alice");
        Assert.Contains(result, p => p.Name == "Charlie");
    }

    [Fact]
    public void Exercise303_GetOnlinePlayersOnTeam_NoOnlineOnTeam_ReturnsEmpty()
    {
        // All Red players except Alice and Charlie are offline
        var playersWithNoOnlineRed = _players.Where(p => p.Team != "Red" || !p.IsOnline).ToList();
        var result = LinqExercises.GetOnlinePlayersOnTeam(playersWithNoOnlineRed, "Red");

        Assert.Empty(result);
    }

    // ============================================================
    // PART 2: TRANSFORMING WITH SELECT
    // ============================================================

    [Fact]
    public void Exercise304_GetPlayerNames_ReturnsAllNames()
    {
        var result = LinqExercises.GetPlayerNames(_players).ToList();

        Assert.Equal(10, result.Count);
        Assert.Contains("Alice", result);
        Assert.Contains("Bob", result);
        Assert.Contains("Ivy", result);
    }

    [Fact]
    public void Exercise305_GetPlayerScores_ReturnsAllScores()
    {
        var result = LinqExercises.GetPlayerScores(_players).ToList();

        Assert.Equal(10, result.Count);
        Assert.Contains(1500, result);
        Assert.Contains(3000, result);
        Assert.Contains(450, result);
    }

    [Fact]
    public void Exercise306_GetPlayerScoreStrings_ReturnsFormattedStrings()
    {
        var result = LinqExercises.GetPlayerScoreStrings(_players).ToList();

        Assert.Equal(10, result.Count);
        Assert.Contains("Alice: 1500", result);
        Assert.Contains("Ivy: 3000", result);
        Assert.Contains("Henry: 450", result);
    }

    // ============================================================
    // PART 3: SORTING WITH ORDERBY
    // ============================================================

    [Fact]
    public void Exercise307_GetPlayersSortedByScore_SortsAscending()
    {
        var result = LinqExercises.GetPlayersSortedByScore(_players).ToList();

        Assert.Equal(10, result.Count);
        Assert.Equal("Henry", result[0].Name); // 450
        Assert.Equal("Frank", result[1].Name); // 600
        Assert.Equal("Ivy", result[9].Name);   // 3000

        // Verify ascending order
        for (int i = 1; i < result.Count; i++)
        {
            Assert.True(result[i].Score >= result[i - 1].Score);
        }
    }

    [Fact]
    public void Exercise308_GetPlayersSortedByScoreDescending_SortsDescending()
    {
        var result = LinqExercises.GetPlayersSortedByScoreDescending(_players).ToList();

        Assert.Equal(10, result.Count);
        Assert.Equal("Ivy", result[0].Name);   // 3000
        Assert.Equal("Charlie", result[1].Name); // 2200
        Assert.Equal("Henry", result[9].Name); // 450

        // Verify descending order
        for (int i = 1; i < result.Count; i++)
        {
            Assert.True(result[i].Score <= result[i - 1].Score);
        }
    }

    [Fact]
    public void Exercise309_GetPlayersSortedByName_SortsAlphabetically()
    {
        var result = LinqExercises.GetPlayersSortedByName(_players).ToList();

        Assert.Equal("Alice", result[0].Name);
        Assert.Equal("Bob", result[1].Name);
        Assert.Equal("Charlie", result[2].Name);
        Assert.Equal("Jack", result[9].Name);
    }

    // ============================================================
    // PART 4: FINDING SINGLE ELEMENTS
    // ============================================================

    [Fact]
    public void Exercise310_GetTopScorer_ReturnsHighestScorer()
    {
        var result = LinqExercises.GetTopScorer(_players);

        Assert.NotNull(result);
        Assert.Equal("Ivy", result.Name);
        Assert.Equal(3000, result.Score);
    }

    [Fact]
    public void Exercise310_GetTopScorer_EmptyList_ReturnsNull()
    {
        var result = LinqExercises.GetTopScorer([]);

        Assert.Null(result);
    }

    [Fact]
    public void Exercise311_GetFirstOnlinePlayer_ReturnsFirstOnline()
    {
        var result = LinqExercises.GetFirstOnlinePlayer(_players);

        Assert.NotNull(result);
        Assert.True(result.IsOnline);
    }

    [Fact]
    public void Exercise311_GetFirstOnlinePlayer_NoOnline_ReturnsNull()
    {
        var offlinePlayers = _players.Where(p => !p.IsOnline).ToList();
        var result = LinqExercises.GetFirstOnlinePlayer(offlinePlayers);

        Assert.Null(result);
    }

    [Fact]
    public void Exercise312_GetLowestScorerWithGames_ReturnsCorrectPlayer()
    {
        var result = LinqExercises.GetLowestScorerWithGames(_players);

        Assert.NotNull(result);
        Assert.Equal("Henry", result.Name);
        Assert.Equal(450, result.Score);
        Assert.True(result.GamesPlayed > 0);
    }

    [Fact]
    public void Exercise312_GetLowestScorerWithGames_NoGamesPlayed_ReturnsNull()
    {
        var noGamesPlayers = new List<Player>
        {
            new Player { Name = "Test", Score = 100, Level = 1, IsOnline = true, Team = "X", GamesPlayed = 0 }
        };
        var result = LinqExercises.GetLowestScorerWithGames(noGamesPlayers);

        Assert.Null(result);
    }

    // ============================================================
    // PART 5: CHECKING CONDITIONS WITH ANY AND ALL
    // ============================================================

    [Fact]
    public void Exercise313_HasOnlinePlayers_WithOnline_ReturnsTrue()
    {
        var result = LinqExercises.HasOnlinePlayers(_players);

        Assert.True(result);
    }

    [Fact]
    public void Exercise313_HasOnlinePlayers_AllOffline_ReturnsFalse()
    {
        var offlinePlayers = _players.Where(p => !p.IsOnline).ToList();
        var result = LinqExercises.HasOnlinePlayers(offlinePlayers);

        Assert.False(result);
    }

    [Fact]
    public void Exercise314_HasHighScorer_WithHighScorer_ReturnsTrue()
    {
        var result = LinqExercises.HasHighScorer(_players);

        Assert.True(result); // Ivy has 3000, Charlie has 2200
    }

    [Fact]
    public void Exercise314_HasHighScorer_NoHighScorer_ReturnsFalse()
    {
        var lowScorers = _players.Where(p => p.Score <= 1000).ToList();
        var result = LinqExercises.HasHighScorer(lowScorers);

        Assert.False(result);
    }

    [Fact]
    public void Exercise315_AllPlayersHavePlayedGames_AllHaveGames_ReturnsTrue()
    {
        var result = LinqExercises.AllPlayersHavePlayedGames(_players);

        Assert.True(result);
    }

    [Fact]
    public void Exercise315_AllPlayersHavePlayedGames_SomeHaveNoGames_ReturnsFalse()
    {
        var playersWithZeroGames = _players.Append(
            new Player { Name = "Newbie", Score = 0, Level = 1, IsOnline = true, Team = "New", GamesPlayed = 0 }
        ).ToList();
        var result = LinqExercises.AllPlayersHavePlayedGames(playersWithZeroGames);

        Assert.False(result);
    }

    [Fact]
    public void Exercise316_AllOnlinePlayersHavePositiveScore_AllPositive_ReturnsTrue()
    {
        var result = LinqExercises.AllOnlinePlayersHavePositiveScore(_players);

        Assert.True(result);
    }

    [Fact]
    public void Exercise316_AllOnlinePlayersHavePositiveScore_SomeZero_ReturnsFalse()
    {
        var playersWithZeroScore = _players.Append(
            new Player { Name = "Zero", Score = 0, Level = 1, IsOnline = true, Team = "X", GamesPlayed = 1 }
        ).ToList();
        var result = LinqExercises.AllOnlinePlayersHavePositiveScore(playersWithZeroScore);

        Assert.False(result);
    }

    // ============================================================
    // PART 6: COUNTING AND AGGREGATING
    // ============================================================

    [Fact]
    public void Exercise317_CountOnlinePlayers_ReturnsCorrectCount()
    {
        var result = LinqExercises.CountOnlinePlayers(_players);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Exercise317_CountOnlinePlayers_NoneOnline_ReturnsZero()
    {
        var offlinePlayers = _players.Where(p => !p.IsOnline).ToList();
        var result = LinqExercises.CountOnlinePlayers(offlinePlayers);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise318_GetTotalScore_ReturnsSumOfScores()
    {
        var result = LinqExercises.GetTotalScore(_players);

        // 1500 + 800 + 2200 + 950 + 1100 + 600 + 1800 + 450 + 3000 + 750 = 13150
        Assert.Equal(13150, result);
    }

    [Fact]
    public void Exercise318_GetTotalScore_EmptyList_ReturnsZero()
    {
        var result = LinqExercises.GetTotalScore([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise319_GetAverageScore_ReturnsCorrectAverage()
    {
        var result = LinqExercises.GetAverageScore(_players);

        // 13150 / 10 = 1315
        Assert.Equal(1315, result);
    }

    [Fact]
    public void Exercise319_GetAverageScore_EmptyList_ReturnsZero()
    {
        var result = LinqExercises.GetAverageScore([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise320_GetHighestScore_ReturnsMaxScore()
    {
        var result = LinqExercises.GetHighestScore(_players);

        Assert.Equal(3000, result);
    }

    [Fact]
    public void Exercise320_GetHighestScore_EmptyList_ReturnsZero()
    {
        var result = LinqExercises.GetHighestScore([]);

        Assert.Equal(0, result);
    }

    // ============================================================
    // PART 7: TAKE AND SKIP
    // ============================================================

    [Fact]
    public void Exercise321_GetTop3Players_ReturnsTop3ByScore()
    {
        var result = LinqExercises.GetTop3Players(_players).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal("Ivy", result[0].Name);     // 3000
        Assert.Equal("Charlie", result[1].Name); // 2200
        Assert.Equal("Grace", result[2].Name);   // 1800
    }

    [Fact]
    public void Exercise321_GetTop3Players_LessThan3Players_ReturnsAll()
    {
        var twoPlayers = _players.Take(2).ToList();
        var result = LinqExercises.GetTop3Players(twoPlayers).ToList();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Exercise322_GetPlayersExceptTop3_ReturnsRemaining()
    {
        var result = LinqExercises.GetPlayersExceptTop3(_players).ToList();

        Assert.Equal(7, result.Count);
        Assert.DoesNotContain(result, p => p.Name == "Ivy");
        Assert.DoesNotContain(result, p => p.Name == "Charlie");
        Assert.DoesNotContain(result, p => p.Name == "Grace");
    }

    [Fact]
    public void Exercise323_GetPlayersRanked4To6_ReturnsCorrectPlayers()
    {
        var result = LinqExercises.GetPlayersRanked4To6(_players).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal("Alice", result[0].Name);  // 1500 (4th)
        Assert.Equal("Eve", result[1].Name);    // 1100 (5th)
        Assert.Equal("Diana", result[2].Name);  // 950 (6th)
    }

    // ============================================================
    // PART 8: CHAINING MULTIPLE OPERATIONS
    // ============================================================

    [Fact]
    public void Exercise324_GetTop5OnlinePlayerNames_ReturnsCorrectNames()
    {
        var result = LinqExercises.GetTop5OnlinePlayerNames(_players).ToList();

        Assert.Equal(5, result.Count);
        Assert.Equal("Ivy", result[0]);      // 3000, online
        Assert.Equal("Charlie", result[1]);  // 2200, online
        Assert.Equal("Alice", result[2]);    // 1500, online
        Assert.Equal("Diana", result[3]);    // 950, online
        Assert.Equal("Frank", result[4]);    // 600, online
    }

    [Fact]
    public void Exercise325_GetTeamOnlineScore_ReturnsCorrectSum()
    {
        var result = LinqExercises.GetTeamOnlineScore(_players, "Red");

        // Alice (1500) + Charlie (2200) = 3700
        Assert.Equal(3700, result);
    }

    [Fact]
    public void Exercise325_GetTeamOnlineScore_NoOnlineOnTeam_ReturnsZero()
    {
        // Create players where no one on "Red" is online
        var players = new List<Player>
        {
            new Player { Name = "A", Score = 100, Level = 1, IsOnline = false, Team = "Red", GamesPlayed = 1 },
            new Player { Name = "B", Score = 200, Level = 2, IsOnline = true, Team = "Blue", GamesPlayed = 2 }
        };
        var result = LinqExercises.GetTeamOnlineScore(players, "Red");

        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise326_GetAverageLevelOfTopScorers_ReturnsCorrectAverage()
    {
        var result = LinqExercises.GetAverageLevelOfTopScorers(_players);

        // Top 10 by score: Ivy(35), Charlie(30), Grace(28), Alice(25), Eve(20),
        //                  Diana(18), Bob(15), Jack(14), Frank(12), Henry(8)
        // Average: (35+30+28+25+20+18+15+14+12+8) / 10 = 205/10 = 20.5
        Assert.Equal(20.5, result);
    }

    // ============================================================
    // PART 9: DISTINCT AND GROUPBY
    // ============================================================

    [Fact]
    public void Exercise327_GetAllTeamNames_ReturnsUniqueTeams()
    {
        var result = LinqExercises.GetAllTeamNames(_players).ToList();

        Assert.Equal(3, result.Count);
        Assert.Contains("Red", result);
        Assert.Contains("Blue", result);
        Assert.Contains("Green", result);
    }

    [Fact]
    public void Exercise328_GetAllLevels_ReturnsUniqueSortedLevels()
    {
        var result = LinqExercises.GetAllLevels(_players).ToList();

        Assert.Equal(10, result.Count); // All players have unique levels
        Assert.Equal(8, result[0]);     // Henry
        Assert.Equal(35, result[9]);    // Ivy

        // Verify sorted
        for (int i = 1; i < result.Count; i++)
        {
            Assert.True(result[i] > result[i - 1]);
        }
    }

    [Fact]
    public void Exercise329_GetPlayerCountByTeam_ReturnsCorrectCounts()
    {
        var result = LinqExercises.GetPlayerCountByTeam(_players);

        Assert.Equal(3, result.Count);
        Assert.Equal(4, result["Red"]);   // Alice, Charlie, Grace, Jack
        Assert.Equal(3, result["Blue"]);  // Bob, Diana, Henry
        Assert.Equal(3, result["Green"]); // Eve, Frank, Ivy
    }

    [Fact]
    public void Exercise330_GetHighestScoreByTeam_ReturnsCorrectScores()
    {
        var result = LinqExercises.GetHighestScoreByTeam(_players);

        Assert.Equal(3, result.Count);
        Assert.Equal(2200, result["Red"]);   // Charlie
        Assert.Equal(950, result["Blue"]);   // Diana
        Assert.Equal(3000, result["Green"]); // Ivy
    }

    // ============================================================
    // PART 10: TOLIST AND IMMEDIATE EXECUTION
    // ============================================================

    [Fact]
    public void Exercise331_GetOnlinePlayersAsList_ReturnsList()
    {
        var result = LinqExercises.GetOnlinePlayersAsList(_players);

        Assert.IsType<List<Player>>(result);
        Assert.Equal(6, result.Count);
        Assert.All(result, p => Assert.True(p.IsOnline));
    }

    [Fact]
    public void Exercise332_GetSortedPlayerNamesAsArray_ReturnsArray()
    {
        var result = LinqExercises.GetSortedPlayerNamesAsArray(_players);

        Assert.IsType<string[]>(result);
        Assert.Equal(10, result.Length);
        Assert.Equal("Alice", result[0]);
        Assert.Equal("Jack", result[9]);
    }

    [Fact]
    public void Exercise333_GetHighScorersSingleEnumeration_OnlyEnumeratesOnce()
    {
        // This wrapper throws if enumerated more than once
        var singleUseSource = new SingleEnumerationWrapper<Player>(_players);

        var result = LinqExercises.GetHighScorersSingleEnumeration(singleUseSource, 1000);

        // Iterate multiple times - this should NOT throw because the result should be materialized
        var count1 = result.Count();
        var count2 = result.Count();
        var list = result.ToList();

        Assert.Equal(5, count1);
        Assert.Equal(5, count2);
        Assert.All(list, p => Assert.True(p.Score > 1000));
    }

    [Fact]
    public void Exercise333_GetHighScorersSingleEnumeration_ReturnsCorrectPlayers()
    {
        var result = LinqExercises.GetHighScorersSingleEnumeration(_players, 1000).ToList();

        Assert.Equal(5, result.Count);
        Assert.Contains(result, p => p.Name == "Alice");   // 1500
        Assert.Contains(result, p => p.Name == "Charlie"); // 2200
        Assert.Contains(result, p => p.Name == "Eve");     // 1100
        Assert.Contains(result, p => p.Name == "Grace");   // 1800
        Assert.Contains(result, p => p.Name == "Ivy");     // 3000
    }

    // ============================================================
    // BONUS CHALLENGES
    // ============================================================

    [Fact]
    public void Bonus301_GetTeamWithMostOnlinePlayers_ReturnsCorrectTeam()
    {
        var result = LinqExercises.GetTeamWithMostOnlinePlayers(_players);

        // Red: 2 online (Alice, Charlie)
        // Blue: 2 online (Diana, Henry)
        // Green: 2 online (Frank, Ivy)
        // Multiple teams tie, any of them is acceptable
        Assert.NotNull(result);
        Assert.Contains(result, new[] { "Red", "Blue", "Green" });
    }

    [Fact]
    public void Bonus301_GetTeamWithMostOnlinePlayers_NoOnline_ReturnsNull()
    {
        var offlinePlayers = _players.Where(p => !p.IsOnline).ToList();
        var result = LinqExercises.GetTeamWithMostOnlinePlayers(offlinePlayers);

        Assert.Null(result);
    }

    [Fact]
    public void Bonus302_GetAboveAveragePlayerNames_ReturnsCorrectNames()
    {
        var result = LinqExercises.GetAboveAveragePlayerNames(_players).ToList();

        // Average is 1315
        // Above average: Ivy (3000), Charlie (2200), Grace (1800), Alice (1500)
        Assert.Equal(4, result.Count);
        Assert.Contains("Ivy", result);
        Assert.Contains("Charlie", result);
        Assert.Contains("Grace", result);
        Assert.Contains("Alice", result);
    }

    [Fact]
    public void Bonus303_GetTopScorerPerTeam_ReturnsCorrectPlayers()
    {
        var result = LinqExercises.GetTopScorerPerTeam(_players);

        Assert.Equal(3, result.Count);
        Assert.Equal("Charlie", result["Red"]);  // 2200
        Assert.Equal("Diana", result["Blue"]);   // 950
        Assert.Equal("Ivy", result["Green"]);    // 3000
    }
}

/// <summary>
/// Helper class that wraps an enumerable and throws if enumerated more than once.
/// Used to test that students properly materialize their LINQ queries.
/// </summary>
internal class SingleEnumerationWrapper<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _source;
    private bool _enumerated;

    public SingleEnumerationWrapper(IEnumerable<T> source)
    {
        _source = source;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (_enumerated)
        {
            throw new InvalidOperationException(
                "This collection has already been enumerated once. " +
                "You need to materialize your query with ToList() to avoid multiple enumerations.");
        }
        _enumerated = true;
        return _source.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
