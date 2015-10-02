namespace Minesweeper.Logic
{
    using Enumerations;
    using System;
    using System.Linq;

    public class Mines
    {
        public static int CountSurroundingMines(Field[,] field, int row, int column)
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
                    if (field[rowNum, colNum].Status == FieldStatus.IsAMine)
                    {
                        minesCount++;
                    }
                }
            }

            return minesCount;
        }

        public static void SetMines(Field[,] field, int minesCount)
        {
            var random = new Random();

            for (int i = 0; i < minesCount; i++)
            {
                int row = random.Next(0, field.GetLength(0));
                int column = random.Next(0, field.GetLength(1));

                if (field[row, column].Status == FieldStatus.IsAMine)
                {
                    i--;
                }
                else
                {
                    field[row, column].Status = FieldStatus.IsAMine;
                }
            }
        }
    }
}
