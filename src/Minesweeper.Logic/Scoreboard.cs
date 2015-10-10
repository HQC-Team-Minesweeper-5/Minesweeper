namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class Scoreboard
    {
        private const int MaxPlayersInHighscore = 3;

        public static void HighScore(int currentPlayerScore)
        {
            try
            {
                // Read high scores from file
                List<Score> highScore = ReadHighScore();

                // Check if current score must be included in the highscore
                if (highScore.Count < MaxPlayersInHighscore)
                {
                    AddPlayerToHighScore(highScore, currentPlayerScore);
                }
                else
                {
                    if (highScore.Any(score => score.Points < currentPlayerScore))
                    {
                        AddPlayerToHighScore(highScore, currentPlayerScore);
                        highScore.RemoveAt(MaxPlayersInHighscore);
                    }
                }

                WriteHighScore(highScore);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Score> ReadHighScore()
        {
            if (!File.Exists("HighScore.txt"))
            {
                TextWriter tw = new StreamWriter("HighScore.txt", true);
                tw.Close();
            }

            string[] scores = System.IO.File.ReadAllLines("HighScore.txt");
            List<Score> tempScore = new List<Score>();

            for (int i = 0; i < scores.Length; i++)
            {
                string[] temp = scores[i].Split('\t');

                if (temp != null)
                {
                    tempScore.Add(new Score(temp[0], int.Parse(temp[1]), DateTime.Parse(temp[2])));
                }
            }

            return tempScore;
        }

        private static void WriteHighScore(IEnumerable<Score> scoreBoard)
        {
            Console.Clear();
            List<string> output = new List<string>();

            foreach (var item in scoreBoard)
            {
                output.Add(item.ToString());
                Console.WriteLine(item.ToString());
            }

            System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
        }
        
        private static void AddPlayerToHighScore(List<Score> tempScore, int currentPlayerScore)
        {
            string playerName;

            while (true)
            { 
                Console.Write("Input your name:  ");
                playerName = Console.ReadLine();

                if (playerName.IndexOf('\t') >= 0)
                {
                    Console.WriteLine("Invalid Name! Do not use 'tab' in player name");
                }
                else if (playerName.Length < 3)
                {
                    Console.WriteLine("Invalid name! It must be at least 3 symbols long");
                }
                else
                {
                    break;
                }
            }

            Score current = new Score(playerName, currentPlayerScore, DateTime.Now);
            tempScore.Add(current);
            tempScore.Sort((x1, x2) => x1.CompareTo(x2));
        }
    }
}
