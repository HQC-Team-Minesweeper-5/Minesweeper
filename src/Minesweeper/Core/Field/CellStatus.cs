//-----------------------------------------------------------------------
// <copyright file="CellStatus.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This enumeration lists the different states of the cells in the minesweeper board.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core.Field
{
    /// <summary>
    /// List the different states of each cell on the playing field.
    /// </summary>
    public enum CellStatus 
    {
        /// <summary>
        /// The cell has not been opened yet.
        /// </summary>
        Closed,

        /// <summary>
        /// The cell has already been opened.
        /// </summary>
        Opened,

        /// <summary>
        /// The cell has been flagged as a mine.
        /// </summary>
        Flagged
    }
}
