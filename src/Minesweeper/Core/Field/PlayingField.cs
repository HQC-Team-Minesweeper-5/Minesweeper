//-----------------------------------------------------------------------
// <copyright file="PlayingField.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class contains the template for the playing filed of the minesweeper game.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core.Field
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Core.Mines;
    using Minesweeper.Utils;

    /// <summary>
    /// The template for the playing filed of the minesweeper game.
    /// </summary>
    public class PlayingField
    {
        /// <summary>
        /// Field containing the playing field with all the cells.
        /// </summary>
        private readonly Cell[,] field;

        /// <summary>
        /// List needed for the memento pattern, holding cell coordinates to enable undo functionality.
        /// </summary>
        private List<Coordinates> newCells;

        /// <summary>
        /// Counter, holding the number of cells, which are already opened.
        /// </summary>
        private int openCellsCounter;

        /// <summary>
        /// This is a helper boolean which indicates whether the game has just been started and this is the first move of the player.
        /// </summary>
        private bool initialState;

        /// <summary>
        /// Holds the number of mines set on the playing field.
        /// </summary>
        private int minesCount;

        /// <summary>
        /// Holds the depth level of the memento.
        /// </summary>
        private int howDeepAmI;

        /// <summary>
        /// Initializes a new instance of the PlayingField class.
        /// </summary>
        /// <param name="rows">The number of rows of the playing field.</param>
        /// <param name="cols">The number of columns of the playing field.</param>
        /// <param name="minesCount">The number of mines on the playing filed.</param>
        public PlayingField(int rows, int cols, int minesCount)
        {
            this.field = new Cell[rows, cols];
            this.openCellsCounter = 0;
            this.initialState = true;
            this.minesCount = minesCount;
            this.howDeepAmI = 0;
            this.FillPlayingFieldWithCells(this.field);
        }

        /// <summary>
        /// Gets the playing field.
        /// </summary>
        /// <value>Returns the mine field within the playing field.</value>
        public Cell[,] Field
        {
            get
            {
                return this.field;
            }
        }

        /// <summary>
        /// Gets the open cells counter - the number of cells which are already opened.
        /// </summary>
        /// <value>Returns the number of cell, which have been opened.</value>
        public int OpenCellsCounter
        {
            get
            {
                return this.openCellsCounter;
            }
        }

        /// <summary>
        /// Reduces the score.
        /// </summary>
        /// <param name="count">The amount with which the current score must be reduced.</param>
        public void ReduceScore(int count)
        {
            this.openCellsCounter -= count;
        }

        /// <summary>
        /// Opens a cell in the playing field.
        /// </summary>
        /// <param name="row">The row of the cell, being opened.</param>
        /// <param name="column">The column of the cell, being opened.</param>
        public void OpenCell(int row, int column)
        {
            Cell cell = this.field[row, column];

            if (cell.Status == CellStatus.Flagged || cell.Status == CellStatus.Opened)
            {
                Console.Beep();

                return;
            }
            else if (cell.IsMine)
            {
                Game.Instance().ChangeToGameOver();
            }
            else
            {
                int currDeepness = this.howDeepAmI;
                if (currDeepness == 0)
                {
                    this.newCells = new List<Coordinates>();
                }

                cell.Status = CellStatus.Opened;
                this.newCells.Add(new Coordinates(row, column));

                if (this.initialState)
                {
                    this.SetMines(this.minesCount);
                    Calculator.CalculateFieldValues(this.Field);
                    this.initialState = false;
                }

                if (cell.Value == 0)
                {
                    this.howDeepAmI++;
                    this.OpenSurroundingCells(row, column);
                    this.howDeepAmI--;
                }

                if (currDeepness == 0)
                {
                    Game.Instance().Memento.AddCells(this.newCells);
                }

                this.openCellsCounter++;
            }
        }

        /// <summary>
        /// Sets flag on a cell in the playing field.
        /// </summary>
        /// <param name="row">The row of the cell, being flagged.</param>
        /// <param name="column">The column of the cell, being flagged.</param>
        internal void SetFlag(int row, int column)
        {
            this.newCells = new List<Coordinates>();
            this.newCells.Add(new Coordinates(row, column));
            Game.Instance().Memento.AddCells(this.newCells);

            Cell field = this.field[row, column];

            if (field.Status != CellStatus.Opened && field.Status != CellStatus.Flagged)
            {
                field.Status = CellStatus.Flagged;
                Game.Instance().NumberOfFlags++;
            }
        }

        /// <summary>
        /// Removes a flag from a cell.
        /// </summary>
        /// <param name="row">The row of the cell, from which a flag is being removed.</param>
        /// <param name="column">The column of the cell, from which a flag is being removed.</param>
        internal void RemoveFlag(int row, int column)
        {
            this.newCells = new List<Coordinates>();
            this.newCells.Add(new Coordinates(row, column));
            Game.Instance().Memento.AddCells(this.newCells);

            Cell field = this.field[row, column];

            if (field.Status == CellStatus.Flagged)
            {
                field.Status = CellStatus.Closed;
                Game.Instance().NumberOfFlags--;
            }
        }

        /// <summary>
        /// This method fills the playing field matrix with cells.
        /// </summary>
        /// <param name="emptyPlayingField">An empty playing field matrix.</param>
        private void FillPlayingFieldWithCells(Cell[,] emptyPlayingField)
        {
            int rows = emptyPlayingField.GetLength(0);
            int cols = emptyPlayingField.GetLength(1);
            Cell[,] playingField = emptyPlayingField;
            Cell cell = new Cell();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playingField[i, j] = cell.Clone() as Cell;
                }
            }
        }

        /// <summary>
        /// This method seeds mines in random places, after the first cell in the playing field has been opened.
        /// </summary>
        /// <param name="minesCount">The number of mines, which will be seeded in the playing field.</param>
        private void SetMines(int minesCount)
        {
            var random = new Random();

            for (int i = 0; i < minesCount; i++)
            {
                int row = random.Next(0, this.field.GetLength(0));
                int column = random.Next(0, this.field.GetLength(1));

                if (this.field[row, column].IsMine == true)
                {
                    i--;
                }
                else
                {
                    this.field[row, column].IsMine = true;
                }
            }
        }

        /// <summary>
        /// This method opens all surrounding cells if the current cell value is 0.
        /// </summary>
        /// <param name="row">The row of the cell, which does not have any mines as neighbors.</param>
        /// <param name="column">The column of the cell, which does not have any mines as neighbors.</param>
        private void OpenSurroundingCells(int row, int column)
        {
            int minX = 0;
            int maxX = this.field.GetLength(0) - 1;
            int minY = 0;
            int maxY = this.field.GetLength(1) - 1;

            int startPosX = (row - 1 < minX) ? row : row - 1;
            int startPosY = (column - 1 < minY) ? column : column - 1;
            int endPosX = (row + 1 > maxX) ? row : row + 1;
            int endPosY = (column + 1 > maxY) ? column : column + 1;

            for (int rowNum = startPosX; rowNum <= endPosX; rowNum++)
            {
                for (int colNum = startPosY; colNum <= endPosY; colNum++)
                {
                    if (this.field[rowNum, colNum].Status == CellStatus.Opened)
                    {
                        continue;
                    }

                    this.OpenCell(rowNum, colNum);
                }
            }
        }
    }
}
