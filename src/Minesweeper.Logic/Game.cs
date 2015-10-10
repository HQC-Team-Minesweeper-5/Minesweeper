namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public sealed class Game
    {
        private const string InvalidCoordinatesText = "Illegal move";
        private const string GameEndMessage = "Your score: ";
        private const string ExitOrRestartMessage = "Enter 'restart' for new game or 'exit' to exit the game";
        private const string GameWelcomeText = "Welcome to the game “Minesweeper. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        private static Game gameInstance;

        private int numberOfRows;
        private int numberOfCols;

        private GameStatus gameStatus;
        private Printer printer;
        private Coordinates coordinates;
        private HandleUserInput userInput;

        private Game()
        {
            this.printer = new Printer();
            this.userInput = new HandleUserInput();
            this.OpenCellSaver = new OpenCellSaver();
            this.coordinates = new Coordinates(this.numberOfRows, this.numberOfCols);
            this.gameStatus = GameStatus.GameOn;
        }

        public PlayingField GameBoard { get; private set; }

        public OpenCellSaver OpenCellSaver { get; private set; }

        public int NumberOfMines { get; private set; }

        public int NumberOfFlags { get; set; }

        public static Game Instance()
        {
            if (gameInstance == null)
            {
                gameInstance = new Game();
            }

            return gameInstance;
        }
        
        public void StartNewGame()
        {
            this.PrepareGameResourses();
            Console.WriteLine(GameWelcomeText);

            while (this.gameStatus != GameStatus.Restart)
            {
                switch (this.gameStatus)
                {
                    case GameStatus.GameOn:
                        this.DisplayGameOnSection();
                        break;

                    case GameStatus.GameOver:
                        this.DisplayGameOverSection();
                        break;

                    case GameStatus.YouWin:
                        this.DisplayYouWinSection();
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
            this.NumberOfMines = level.NumberOfMines;
        }

        private void PrepareGameResourses()
        {
            MenuPrinter menuPrinter = new MenuPrinter();

            this.SelectLevel(menuPrinter.GameLevelSelector());
            this.GameBoard = new PlayingField(this.numberOfRows, this.numberOfCols, this.NumberOfMines);

            menuPrinter.ConsoleSetUp();
            menuPrinter.PrintBackground();
        }

        private void DisplayGameOnSection()
        {
            this.printer.PrintPlayingField(this.GameBoard, this.gameStatus);
            this.userInput.HandleInput(this.GameBoard);

            if (this.GameBoard.OpenCellsCounter == (this.numberOfRows * this.numberOfCols) - this.NumberOfMines)
            {
                this.gameStatus = GameStatus.YouWin;
            }

            Console.Clear();
        }

        private void DisplayYouWinSection()
        {
            Scoreboard.HighScore(this.GameBoard.OpenCellsCounter);
            Console.WriteLine("Congratulations General, you won the game!");
            Console.ReadKey();

            this.gameStatus = GameStatus.Restart;
        }

        private void DisplayGameOverSection()
        {
            Scoreboard.HighScore(this.GameBoard.OpenCellsCounter);
            this.printer.PrintPlayingField(this.GameBoard, this.gameStatus);
            this.gameStatus = GameStatus.Restart;

            int score = this.GameBoard.OpenCellsCounter;
            Console.WriteLine("GAME OVER - you are dead!");
            Console.WriteLine("{0} {1}", GameEndMessage, score);
            Console.ReadKey();
        }
    }
}
