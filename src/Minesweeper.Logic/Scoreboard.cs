namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;

    internal static class Scoreboard
    {
        // TODO: Scoreboard should read/write game results to a file
        internal static List<Player> TopPlayers { get; set; }

        internal static void Initialize(int maxTopPlayers)
        {
            TopPlayers = new List<Player>();
            TopPlayers.Capacity = maxTopPlayers;
        }

        internal static void AddToHighScores(int score)
        {
            Console.WriteLine("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            var player = new Player(name, score);
            Scoreboard.Add(ref player);
            Scoreboard.PrintScoreboard();
        }

        internal static void CheckHighScores(int score)
        {
            if (TopPlayers.Capacity > TopPlayers.Count)
            {
                AddToHighScores(score);
            }

            foreach (Player currentPlayer in TopPlayers)
            {
                if (currentPlayer.Score < score)
                {
                    AddToHighScores(score);
                }
            }
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
