namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    /// <summary>
    /// A static class that reads and writes into the scoreboard file
    /// </summary>
    internal static class Scoreboard
    {
        private const int MaxPlayersInHighscore = 3;

        /// <summary>
        /// Takes the currect score and compares it with the existing ones, then decides if it should save it or not
        /// </summary>
        /// <param name="currentPlayerScore">The player score for the current game</param>
        public static void HighScore(int currentPlayerScore)
        {
            try
            {
                List<Score> highScore = ReadHighScore();

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

        /// <summary>
        /// Helper method that reads the highscore file 
        /// </summary>
        /// <returns>A list of all the saved scores</returns>
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

        /// <summary>
        /// Helper method that rewriters the saved highscores
        /// </summary>
        /// <param name="scoreBoard">The new scores to be written</param>
        private static void WriteHighScore(IEnumerable<Score> scoreBoard)
        {
            List<string> output = new List<string>();

            foreach (var item in scoreBoard)
            {
                output.Add(item.ToString());
                Console.WriteLine(item.ToString());
            }

            System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
        }
        
        /// <summary>
        /// Adds a player to the highscore
        /// </summary>
        /// <param name="scoreBoard">All currently saved highscores</param>
        /// <param name="currentPlayerScore">The highscore of the current player</param>
        private static void AddPlayerToHighScore(List<Score> scoreBoard, int currentPlayerScore)
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
            scoreBoard.Add(current);
            scoreBoard.Sort((x1, x2) => x1.CompareTo(x2));
        }
    }
}
