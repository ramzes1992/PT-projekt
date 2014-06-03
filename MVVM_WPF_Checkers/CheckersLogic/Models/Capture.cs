using MVVM_WPF_Checkers.Models;

namespace CheckersLogic
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