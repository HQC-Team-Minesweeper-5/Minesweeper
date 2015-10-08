namespace Minesweeper.Logic
{
    using System;
    using System.Text;
    using Minesweeper.Logic.Enumerations;

    internal class Printer
    {
        private const string MineOpened = "* ";
        private const string MineClosed = "? ";
        private const string Flag = "F";
        private StringBuilder sb;

        internal Printer()
        {
            this.sb = new StringBuilder();
        }

        internal void PrintPlayingField(PlayingField playingField, GameStatus gamestatus)
        {
            int rows = playingField.Field.GetLength(0);
            int columns = playingField.Field.GetLength(1);

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
                    MineCell currentField = playingField.Field[i, j];

                    if (gamestatus == GameStatus.GameOn)
                    {
                        if (currentField.Status == FieldStatus.Opened)
                        {
                            this.sb.Append(playingField.Field[i, j].Value);
                            this.sb.Append(" ");
                        }
                        else if(currentField.Status == FieldStatus.Flagged)
                        {
                            this.sb.Append(Flag);
                            this.sb.Append(" ");
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
                            this.sb.Append(playingField.Field[i, j].Value + " ");
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
                            this.sb.Append(playingField.Field[i, j].Value + " ");
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