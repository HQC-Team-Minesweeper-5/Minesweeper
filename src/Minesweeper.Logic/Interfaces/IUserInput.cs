namespace Minesweeper.Logic.Interfaces
{
    public interface IUserInput
    {
        void HandleUserInput();

        int ChoosenRow { get; set; }

        int ChoosenColumn { get; set; }

        // This maybe can be removed later
        public string[] InputCoordinates { get; set; }
    }
}