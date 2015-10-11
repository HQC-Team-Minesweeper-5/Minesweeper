namespace Minesweeper.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Utils;

    /// <summary>
    /// A static class that saves the state of the game
    /// </summary>
    public class Memento
    {
        private int turn;
        private List<List<Coordinates>> cells;

        public Memento()
        {
            this.turn = -1;
            this.cells = new List<List<Coordinates>>();
        }

        /// <summary>
        /// A method that adds the cells that are changed this turn to the list
        /// <param name="newCells">The cells that are changed this turn</param>
        /// </summary>
        public void AddCells(List<Coordinates> newCells)
        {
            this.cells.Add(newCells);
            this.turn++;
            return;
        }

        /// <summary>
        /// A method that removes the cells that are changed the last turn from the list
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
        /// A method that returns the cells that are changed the last turn from the list
        /// </summary>
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