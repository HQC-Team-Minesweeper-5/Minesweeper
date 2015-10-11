//-----------------------------------------------------------------------
// <copyright file="Level.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class holds the params of the chosen level of the game</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Utils
{
    /// <summary>
    /// Utility class that holds the parameters of the chosen level in the beginning of the game.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Initializes a new instance of the Level class.
        /// </summary>
        /// <param name="numberOfRows">The number of rows in the playing field for this level.</param>
        /// <param name="numberOfCols">The number of columns in the playing field for this level.</param>
        /// <param name="numberOfMines">The number of mines in the playing field for this level.</param>
        public Level(int numberOfRows, int numberOfCols, int numberOfMines)
        {
            this.NumberOfRows = numberOfRows;
            this.NumberOfCols = numberOfCols;
            this.NumberOfMines = numberOfMines;
        }

        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        /// <value>The number of rows in the field.</value>
        public int NumberOfRows { get; private set; }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        /// <value>The number of columns in the field.</value>
        public int NumberOfCols { get; private set; }

        /// <summary>
        /// Gets the number of mines.
        /// </summary>
        /// <value>The number of mines in the field.</value>
        public int NumberOfMines { get; private set; }
    }
}
