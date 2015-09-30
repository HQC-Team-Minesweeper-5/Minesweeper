namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    internal static class TopPlayers
    {
        internal static List<Player> Players { get; set; }

        internal static void Initialize(int maxTopPlayers)
        {
            Players = new List<Player>();
            Players.Capacity = maxTopPlayers;
        }

        internal static bool CheckHighScores(int score)
        {
            if (Players.Capacity > Players.Count)
            {
                return true;
            }

            foreach (Player currentPlayer in Players)
            {
                if (currentPlayer.Score < score)
                {
                    return true;
                }
            }

            return false;
        }

        internal static void PrintScoreboard()
        {
            Console.WriteLine(value: "Scoreboard");

            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine((int)(i + 1) + ". " + Players[i]);
            }
        }

        internal static void Add(ref Player player)
        {
            if (Players.Capacity > Players.Count)
            {
                Players.Add(player);
                Players.Sort();
            }
            else
            {
                Players.RemoveAt(Players.Capacity - 1);
                Players.Add(player);
                Players.Sort();
            }
        }
    }
}
