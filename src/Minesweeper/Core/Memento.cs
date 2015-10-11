namespace Minesweeper.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Utils;

    public class Memento
    {
        private int turn;
        private List<List<Coordinates>> cells;

        public Memento()
        {
            this.turn = -1;
            this.cells = new List<List<Coordinates>>();
        }

        public void AddCells(List<Coordinates> newCells)
        {
            this.cells.Add(newCells);
            this.turn++;
            return;
        }

        public void RemoveCells()
        {
            if (this.turn >= 0)
            {
                this.cells.RemoveAt(this.turn);
                this.turn--;
            }
        }

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