namespace Minesweeper.Logic
{
    public class Level
    {
        public Level(int numberOfRows, int numberOfCols, int numberOfMines)
        {
            this.NumberOfRows = numberOfRows;
            this.NumberOfCols = numberOfCols;
            this.NumberOfMines = numberOfMines;
        }

        public int NumberOfRows { get; private set; }

        public int NumberOfCols { get; private set; }

        public int NumberOfMines { get; private set; }
    }
}
