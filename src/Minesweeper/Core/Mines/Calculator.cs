//-----------------------------------------------------------------------
// <copyright file="Calculator.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class performs calculations with the mines in the minesweeper game.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core.Mines
{
    /// <summary>
    /// Class, performing calculations with the mines in the minesweeper game.
    /// </summary>
    internal static class Calculator
    {
        /// <summary>
        /// Calculates the values of all fields without mines in the beginning of the minesweeper game.
        /// </summary>
        /// <param name="field">Method accepts the newly constructed playing field, with mines already set in their places.</param>
        internal static void CalculateFieldValues(Cell[,] field)
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

        /// <summary>
        /// Method which calculates the number of mines, in the cells surrounding the current cell.
        /// </summary>
        /// <param name="field">The playing field.</param>
        /// <param name="row">The row of the cell which was clicked.</param>
        /// <param name="column">The column of the cell which was clicked.</param>
        /// <returns>An integer showing the number of mines in the surrounding cells.</returns>
        internal static int CountSurroundingMines(Cell[,] field, int row, int column)
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
