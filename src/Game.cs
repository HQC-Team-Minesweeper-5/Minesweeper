namespace Minesweeper
{
    using Enumerations;
    using System;

    public static class Game
    {
        private const int MaxRows = 5;
        private const int MaxColumns = 10;
        private const int MaxMines = 15;
        private const int MaxTopPlayers = 5;

        private static Board board;

        private static void InitializeGameBoard()
        {
            board = new Board(MaxRows, MaxColumns, MaxMines);
        }

        public static void Menu()
        {
			TopPlayers.Initialize(MaxTopPlayers);

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
					TopPlayers.PrintScoreboard();
                }
                else if (str == "coordinates")
                {
                    try
                    {
                        Status status = board.OpenField(choosenRow, chosenColumn);
                        if (status == Status.SteppedOnAMine)
                        {
                            //Printer.PrintAllFields(board.Fields, MaxRows, MaxColumns);
                            Printer.PrintAllFields(board.PlayingBoard, MaxRows, MaxColumns);

                            int score = board.CountOpenedFields();
                            Console.WriteLine("Booooom! You were killed by a mine. You revealed " +
                                score +
                                " cells without mines.");

							if (TopPlayers.CheckHighScores(score))
                            {
                                Console.WriteLine(value: "Please enter your name for the top scoreboard: ");
                                string name = Console.ReadLine();
                                var player = new Player(name, score);
								TopPlayers.Add(ref player);
								TopPlayers.PrintScoreboard();
                            }

                            str = "restart";
                            continue;
                        }
                        else if (status == Status.AlreadyOpened)
                        {
                            Console.WriteLine(value: "Illegal move!");
                        }
                        else if (status == Status.AllFieldsAreOpened)
                        {
                            //Printer.PrintAllFields(board.Fields, MaxRows, MaxColumns);
                            Printer.PrintAllFields(board.PlayingBoard, MaxRows, MaxColumns);

                            int score = board.CountOpenedFields();
                            Console.WriteLine(value: "Congratulations! You win!!");

							if (TopPlayers.CheckHighScores(score))
                            {
                                Console.WriteLine(value: "Please enter your name for the top scoreboard: ");
                                string name = Console.ReadLine();
                                var player = new Player(name, score);
								TopPlayers.Add(ref player);

                                // pokazvame klasiraneto
								TopPlayers.PrintScoreboard();
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
    }
}
