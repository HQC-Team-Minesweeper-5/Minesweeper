namespace Minesweeper
{
    using System;

    public class Board
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int minesCount;

        //TODO: make the filed a simple matrix instead of a jagged array
        private readonly Field[][] fields;

        public Board(int rows, int columns, int minesCount)
        {
            this.rows = rows;
            this.columns = columns;
            this.minesCount = minesCount;
            this.fields = new Field[rows][];

            for (int i = 0; i < this.fields.Length; i++)
            {
                this.fields[i] = new Field[columns];
            }

            for (int i = 0; i < this.fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    this.fields[i][j] = new Field();
                }
            }

            Mines.SetMines(fields, minesCount, rows, columns);
        }

        public Field[][] Fields
        {
            get
            {
                return this.fields;
            }
        }

        public enum Status
        {
            SteppedOnAMine,
            AlreadyOpened,
            SuccessfullyOpened,
            AllFieldsAreOpened
        }

        public Status OpenField(int row, int column)
        {
            Field field = this.fields[row][column];
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
                field.Value = Mines.CountSurroundingNumberOfMines(fields, row, column);
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

        ////TODO: Move to Printer class
        //public void PrintGameBoard()
        //{
        //    Console.Write("    ");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write(i + " ");
        //    }

        //    Console.WriteLine();
        //    Console.Write("   _");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write("__");
        //    }

        //    Console.WriteLine();

        //    for (int i = 0; i < this.rows; i++)
        //    {
        //        Console.Write(i);
        //        Console.Write(" | ");

        //        for (int j = 0; j < this.columns; j++)
        //        {
        //            Field currentField = this.fields[i][j];
        //            if (currentField.Status == Field.FieldStatus.Opened)
        //            {
        //                Console.Write(this.fields[i][j].Value);
        //                Console.Write(" ");
        //            }
        //            else
        //            {
        //                Console.Write("? ");
        //            }
        //        }

        //        Console.WriteLine("|");
        //    }

        //    Console.Write("   _");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write("__");
        //    }

        //    Console.WriteLine();
        //}

        ////TODO: Move to Printer class
        //public void PrintAllFields()
        //{
        //    Console.Write("    ");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write(i + " ");
        //    }

        //    Console.WriteLine();
        //    Console.Write("   _");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write("__");
        //    }

        //    Console.WriteLine();

        //    for (int i = 0; i < this.rows; i++)
        //    {
        //        Console.Write(i);
        //        Console.Write(" | ");
        //        for (int j = 0; j < this.columns; j++)
        //        {
        //            Field currentField = this.fields[i][j];
        //            if (currentField.Status == Field.FieldStatus.Opened)
        //            {
        //                Console.Write(this.fields[i][j].Value + " ");
        //            }
        //            else if (currentField.Status == Field.FieldStatus.IsAMine)
        //            {
        //                Console.Write("* ");
        //            }
        //            else
        //            {
        //                currentField.Value = Mines.CountSurroundingNumberOfMines(fields, i, j);
        //                Console.Write(this.fields[i][j].Value + " ");
        //            }
        //        }

        //        Console.WriteLine("|");
        //    }

        //    Console.Write("   _");

        //    for (int i = 0; i < this.columns; i++)
        //    {
        //        Console.Write("__");
        //    }

        //    Console.WriteLine();
        //}

        public int CountOpenedFields()
        {
            int count = 0;
            for (int i = 0; i < this.fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    if (this.fields[i][j].Status == Field.FieldStatus.Opened)
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

            for (int i = 0; i < this.fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    if (this.fields[i][j].Status == Field.FieldStatus.Opened)
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