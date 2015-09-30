﻿namespace Minesweeper
{
    using System;
    using System.Linq;

    public class Mines
    {
        public static int CountSurroundingNumberOfMines(Field[,] field, int row, int column)
        {
            int minesCount = 0;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if ((row > 0) && (column > 0) &&
                (field[row - 1, column - 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((row > 0) &&
                (field[row - 1, column].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((row > 0) && (column < columns - 1) &&
                (field[row - 1, column + 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((column > 0) &&
                (field[row, column - 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((column < columns - 1) &&
                (field[row, column + 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((row < rows - 1) && (column > 0) &&
                (field[row + 1, column - 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((row < rows - 1) && (field[row + 1, column].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
            }

            if ((row < rows - 1) && (column < columns - 1) &&
                (field[row + 1, column + 1].Status == Field.FieldStatus.IsAMine))
            {
                minesCount++;
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

                if (field[row, column].Status == Field.FieldStatus.IsAMine)
                {
                    i--;
                }
                else
                {
                    field[row, column].Status = Field.FieldStatus.IsAMine;
                }
            }
        }
    }
}
