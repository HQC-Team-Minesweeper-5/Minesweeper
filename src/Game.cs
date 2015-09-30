namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public static class Game
    {
        private const int MaxRows = 5;
        private const int MaxColumns = 10;
        private const int MaxMines = 15;
        private const int MaxTopPlayers = 5;

        private static Board board;
        private static List<Player> topPlayers;

        public static void Menu()
        {
            InitializeTopPlayers();

            string str = "restart";
            int choosenRow = 0;
            int chosenColumn = 0;

            while (str != "exit")
            {
                if (str == "restart")
                {
                    InitializeGameBoard();

                    Console.WriteLine("Welcome to the game “Minesweeper”. " +
                        "Try to reveal all cells without mines. " +
                        "Use 'top' to view the scoreboard, 'restart' to start a new game" +
                        "and 'exit' to quit the game.");

                    //Printer.PrintGameBoard(board.Fields, MaxRows, MaxColumns);
                    Printer.PrintGameBoard(board.PlayingBoard, MaxRows, MaxColumns);
                }
                else if (str == "exit")
                {
                    Console.WriteLine(value: "Good bye!");
                    Console.Read();
                }
                else if (str == "top")
                {
                    Top();
                }
                else if (str == "coordinates")
                {
                    try
                    {
                        Board.Status status = board.OpenField(choosenRow, chosenColumn);
                        if (status == Board.Status.SteppedOnAMine)
                        {
                            //Printer.PrintAllFields(board.Fields, MaxRows, MaxColumns);
                            Printer.PrintAllFields(board.PlayingBoard, MaxRows, MaxColumns);

                            int score = board.CountOpenedFields();
                            Console.WriteLine("Booooom! You were killed by a mine. You revealed " +
                                score +
                                " cells without mines.");

                            if (CheckHighScores(score))
                            {
                                Console.WriteLine(value: "Please enter your name for the top scoreboard: ");
                                string name = Console.ReadLine();
                                var player = new Player(name, score);
                                TopAdd(ref player);
                                Top();
                            }

                            str = "restart";
                            continue;
                        }
                        else if (status == Board.Status.AlreadyOpened)
                        {
                            Console.WriteLine(value: "Illegal move!");
                        }
                        else if (status == Board.Status.AllFieldsAreOpened)
                        {
                            //Printer.PrintAllFields(board.Fields, MaxRows, MaxColumns);
                            Printer.PrintAllFields(board.PlayingBoard, MaxRows, MaxColumns);

                            int score = board.CountOpenedFields();
                            Console.WriteLine(value: "Congratulations! You win!!");

                            if (CheckHighScores(score))
                            {
                                Console.WriteLine(value: "Please enter your name for the top scoreboard: ");
                                string name = Console.ReadLine();
                                var player = new Player(name, score);
                                TopAdd(ref player);

                                // pokazvame klasiraneto
                                Top();
                            }

                            str = "restart";
                            continue;
                        }
                        else
                        {
                            //Printer.PrintGameBoard(board.Fields, MaxRows, MaxColumns);
                            Printer.PrintGameBoard(board.PlayingBoard, MaxRows, MaxColumns);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(value: "Illegal move");
                    }
                }

                Console.Write(Environment.NewLine + "Enter row and column: ");

                str = Console.ReadLine();
                try
                {
                    choosenRow = int.Parse(str);
                    str = "coordinates";
                }
                catch
                {
                    // niama smisal tuka
                    continue;
                }

                str = Console.ReadLine();
                try
                {
                    chosenColumn = int.Parse(str);
                    str = "coordinates";
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private static void InitializeGameBoard()
        {
            board = new Board(MaxRows, MaxColumns, MaxMines);
        }

        private static void InitializeTopPlayers()
        {
            topPlayers = new List<Player>();
            topPlayers.Capacity = MaxTopPlayers;
        }

        private static bool CheckHighScores(int score)
        {
            if (topPlayers.Capacity > topPlayers.Count)
            {
                return true;
            }

            foreach (Player currentPlayer in topPlayers)
            {
                if (currentPlayer.Score < score)
                {
                    return true;
                }
            }

            return false;
        }

        private static void TopAdd(ref Player player)
        {
            if (topPlayers.Capacity > topPlayers.Count)
            {
                topPlayers.Add(player);
                topPlayers.Sort();
            }
            else
            {
                topPlayers.RemoveAt(topPlayers.Capacity - 1);
                topPlayers.Add(player);
                topPlayers.Sort();
            }
        }

        private static void Top()
        {
            Console.WriteLine(value: "Scoreboard");

            for (int i = 0; i < topPlayers.Count; i++)
            {
                Console.WriteLine((int)(i + 1) + ". " + topPlayers[i]);
            }
        }
    }
}
