namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public class PlayingField
    {
        private readonly MineCell[,] field;

        internal PlayingField(int rows, int cols, int minesCount)
        {
            this.field = new MineCell[rows, cols];
            this.FillPlayingFieldWithMineCells(this.field);
            this.SetMines(this.field, minesCount);
            MineCalculator.CalculateFieldValues(this.field);
        }

        public MineCell[,] Field
        {
            get
            {
                return this.field;
            }
        }

        internal GameStatus OpenCell(int row, int column)
        {
            MineCell field = this.field[row, column];
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
                field.Status = FieldStatus.Opened;
                status = GameStatus.GameOn;
            }

            return status;
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

        private void SetMines(MineCell[,] field, int minesCount)
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
