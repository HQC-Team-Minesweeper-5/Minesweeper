namespace Minesweeper.Logic
{
    using Minesweeper.Logic.Enumerations;

    public class Board
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int maxMines;
        private readonly Field[,] playingBoard;

        public Board(int rows, int columns, int minesCount)
        {
            this.rows = rows;
            this.columns = columns;
            this.maxMines = minesCount;
            this.playingBoard = new Field[rows, columns];

            this.PopulateField();
            Mines.SetMines(this.playingBoard, minesCount);
        }        

        public Field[,] PlayingBoard
        {
            get
            {
                return this.playingBoard;
            }
        }

        public GameStatus OpenField(int row, int column)
        {
            Field field = this.playingBoard[row, column];

            GameStatus status;

            if (field.Status == FieldStatus.IsAMine)
            {
                status = GameStatus.GameOver;
            }
            else if (field.Status == FieldStatus.Opened)
            {
                status = GameStatus.GameOn;
            }
            else
            {
                field.Value = Mines.CountSurroundingMines(this.playingBoard, row, column);
                field.Status = FieldStatus.Opened;

                if (this.CheckIfWin())
                {
                    status = GameStatus.YouWin;
                }
                else
                {
                    status = GameStatus.GameOn;
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
                    if (this.playingBoard[i, j].Status == FieldStatus.Opened)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void PopulateField()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    this.playingBoard[i, j] = new Field();
                }
            }
        }

        private bool CheckIfWin()
        {
            int openedFields = 0;

            for (int i = 0; i < this.playingBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.playingBoard.GetLength(1); j++)
                {
                    if (this.playingBoard[i, j].Status == FieldStatus.Opened)
                    {
                        openedFields++;
                    }
                }
            }

            if ((openedFields + this.maxMines) == (this.rows * this.columns))
            {
                return true;
            }

            return false;
        }
    }
}