using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MVVM_WPF_Checkers.Models;

namespace MVVM_WPF_Checkers.Services
{
    public class LogicService
    {
        private FieldState[,] _boardArray;
        private FieldState[,] _previousBoardArray;
        private readonly List<FieldState[,]> _possibleMoves;
        private readonly List<Capture> _possibleCapture;

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
            _possibleMoves = new List<FieldState[,]>();
            _possibleCapture = new List<Capture>();
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
            //var diff = GetDiff();
            //string message = "Invalid move";
            //foreach (var pawn in diff)
            //    message += String.Format(" {0}", pawn);
            //if (diff.Count == 0) return null;
            //if (diff.Count != 2) return message;
            //if (!ValidateMovePawn(diff)) return message;

            SetPossibleCapture();
            if (_possibleCapture.Any(capture => GetDiff(_boardArray, capture.BoardState).Count == 0))
                return null;
            if (_possibleCapture.Any())
                return "Obligatory capture";

            SetPossibleMoves();
            return _possibleMoves.Any(move => GetDiff(_boardArray, move).Count == 0) ? null : "Invalid move";
        }

        private void SetPossibleMoves()
        {
            _possibleMoves.Clear();

            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                {
                    var fieldState = _previousBoardArray[i, j];
                    MovePawns(i, j, fieldState);
                    MoveDames(i, j, fieldState);
                }
        }

        private void MovePawns(int x, int y, FieldState fieldState)
        {
            if (fieldState != FieldState.RedPawn && fieldState != FieldState.YellowPawn) return;
            var direction = 0;
            if (fieldState == FieldState.RedPawn) direction = 1;
            if (fieldState == FieldState.YellowPawn) direction = -1;
            MovePawn(x, y, x + direction, y + 1);
            MovePawn(x, y, x + direction, y - 1);
        }

        private void MoveDames(int x, int y, FieldState fieldState)
        {
            if (fieldState != FieldState.GreenPawn && fieldState != FieldState.BluePawn) return;
            for (var i = 0; i < 8; i++) MovePawn(x, y, x + i, y + i);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x + i, y - i);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x - i, y - i);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x - i, y + i); 
        }

        private void MovePawn(int currentX, int currentY, int newX, int newY)
        {
            if (newX < 0 || newX > 7 || newY < 0 || newY > 7) return;
            if (_previousBoardArray[newX, newY] != FieldState.Empty) return;
            var tmpBoard = (FieldState[,])_previousBoardArray.Clone();
            tmpBoard[newX, newY] = tmpBoard[currentX, currentY];
            tmpBoard[currentX, currentY] = FieldState.Empty;
            _possibleMoves.Add(tmpBoard);
        }

        private void SetPossibleCapture()
        {
            _possibleCapture.Clear();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    CapturePawns(_previousBoardArray, 0, i, j);
                    //MoveDames(i, j, fieldState);
                }
        }

        private void CapturePawns(FieldState[,] boardState, int counter, int x, int y)
        {
            if (boardState[x, y] != FieldState.RedPawn && boardState[x, y] != FieldState.YellowPawn) return;
            CapturePawn(boardState, counter, x, y, 1, 1);
            CapturePawn(boardState, counter, x, y, 1, -1);
            CapturePawn(boardState, counter, x, y, -1, -1);
            CapturePawn(boardState, counter, x, y, -1, 1);
        }

        private void CapturePawn(FieldState[,] boardState, int counter, int currentX, int currentY, int moveX, int moveY)
        {
            if (boardState[currentX, currentY] != FieldState.RedPawn) return;
            var opponentPawnX = currentX + moveX;
            var opponentPawnY = currentY + moveY;
            if (opponentPawnX < 0 || opponentPawnX > 7 || opponentPawnY < 0 || opponentPawnY > 7) return;
            var newX = currentX + (2*moveX);
            var newY = currentY + (2*moveY);
            if (newX < 0 || newX > 7 || newY < 0 || newY > 7) return;
            if (boardState[opponentPawnX, opponentPawnY] != FieldState.YellowPawn) return;
            if (boardState[newX, newY] != FieldState.Empty) return;
            var tmpBoard = (FieldState[,])boardState.Clone();
            tmpBoard[newX, newY] = tmpBoard[currentX, currentY];
            tmpBoard[currentX, currentY] = FieldState.Empty;
            tmpBoard[opponentPawnX, opponentPawnY] = FieldState.Empty;
            //sprawdzam jeszcze raz
            //jak sprawdzanie sie nie powiodło to add
            CapturePawns(tmpBoard, counter++, newX, newY);
            _possibleCapture.Add(new Capture(1, tmpBoard));
        }

        public List<Pawn> GetDiff(FieldState[,] baseArray = null, FieldState[,] compareArray = null)
        {
            if (baseArray == null) baseArray = _boardArray;
            if (compareArray == null) compareArray = _previousBoardArray;
            var result = new List<Pawn>();

            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                    if (baseArray[i, j] != compareArray[i, j])
                        result.Add(new Pawn(i, j, baseArray[i, j], compareArray[i, j]));
            return result;
        }

        private bool ValidateMovePawn(List<Pawn> diff)
        {
            var oldPawnPossition = diff.FirstOrDefault(pawn => pawn.CurrentState == FieldState.Empty);
            var newPawnPossition = diff.FirstOrDefault(pawn => pawn.CurrentState != FieldState.Empty && pawn.PreviousState == FieldState.Empty);

            if (oldPawnPossition == null || newPawnPossition == null) return false;

            var x = newPawnPossition.X - oldPawnPossition.X;
            var y = newPawnPossition.Y - oldPawnPossition.Y;

            //if (!(newPawnPossition.CurrentState != FieldState.BluePawn || newPawnPossition.CurrentState != FieldState.GreenPawn))
            if (Math.Abs(x) != 1) return false;
            if (Math.Abs(x) != Math.Abs(y)) return false;
            if (newPawnPossition.CurrentState == FieldState.RedPawn && newPawnPossition.X < oldPawnPossition.X) return false;
            if (newPawnPossition.CurrentState == FieldState.YellowPawn && newPawnPossition.X > oldPawnPossition.X) return false;

            return true;
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
}