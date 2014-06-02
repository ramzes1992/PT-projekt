using System;
using MVVM_WPF_Checkers.Models;

namespace CheckersLogic
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public FieldState CurrentState { get; set; }
        public FieldState PreviousState { get; set; }

        public Pawn(int x, int y, FieldState currentState, FieldState previousState)
        {
            X = x;
            Y = y;
            CurrentState = currentState;
            PreviousState = previousState;
        }

        public override string ToString()
        {
            return String.Format("[{0}][{1}]", X + 1, Y + 1);
        }
    }
}