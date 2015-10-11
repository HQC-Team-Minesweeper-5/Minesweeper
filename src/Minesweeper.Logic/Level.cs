namespace Minesweeper.Logic
{
    /// <summary>
    /// Util class that holds the params of the chosen level in the begining of the game
    /// </summary>
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
