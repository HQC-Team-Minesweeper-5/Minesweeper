namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public sealed class Game
    {
        private const int consoleHeight = 29;
        private const int consoleWidth = 80;
        private int numberOfRows = 9;
        private int numberOfCols = 9;
        private int numberOfMines = 10;
        private const int MaxTopPlayers = 5;
        private const string GameWelcomeText = "Welcome to the game “Minesweeper. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        // private const string InvalidCoordinatesText = "Illegal move";
        private const string GameEndMessage = "Your score: ";
        private const string ExitOrRestartMessage = "Enter 'restart' for new game or 'exit' to exit the game";

        private static Game gameInstance;
        private PlayingField gameBoard;
        private GameStatus gameStatus;
        private Printer printer;
        private Coordinates coordinates;
        private HandleUserInput userInput;

        private Game()
        {
            //Facade
            PrepareGameResourses();
        }

        public static Game Instance()
        {
            if (gameInstance == null)
                gameInstance = new Game();

            return gameInstance;
        }

        private void PrepareGameResourses()
        {
            MenuPrinter.ConsoleSetUp();
            SelectLevel(MenuPrinter.GameLevelSelector());
            MenuPrinter.PrintBackground();

            if (numberOfMines != 0)
            {
                this.gameStatus = GameStatus.GameOn;
            }
            else
            {
                this.gameStatus = GameStatus.GameOver;
            }


            this.printer = new Printer();
            this.coordinates = new Coordinates(numberOfRows, numberOfCols);
            this.userInput = new HandleUserInput();
        }

        // State pattern?
        public void StartNewGame()
        {
            this.gameBoard = new PlayingField(numberOfRows, numberOfCols, numberOfMines);

            Console.WriteLine(GameWelcomeText);
            while (this.gameStatus != GameStatus.Restart)
            {
                switch (this.gameStatus)
                {
                    case GameStatus.GameOn:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);

                        int score;

                        userInput.HandleInput(this.gameBoard);

                        if (this.gameBoard.OpenCellsCounter == (numberOfRows * numberOfCols) - numberOfMines)
                        {
                            this.gameStatus = GameStatus.YouWin;
                        }

                        Console.Clear();
                        break;

                    case GameStatus.GameOver:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);
                        
                        score = this.gameBoard.OpenCellsCounter;
                        Console.WriteLine("GAME OVER - you are dead!");
                        Console.WriteLine("{0} {1}", GameEndMessage, score);
                        Console.ReadKey();

                        Scoreboard.HighScore(this.gameBoard.OpenCellsCounter);
                        this.gameStatus = GameStatus.Restart;
                        break;

                    case GameStatus.YouWin:
                        Console.WriteLine("Congratulations General, you won the game!");
                        Scoreboard.HighScore(this.gameBoard.OpenCellsCounter);
                        Console.ReadKey();

                        this.gameStatus = GameStatus.Restart;
                        
                        break;

                    default:
                        throw new Exception("Invalid game state!");
                }
            }
        }

        public void RestartGame()
        {
            Console.Clear();

            this.gameStatus = GameStatus.GameOn;
            this.StartNewGame();
        }

        public void ChangeToGameOver()
        {
            Console.Clear();

            this.gameStatus = GameStatus.GameOver;
        }

        private void SelectLevel(Level level)
        {
            this.numberOfRows = level.NumberOfRows;
            this.numberOfCols = level.NumberOfCols;
            this.numberOfMines = level.NumberOfMines;
        }
    }
}
