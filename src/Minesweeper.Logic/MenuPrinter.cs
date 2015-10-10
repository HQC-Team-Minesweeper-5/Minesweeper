﻿namespace Minesweeper.Logic
{
    using Enumerations;
    using System;

    internal class MenuPrinter
    {
        private const int ConsoleHeight = 29;
        private const int ConsoleWidth = 80;

        public static void ConsoleSetUp()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.CursorVisible = false;
        }

        public static void PrintBackground()
        {
            Console.WriteLine(new string(' ', ConsoleWidth * ConsoleHeight));
            Console.BackgroundColor = ConsoleColor.Black;
            string gameTitle = " Minesweeper - v 5";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.Write((gameTitle).PadLeft(((ConsoleWidth - gameTitle.Length) / 2) + gameTitle.Length).PadRight(ConsoleWidth));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static int GameLevelSelector()
        {
            string[] menuText = { "Level 1", "Level 2", "Level 3", "Exit" };
            int select = 0;
            PrintMenu(select, menuText, ConsoleWidth);

            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                // Move up selection
                if (userInput.Key == ConsoleKey.UpArrow && select >= 1)
                {
                    select--;
                }

                // Move down selection
                if (userInput.Key == ConsoleKey.DownArrow && select <= menuText.Length - 2)
                {
                    select++;
                }

                // Stop selection process
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break;
                }

                PrintMenu(select, menuText, ConsoleWidth);
            }

            switch (select)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 0;
                default:
                    return 0;
            }
        }

        static public void PrintMenu(int s, string[] menu, int w)
        {
            Console.Clear();
            var total = w;
            Console.CursorVisible = false;
            Console.WriteLine();
            for (int i = 0; i < menu.Length; i++)
            {
                // Take care of even lenght situation
                int n = menu[i].Length % 2 == 0 ? 1 : 0;
                if (i == s) //set color for the selected option
                {
                    // Set color
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine((">  " + menu[i]).PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                             .PadRight(total));  //centering text

                    // Reset color
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                            .PadRight(total));
                }
            }
        }
    }
}
