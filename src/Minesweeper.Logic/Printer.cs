namespace Minesweeper.Logic
{
    using Enumerations;
    using System;
    using System.Linq;

    public class Printer
    {
        public static void PrintGameBoard(Field[,] field, int rows, int columns)
        {
            Console.Write("    ");

            for (int i = 0; i < columns; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.Write("   _");

            for (int i = 0; i < columns; i++)
            {
                Console.Write("__");
            }

            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.Write(i);
                Console.Write(" | ");

                for (int j = 0; j < columns; j++)
                {
                    Field currentField = field[i, j];

                    if (currentField.Status == FieldStatus.Opened)
                    {
                        Console.Write(field[i, j].Value);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("? ");
                    }
                }

                Console.WriteLine("|");
            }

            Console.Write("   _");

            for (int i = 0; i < columns; i++)
            {
                Console.Write("__");
            }

            Console.WriteLine();
        }

        public static void PrintAllFields(Field[,] field, int rows, int columns)
        {
            Console.Write("    ");

            for (int i = 0; i < columns; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.Write("   _");

            for (int i = 0; i < columns; i++)
            {
                Console.Write("__");
            }

            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.Write(i);
                Console.Write(" | ");
                for (int j = 0; j < columns; j++)
                {
                    Field currentField = field[i, j];
                    if (currentField.Status == FieldStatus.Opened)
                    {
                        Console.Write(field[i, j].Value + " ");
                    }
                    else if (currentField.Status == FieldStatus.IsAMine)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        currentField.Value = Mines.CountSurroundingMines(field, i, j);
                        Console.Write(field[i, j].Value + " ");
                    }
                }

                Console.WriteLine("|");
            }

            Console.Write("   _");

            for (int i = 0; i < columns; i++)
            {
                Console.Write("__");
            }

            Console.WriteLine();
        }
    }
}