namespace Minesweeper.Logic
{
    using System;
    using System.Text;
    using Minesweeper.Logic.Enumerations;

    public class Printer
    {
        private StringBuilder sb;

        internal Printer()
        {
            this.sb = new StringBuilder();
        }

        public void PrintGameBoard(MineCell[,] field, int rows, int columns)
        {
            this.PrintTopPlayingField(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                this.sb.Append(i);
                this.sb.Append(" | ");

                for (int j = 0; j < columns; j++)
                {
                    MineCell currentField = field[i, j];

                    if (currentField.Status == FieldStatus.Opened)
                    {
                        this.sb.Append(field[i, j].Value);
                        this.sb.Append(" ");
                    }
                    else
                    {
                        this.sb.Append("? ");
                    }
                }

                this.sb.Append("|");
                this.sb.AppendLine();
            }

            this.sb.Append("   =");

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append("==");
            }

            this.sb.AppendLine();

            Console.WriteLine(this.sb.ToString());
            this.sb.Clear();
        }

        public void PrintAllFields(MineCell[,] field, int rows, int columns)
        {
            this.PrintTopPlayingField(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                this.sb.Append(i);
                this.sb.Append(" | ");
                for (int j = 0; j < columns; j++)
                {
                    MineCell currentField = field[i, j];
                    if (currentField.Status == FieldStatus.Opened)
                    {
                        this.sb.Append(field[i, j].Value + " ");
                    }
                    else if (currentField.Status == FieldStatus.IsAMine)
                    {
                        this.sb.Append("* ");
                    }
                    else
                    {
                        currentField.Value = Mines.CountSurroundingMines(field, i, j);
                        this.sb.Append(field[i, j].Value + " ");
                    }
                }

                this.sb.Append("|");
                this.sb.AppendLine();
            }

            this.PrintLine(columns);

            this.sb.AppendLine();
            Console.WriteLine(this.sb.ToString());
            this.sb.Clear();
        }

        private void PrintTopPlayingField(int rows, int columns)
        {
            this.sb.AppendLine();
            this.sb.Append("    ");

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append(i + " ");
            }

            this.sb.AppendLine();

            this.PrintLine(columns);
        }

        private void PrintLine(int columns)
        {
            this.sb.Append("   =");

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append("==");
            }

            this.sb.AppendLine();
        }
    }
}