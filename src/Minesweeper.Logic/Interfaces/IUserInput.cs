namespace Minesweeper.Logic.Interfaces
{
    public interface IUserInput
    {
        int ChoosenRow { get; set; }

        int ChoosenColumn { get; set; }

        // This maybe can be removed later
        string[] InputCoordinates { get; set; }

        void HandleUserInput();
    }
}