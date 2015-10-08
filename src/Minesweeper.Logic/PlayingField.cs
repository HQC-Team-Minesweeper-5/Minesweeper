namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public class PlayingField
    {
        private readonly MineCell[,] field;
        private int openCellsCounter;

        internal PlayingField(int rows, int cols, int minesCount)
        {
            this.field = new MineCell[rows, cols];
            this.FillPlayingFieldWithMineCells(this.field);
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

        internal GameStatus OpenCell(int row, int column)
        {
            MineCell field = this.field[row, column];
            GameStatus status;

            if (field.IsMine)
            {
                status = GameStatus.GameOver;
            }
            else if (field.Status == FieldStatus.Opened)
            {
                status = GameStatus.GameOn;
            }
            else if (field.Status == FieldStatus.Flagged)
            {
                Console.WriteLine("This field has been flagged as a mine!");
                status = GameStatus.GameOn;
            }
            else
            {
                field.Status = FieldStatus.Opened;
                status = GameStatus.GameOn;

                if (field.Value == 0)
                {
                    //TODO: implement auto open of neighbouring cells
                }
                openCellsCounter++;
            }

            return status;
        }

        internal void SetFlag(int row, int column)
        {
            MineCell field = this.field[row, column];

            field.Status = FieldStatus.Flagged;
        }

        internal void RemoveFlag(int row, int column)
        {
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

        internal void SetMines(int minesCount)
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
    }
}
