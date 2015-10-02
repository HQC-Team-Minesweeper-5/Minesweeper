namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;

    internal static class Scoreboard
    {
        internal static List<Player> TopPlayers { get; set; }

        internal static void Initialize(int maxTopPlayers)
        {
            TopPlayers = new List<Player>();
            TopPlayers.Capacity = maxTopPlayers;
        }

        internal static bool CheckHighScores(int score)
        {
            if (TopPlayers.Capacity > TopPlayers.Count)
            {
                return true;
            }

            foreach (Player currentPlayer in TopPlayers)
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

            for (int i = 0; i < TopPlayers.Count; i++)
            {
                Console.WriteLine((int)(i + 1) + ". " + TopPlayers[i]);
            }
        }

        internal static void Add(ref Player player)
        {
            if (TopPlayers.Capacity > TopPlayers.Count)
            {
                TopPlayers.Add(player);
                TopPlayers.Sort();
            }
            else
            {
                TopPlayers.RemoveAt(TopPlayers.Capacity - 1);
                TopPlayers.Add(player);
                TopPlayers.Sort();
            }
        }
    }
}
