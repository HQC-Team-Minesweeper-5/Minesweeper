namespace Minesweeper.Logic
{
    using System;
    using System.Text;
    using Minesweeper.Logic.Enumerations;

    internal class Printer
    {
        private const string MineOpened = "* ";
        private const string MineClosed = "? ";
        private StringBuilder sb;

        internal Printer()
        {
            this.sb = new StringBuilder();
        }

        internal void PrintGameBoard(MineCell[,] field, int rows, int columns, GameStatus gamestatus)
        {
            this.sb.AppendLine();
            this.sb.Append("    ");

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append(i + " ");
            }

            this.sb.AppendLine();
            this.PrintLine(columns);

            for (int i = 0; i < rows; i++)
            {
                this.sb.Append(i);
                this.sb.Append(" | ");

                for (int j = 0; j < columns; j++)
                {
                    MineCell currentField = field[i, j];

                    if (gamestatus == GameStatus.GameOn)
                    {
                        if (currentField.Status == FieldStatus.Opened)
                        {
                            this.sb.Append(field[i, j].Value);
                            this.sb.Append(" ");
                        }
                        else
                        {
                            this.sb.Append(MineClosed);
                        }
                    }
                    else
                    {
                        if (currentField.Status == FieldStatus.IsAMine)
                        {
                            this.sb.Append(MineOpened);
                        }
                        else
                        {
                            currentField.Value = Mines.CountSurroundingMines(field, i, j);
                            this.sb.Append(field[i, j].Value + " ");
                        }
                    }
                }

                this.sb.Append("|");
                this.sb.AppendLine();
            }

            this.PrintLine(columns);
            Console.WriteLine(this.sb.ToString());
            this.sb.Clear();
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