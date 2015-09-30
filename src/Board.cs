namespace Minesweeper
{
    using System;

    public class Board
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int minesCount;
        private readonly Field[,] playingBoard;

        public Board(int rows, int columns, int minesCount)
        {
            this.rows = rows;
            this.columns = columns;
            this.minesCount = minesCount;
            this.playingBoard = new Field[rows, columns];

            for (int i = 0; i < this.playingBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.playingBoard.GetLength(1); j++)
                {
                    this.playingBoard[i, j] = new Field();
                }
            }

            Mines.SetMines(this.playingBoard, minesCount);
        }

        public enum Status
        {
            SteppedOnAMine,
            AlreadyOpened,
            SuccessfullyOpened,
            AllFieldsAreOpened
        }

        public Field[,] PlayingBoard
        {
            get
            {
                return this.playingBoard;
            }
        }

        public Status OpenField(int row, int column)
        {
            Field field = this.playingBoard[row, column];

            Status status;

            if (field.Status == Field.FieldStatus.IsAMine)
            {
                status = Status.SteppedOnAMine;
            }
            else if (field.Status == Field.FieldStatus.Opened)
            {
                status = Status.AlreadyOpened;
            }
            else
            {
                field.Value = Mines.CountSurroundingNumberOfMines(this.playingBoard, row, column);
                field.Status = Field.FieldStatus.Opened;
                if (this.CheckIfWin())
                {
                    status = Status.AllFieldsAreOpened;
                }
                else
                {
                    status = Status.SuccessfullyOpened;
                }
            }

            return status;
        }

        public int CountOpenedFields()
        {
            int count = 0;

            for (int i = 0; i < this.playingBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.playingBoard.GetLength(1); j++)
                {
                    if (this.playingBoard[i, j].Status == Field.FieldStatus.Opened)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool CheckIfWin()
        {
            int openedFields = 0;

            for (int i = 0; i < this.playingBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.playingBoard.GetLength(1); j++)
                {
                    if (this.playingBoard[i, j].Status == Field.FieldStatus.Opened)
                    {
                        openedFields++;
                    }
                }
            }

            if ((openedFields + this.minesCount) == (this.rows * this.columns))
            {
                return true;
            }

            return false;
        }
    }
}