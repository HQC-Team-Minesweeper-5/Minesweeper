namespace Minesweeper.Logic
{
    public class MineField
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int minesCount;
        private readonly PlayingField playingBoard;

        public MineField(int rows, int columns, int minesCount)
        {
            this.rows = rows;
            this.columns = columns;
            this.minesCount = minesCount;
            this.playingBoard = new PlayingField(rows, columns, minesCount);
        }
    }
}