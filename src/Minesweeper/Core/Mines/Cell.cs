//-----------------------------------------------------------------------
// <copyright file="Cell.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class contains the template for each cell in the playing field</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core.Mines
{
    using System;
    using Minesweeper.Core.Field;

    /// <summary>
    /// The cell class is a template for the cells in the playing field of the minesweeper game.
    /// </summary>
    public class Cell : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the Cell class.
        /// </summary>
        public Cell()
        {
            this.Value = 0;
            this.Status = CellStatus.Closed;
        }

        /// <summary>
        /// Gets or sets the value of the cell.
        /// </summary>
        /// <value>An integer showing how many mines are near this cell.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the status of the cell.
        /// </summary>
        /// <value>Holds the cell status.</value>
        public CellStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there is a mine in the current cell.
        /// </summary>
        /// <value>Boolean showing if the cell contains a mine.</value>
        public bool IsMine { get; set; }

        /// <summary>
        /// Method which makes possible copying of mine cells instead of initializing them with the new operator.
        /// </summary>
        /// <returns>A copy of a cell in the playing field in its default state.</returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Cell;
        }
    }
}
