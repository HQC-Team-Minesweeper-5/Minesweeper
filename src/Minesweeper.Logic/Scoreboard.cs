namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Scoreboard
    {
        // TODO: refactor
        private const int MaxPlayersInHighscore = 3;

        public static void HighScore(int score)
        {
            try
            {
                // Read high scores from file
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

                // Check if current score must be included in the highscore
                if (tempScore.Count < MaxPlayersInHighscore)
                {
                    string playerName = string.Empty;

                    do
                    {
                        Console.Write("Input your name:  ");
                        playerName = Console.ReadLine();

                        if (playerName.IndexOf('-') >= 0)
                        {
                            throw new FormatException("Invalid Name! Do not use '-");
                        }
                    }
                    while (playerName.Length < 3);

                    Score current = new Score(playerName, score, DateTime.Now);
                    tempScore.Add(current);
                    tempScore.Sort((x1, x2) => x1.CompareTo(x2));
                }
                else
                {
                    foreach (Score currentScore in tempScore)
                    {
                        if (currentScore.Points < score)
                        {
                            string playerName = string.Empty;

                            do
                            {
                                Console.Write("Input your name:  ");
                                playerName = Console.ReadLine();

                                if (playerName.IndexOf('\t') >= 0)
                                {
                                    throw new FormatException("Invalid Name! Do not use 'tab' in player name");
                                }
                            }
                            while (playerName.Length < 3);

                            Score current = new Score(playerName, score, DateTime.Now);
                            tempScore.Add(current);
                            tempScore.Sort((x1, x2) => x1.CompareTo(x2));
                            tempScore.RemoveAt(MaxPlayersInHighscore);
                            break;
                        }
                    }
                }

                Console.Clear();
                List<string> output = new List<string>();

                foreach (var item in tempScore)
                {
                    output.Add(item.ToString());
                    Console.WriteLine(item.ToString());
                }

                System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
