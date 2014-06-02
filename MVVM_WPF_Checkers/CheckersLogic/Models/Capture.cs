using MVVM_WPF_Checkers.Models;

namespace CheckersLogic
{
    public class Capture
    {
        public int CaptureLength { get; set; }
        public FieldState[,] BoardState { get; set; }

        public Capture(int captureLength, FieldState[,] boardState)
        {
            CaptureLength = captureLength;
            BoardState = boardState;
        }
    }
}