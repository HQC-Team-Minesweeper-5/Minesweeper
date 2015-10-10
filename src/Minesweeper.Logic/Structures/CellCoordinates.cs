namespace Minesweeper.Logic.Structures
{
    public struct CellCoordinates
    {
        public int Row;
        public int Col;

        public CellCoordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}