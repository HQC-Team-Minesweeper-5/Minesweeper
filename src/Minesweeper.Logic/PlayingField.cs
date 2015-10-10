namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Logic.Enumerations;
    using Minesweeper.Logic.Structures;

    public class PlayingField
    {
        private List<CellCoordinates> newCells;
        private readonly MineCell[,] field;
        private int openCellsCounter;
        private bool initialState = true;
        private int minesCount;
        private int howDeepAmI = 0;

        internal PlayingField(int rows, int cols, int minesCount)
        {
            this.field = new MineCell[rows, cols];
            this.FillPlayingFieldWithMineCells(this.field);
            this.minesCount = minesCount;
            this.openCellsCounter = 0;
        }

        internal MineCell[,] Field
        {
            get
            {
                return this.field;
            }
        }

        internal int OpenCellsCounter
        {
            get
            {
                return this.openCellsCounter;
            }
        }

        internal void OpenCell(int row, int column)
        {
            MineCell field = this.field[row, column];

            if (field.Status == FieldStatus.Flagged)
            {
                Console.Beep();

                return;
            }
            else if (field.IsMine)
            {
                Game.Instance().ChangeToGameOver();
            }
            else
            {

                int currDeepness = howDeepAmI;
                if (currDeepness == 0)
                {
                    newCells = new List<CellCoordinates>();
                }
                field.Status = FieldStatus.Opened;
                newCells.Add(new CellCoordinates(row, column));

                if (this.initialState)
                {
                    this.SetMines(this.minesCount);
                    MineCalculator.CalculateFieldValues(this.Field);
                    this.initialState = false;
                }

                if (field.Value == 0)
                {
                    howDeepAmI++;
                    this.OpenSurroundingCells(row, column);
                    howDeepAmI--;
                }

                if (currDeepness == 0)
                {
                    Game.Instance().OpenCellSaver.addCells(newCells);
                }
                this.openCellsCounter++;
            }
        }

        internal void SetFlag(int row, int column)
        {

            newCells = new List<CellCoordinates>();
            newCells.Add(new CellCoordinates(row, column));
            Game.Instance().OpenCellSaver.addCells(newCells);

            MineCell field = this.field[row, column];

            if (field.Status != FieldStatus.Opened)
            {
                field.Status = FieldStatus.Flagged;
            }
        }

        internal void RemoveFlag(int row, int column)
        {
            newCells = new List<CellCoordinates>();
            newCells.Add(new CellCoordinates(row, column));
            Game.Instance().OpenCellSaver.addCells(newCells);

            MineCell field = this.field[row, column];

            field.Status = FieldStatus.Closed;
        }

        private void FillPlayingFieldWithMineCells(MineCell[,] emptyPlayingField)
        {
            int rows = emptyPlayingField.GetLength(0);
            int cols = emptyPlayingField.GetLength(1);
            MineCell[,] playingField = emptyPlayingField;
            MineCell mine = new MineCell();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playingField[i, j] = mine.Clone() as MineCell;
                }
            }
        }

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
                    if (this.field[rowNum, colNum].Status == FieldStatus.Opened)
                    {
                        continue;
                    }

                    this.OpenCell(rowNum, colNum);
                }
            }
        }
    }
}
