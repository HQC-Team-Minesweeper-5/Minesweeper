namespace Minesweeper.Logic
{
    using Minesweeper.Logic.Enumerations;

    internal static class MineCalculator
    {
        internal static void CalculateFieldValues(MineCell[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!field[i, j].IsMine)
                    {
                        field[i, j].Value = CountSurroundingMines(field, i, j);
                    }
                }
            }
        }

        internal static int CountSurroundingMines(MineCell[,] field, int row, int column)
        {
            int minesCount = 0;

            int minX = 0;
            int maxX = field.GetLength(0) - 1;
            int minY = 0;
            int maxY = field.GetLength(1) - 1;

            int startPosX = (row - 1 < minX) ? row : row - 1;
            int startPosY = (column - 1 < minY) ? column : column - 1;
            int endPosX = (row + 1 > maxX) ? row : row + 1;
            int endPosY = (column + 1 > maxY) ? column : column + 1;

            for (int rowNum = startPosX; rowNum <= endPosX; rowNum++)
            {
                for (int colNum = startPosY; colNum <= endPosY; colNum++)
                {
                    if (field[rowNum, colNum].IsMine)
                    {
                        minesCount++;
                    }
                }
            }

            return minesCount;
        }
    }
}
