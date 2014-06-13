using CheckersLogic.Models;

namespace CheckersLogic.Models
{
    public class Capture
    {
        public FieldState[,] BoardState { get; set; }

        public Capture(FieldState[,] boardState)
        {
            BoardState = boardState;
        }
    }
}