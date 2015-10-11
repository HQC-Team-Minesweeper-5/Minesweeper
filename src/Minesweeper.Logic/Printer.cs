namespace Minesweeper.Logic
{
    using System;
    using System.Text;
    using Minesweeper.Logic.Enumerations;

    internal class Printer
    {
        private const string MineOpened = "*  ";
        private const string MineClosed = "X  ";
        private const string Flag = "F  ";
        private StringBuilder sb;

        internal Printer()
        {
            this.sb = new StringBuilder();
        }

        internal void PrintPlayingField(PlayingField playingField, GameStatus gamestatus)
        {
            MenuPrinter menuPrinter = new MenuPrinter();
            menuPrinter.ConsoleSetUp();
            menuPrinter.PrintBackground();

            int rows = playingField.Field.GetLength(0);
            int columns = playingField.Field.GetLength(1);

            string formatString = new string(' ', (Console.WindowWidth - (columns + (columns * 2))) / 2);

            this.sb.AppendLine();
            this.sb.Append(formatString);

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append(string.Format("{0}", i).PadLeft(2, ' ') + " ");
            }

            this.sb.AppendLine();
            this.PrintLine(columns);

            for (int i = 0; i < rows; i++)
            {
                this.sb.Append(new string(' ', ((Console.WindowWidth - (columns + (columns * 2))) / 2) - 4));
                this.sb.Append(string.Format("{0}", i).PadLeft(2, ' '));
                this.sb.Append(" | ");

                for (int j = 0; j < columns; j++)
                {
                    MineCell currentField = playingField.Field[i, j];

                    if (gamestatus == GameStatus.GameOn)
                    {
                        if (currentField.Status == FieldStatus.Opened)
                        {
                            this.sb.Append(playingField.Field[i, j].Value);
                            this.sb.Append("  ");
                        }
                        else if (currentField.Status == FieldStatus.Flagged)
                        {
                            this.sb.Append(Flag);
                        }
                        else
                        {
                            this.sb.Append(MineClosed);
                        }
                    }
                    else if (gamestatus == GameStatus.GameOver)
                    {
                        if (currentField.IsMine)
                        {
                            this.sb.Append(MineOpened);
                        }
                        else
                        {
                            this.sb.Append(playingField.Field[i, j].Value + "  ");
                        }
                    }
                    else
                    {
                        if (currentField.IsMine == true || currentField.Status == FieldStatus.Flagged)
                        {
                            this.sb.Append(Flag);
                        }
                        else
                        {
                            this.sb.Append(playingField.Field[i, j].Value + "  ");
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
            this.sb.Append(new string(' ', (Console.WindowWidth - (columns + (columns * 2))) / 2));

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append("===");
            }

            this.sb.Append("=");
            this.sb.AppendLine();
        }
    }
}