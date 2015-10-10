
namespace Minesweeper.Logic
{
    using Minesweeper.Logic.Structures;
    using System.Collections.Generic;
    using System.Linq;

    public class OpenCellSaver
    {
        private int turn = -1;
        public List<List<CellCoordinates>> cells;

        public OpenCellSaver()
        {
            cells = new List<List<CellCoordinates>>();
        }

        public void addCells(List<CellCoordinates> newCells)
        {
            cells.Add(newCells);
            this.turn++;
            return;
        }

        public void RemoveCells()
        {
            if (turn >= 0)
            {
                cells.RemoveAt(turn);
                this.turn--;
            }
        }

        public List<CellCoordinates> getLastCells()
        {
            if (turn >= 0)
            {
                return cells.ElementAt(turn);
            }
            else
            {
                return null;
            }
        }

    }
}
