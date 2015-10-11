//-----------------------------------------------------------------------
// <copyright file="Memento.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This file contains the memento logic, enabling undo functionality</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Utils;

    /// <summary>
    /// A static class that saves the state of the game.
    /// </summary>
    public class Memento
    {
        /// <summary>
        /// Field containing turn counter.
        /// </summary>
        private int turn;

        /// <summary>
        /// List containing cell coordinates.
        /// </summary>
        private List<List<Coordinates>> cells;

        /// <summary>
        /// Initializes a new instance of the Memento class.
        /// </summary>
        public Memento()
        {
            this.turn = -1;
            this.cells = new List<List<Coordinates>>();
        }

        /// <summary>
        /// A method that adds the cells that are changed this turn to the list.
        /// </summary>
        /// <param name="newCells">The cells that are changed this turn.</param>
        public void AddCells(List<Coordinates> newCells)
        {
            this.cells.Add(newCells);
            this.turn++;
            return;
        }

        /// <summary>
        /// A method that removes the cells that are changed the last turn from the list.
        /// </summary>
        public void RemoveCells()
        {
            if (this.turn >= 0)
            {
                this.cells.RemoveAt(this.turn);
                this.turn--;
            }
        }

        /// <summary>
        /// A method that returns the cells that are changed the last turn from the list.
        /// </summary>
        /// <returns>The cells that were changed in the last turn.</returns>
        public List<Coordinates> GetLastCells()
        {
            if (this.turn >= 0)
            {
                return this.cells.ElementAt(this.turn);
            }
            else
            {
                return null;
            }
        }
    }
}