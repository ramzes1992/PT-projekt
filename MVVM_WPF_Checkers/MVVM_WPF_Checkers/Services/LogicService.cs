using System;
using System.Collections.Generic;
using System.Linq;
using MVVM_WPF_Checkers.Models;

namespace MVVM_WPF_Checkers.Services
{
    public class LogicService
    {
        private FieldState[,] _boardArray;
        private FieldState[,] _previousBoardArray;

        public FieldState[,] BoardArray
        {
            set
            {
                _previousBoardArray = _boardArray ?? value;
                _boardArray = value;
            }
        }

        public LogicService()
        {
            _boardArray = new FieldState[8, 8];
            _previousBoardArray = new FieldState[8, 8];
        }


        public void UpdateBoard(FieldState[,] boardArray)
        {
            BoardArray = boardArray;
        }

        public string InitialValid()
        {
            if (!(
                ValidRow(0, 0, FieldState.RedPawn) &&
                ValidRow(1, 1, FieldState.RedPawn) &&
                ValidRow(2, 0, FieldState.Empty) &&
                ValidRow(3, 1, FieldState.Empty) &&
                ValidRow(4, 0, FieldState.Empty) &&
                ValidRow(5, 1, FieldState.Empty) &&
                ValidRow(6, 0, FieldState.YellowPawn) &&
                ValidRow(7, 1, FieldState.YellowPawn)))
                return "Init failed";
            return null;
        }

        private bool ValidRow(int start, int offset, FieldState pawnType)
        {
            for (var i = offset; i < 8; i += 2)
                if (_boardArray[start, i] != pawnType)
                    return false;
            return true;
        }

        public string Validete()
        {
            var diff = GetDiff();
            string message = "Invalid move";
            foreach (var pawn in diff)
                message += String.Format(" {0}", pawn);
            if (diff.Count == 0) return null;
            if (diff.Count != 2) return message;
            if (!ValidateMovePawn(diff)) return message;

            return null;
        }

        private bool ValidateMovePawn(List<Pawn> diff)
        {
            var oldPawnPossition = diff.FirstOrDefault(pawn => pawn.CurrentState == FieldState.Empty);
            var newPawnPossition = diff.FirstOrDefault(pawn => pawn.CurrentState != FieldState.Empty && pawn.PreviousState == FieldState.Empty);

            if (oldPawnPossition == null || newPawnPossition == null) return false;

            var x = newPawnPossition.X - oldPawnPossition.X;
            var y = newPawnPossition.Y - oldPawnPossition.Y;

            if (!(newPawnPossition.CurrentState != FieldState.BluePawn || newPawnPossition.CurrentState != FieldState.GreenPawn))
                if (Math.Abs(x) != 1) return false;
            if (Math.Abs(x) != Math.Abs(y)) return false;
            if (newPawnPossition.CurrentState == FieldState.RedPawn && newPawnPossition.X < oldPawnPossition.X) return false;
            if (newPawnPossition.CurrentState == FieldState.YellowPawn && newPawnPossition.X > oldPawnPossition.X) return false;

            return true; 
        }

        public List<Pawn> GetDiff()
        {
            var result = new List<Pawn>();
            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                    if (_previousBoardArray[i, j].ToString() != _boardArray[i, j].ToString())
                        result.Add(new Pawn(i, j, _boardArray[i, j], _previousBoardArray[i, j]));

            return result;
        }

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
}