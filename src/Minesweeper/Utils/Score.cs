//-----------------------------------------------------------------------
// <copyright file="Score.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class holds the score from the game</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Utils
{
    using System;

    /// <summary>
    /// Holds the score from the game.
    /// </summary>
    public class Score : IComparable<Score>
    {
        /// <summary>
        /// Holds player name.
        /// </summary>
        private string name;

        /// <summary>
        /// Holds player points.
        /// </summary>
        private int points;

        /// <summary>
        /// Holds the date and time the game has ended.
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Initializes a new instance of the Score class.
        /// </summary>
        /// <param name="playerName">Player name.</param>
        /// <param name="points">Points of the player.</param>
        /// <param name="dateTime">Date and time the game has ended.</param>
        public Score(string playerName, int points, DateTime dateTime)
        {
            this.name = playerName;
            this.points = points;
            this.date = dateTime;
        }

        /// <summary>
        /// Gets the points of the player.
        /// </summary>
        /// <value>Returns the points of the player.</value>
        public int Points
        {
            get
            {
                return this.points;
            }
        }

        /// <summary>
        /// Compares one score to another, so players can be ordered in the high score list.
        /// </summary>
        /// <param name="otherScore">A score to compare to.</param>
        /// <returns>A value, indicating which score was higher.</returns>
        public int CompareTo(Score otherScore)
        {
            if (this.points > otherScore.points)
            {
                return 1;
            }

            if (this.points == otherScore.points)
            {
                return 0;
            }

            return -1;
        }

        /// <summary>
        /// Prints the player name, points and date time.
        /// </summary>
        /// <returns>A string with information for player name, score and time the game has ended.</returns>
        public override string ToString()
        {
            return this.name + "\t" + this.points.ToString() + "\t" + this.date.ToString();
        }
    }
}
