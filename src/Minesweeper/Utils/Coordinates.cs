//-----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class contains the scoreboard for our minesweeper game</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Utils
{
    /// <summary>
    /// Structure holding coordinates for a cell in the playing field.
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        /// The row of the cell.
        /// </summary>
        public int Row;

        /// <summary>
        /// The column of the cell.
        /// </summary>
        public int Col;

        /// <summary>
        /// Initializes a new instance of the Coordinates struct.
        /// </summary>
        /// <param name="row">Row of the cell.</param>
        /// <param name="col">Column of the cell.</param>
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}