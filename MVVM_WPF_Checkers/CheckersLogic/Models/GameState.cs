using System.Collections.Generic;
using MVVM_WPF_Checkers.Models;

namespace CheckersLogic.Models
{
    public class GameState
    {
        public string ErrorMessage;
        public FieldState CurrentPawn;
        public FieldState CurrentDame;
        public List<FieldState[,]> PossibleMoves;
        public List<FieldState[,]> PossibleCapture;
        private int _currentPlayer;
        public FieldState[,] PreviousBoardArray;
        private FieldState[,] _boardArray;
        public FieldState[,] BoardArray
        {
            get { return _boardArray; }
            set
            {
                PreviousBoardArray = _boardArray ?? value;
                _boardArray = value;
            }
        }

        public int CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                if (value == 0)
                {
                    CurrentPawn = FieldState.RedPawn;
                    CurrentDame = FieldState.BluePawn;
                }
                else
                {
                    CurrentPawn = FieldState.YellowPawn;
                    CurrentDame = FieldState.GreenPawn;
                }
            }
        }

        public GameState()
        {
            BoardArray = new FieldState[8, 8];
            PreviousBoardArray = new FieldState[8, 8];
            PossibleMoves = new List<FieldState[,]>();
            PossibleCapture = new List<FieldState[,]>();
            CurrentPlayer = 0;
            CurrentPawn = FieldState.RedPawn;
            CurrentDame = FieldState.BluePawn;
        }

        public GameState(FieldState[,] boardArray)
        {
            BoardArray = boardArray;
            PossibleMoves = new List<FieldState[,]>();
            PossibleCapture = new List<FieldState[,]>();
            CurrentPlayer = 0;
            CurrentPawn = FieldState.RedPawn;
            CurrentDame = FieldState.BluePawn;
        }

        public void Restore()
        {
            _boardArray = PreviousBoardArray;
            //UpdateCurrentPlayer();
        }

        public void UpdateCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
        }
    }
}