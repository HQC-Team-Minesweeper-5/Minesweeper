namespace Minesweeper.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Logic.Structures;

    public class OpenCellSaver
    {
        private int turn = -1;
        private List<List<CellCoordinates>> cells;

        public OpenCellSaver()
        {
            this.cells = new List<List<CellCoordinates>>();
        }

        public void AddCells(List<CellCoordinates> newCells)
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

        public List<CellCoordinates> GetLastCells()
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