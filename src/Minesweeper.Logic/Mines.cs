namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    internal class Mines
    {
        internal static void SetMines(MineCell[,] field, int minesCount)
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

        // TODO: Check if this shouldn't be somewhere else ;)
        internal static void CalculateFieldValues(MineCell[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (field[i, j].Status != FieldStatus.IsAMine)
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
                    if (field[rowNum, colNum].Status == FieldStatus.IsAMine)
                    {
                        minesCount++;
                    }
                }
            }

            return minesCount;
        }

        internal static int CountOpenMines(MineCell[,] playingField)
        {
            int openedMines = 0;
            int rows = playingField.GetLength(0);
            int cols = playingField.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (playingField[i, j].Status == FieldStatus.Opened)
                    {
                        openedMines++;
                    }
                }
            }

            return openedMines;
        }
    }
}
