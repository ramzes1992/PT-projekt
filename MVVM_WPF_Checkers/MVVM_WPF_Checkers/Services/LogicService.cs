using System;
using System.Collections.Generic;
using System.Linq;
using MVVM_WPF_Checkers.Models;

namespace MVVM_WPF_Checkers.Services
{
    public class LogicService
    {
        public string StateMessage;
        public string ErrorMessage;
        private FieldState[,] _boardArray;
        private FieldState[,] _previousBoardArray;
        private FieldState _currentPawn;
        private FieldState _currentDame;
        private readonly List<FieldState[,]> _possibleMoves;
        private readonly List<Capture> _possibleCapture;
        private int _currentPlayer;

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
            _currentPlayer = 0;
            _currentPawn = FieldState.RedPawn;
            _currentDame = FieldState.BluePawn;
        }

        public FieldState[,] GetCorrectBoard()
        {
            _boardArray = _previousBoardArray;
            _currentPlayer = _currentPlayer == 0 ? 1 : 0;
            return _previousBoardArray;
        }

        public void InitBoard(FieldState[,] boardArray)
        {
            _boardArray = boardArray;
            _previousBoardArray = boardArray;
            _currentPlayer = 0;
            _currentPawn = _currentPlayer == 0 ? FieldState.RedPawn : FieldState.YellowPawn;
            _currentDame = _currentPlayer == 0 ? FieldState.BluePawn : FieldState.GreenPawn;
            SetPossibleCapture(_boardArray);
            SetPossibleMoves();
            StateMessage = _currentPlayer == 0 ? "First Player move \n " : "Second Player move \n ";
        }

        public void UpdateBoard(FieldState[,] boardArray)
        {
            BoardArray = boardArray;
            _currentPawn = _currentPlayer == 0 ? FieldState.RedPawn : FieldState.YellowPawn;
            _currentDame = _currentPlayer == 0 ? FieldState.BluePawn : FieldState.GreenPawn;
            SetPossibleCapture(_boardArray);
            SetPossibleMoves();
            StateMessage = _currentPlayer == 0 ? "First Player move \n " + CheckObligatoryCapture() : "Second Player move \n " + CheckObligatoryCapture();
            _currentPlayer = _currentPlayer == 0 ? 1 : 0;
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

        private string CheckObligatoryCapture()
        {
            if (_possibleCapture.Any())
                return "Obligatory capture";
            return null;
        }

        public string Validete()
        {
            SetPossibleCapture(_previousBoardArray);

            if (_possibleCapture.Any(capture => GetDiff(_boardArray, capture.BoardState).Count == 0))
                return null;
            if (_possibleCapture.Any())
                return "Obligatory capture";

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
            if (fieldState != _currentPawn) return;
            var direction = 0;
            if (fieldState == FieldState.RedPawn) direction = 1;
            if (fieldState == FieldState.YellowPawn) direction = -1;
            MovePawn(x, y, x + direction, y + 1);
            MovePawn(x, y, x + direction, y - 1);
        }

        private void MoveDames(int x, int y, FieldState fieldState)
        {
            if (fieldState != _currentDame) return;
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

        private void SetPossibleCapture(FieldState[,] boardState)
        {
            _possibleCapture.Clear();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    CapturePawns(boardState, 0, i, j);
                    //MoveDames(i, j, fieldState);
                }
        }

        private void CapturePawns(FieldState[,] boardState, int counter, int x, int y)
        {
            if (boardState[x, y] != _currentPawn) return;
            CapturePawn(boardState, counter, x, y, 1, 1);
            CapturePawn(boardState, counter, x, y, 1, -1);
            CapturePawn(boardState, counter, x, y, -1, -1);
            CapturePawn(boardState, counter, x, y, -1, 1);
        }

        private void CapturePawn(FieldState[,] boardState, int counter, int currentX, int currentY, int moveX, int moveY)
        {

            var opponentPawnX = currentX + moveX;
            var opponentPawnY = currentY + moveY;
            var opponentPawn = _currentPawn == FieldState.RedPawn ? FieldState.YellowPawn : FieldState.RedPawn;
            var newX = currentX + (2*moveX);
            var newY = currentY + (2*moveY);

            if ( 
                (boardState[currentX, currentY] != _currentPawn) ||
                (opponentPawnX < 0 || opponentPawnX > 7 || opponentPawnY < 0 || opponentPawnY > 7) ||
                (newX < 0 || newX > 7 || newY < 0 || newY > 7) ||
                (boardState[opponentPawnX, opponentPawnY] != opponentPawn) ||
                (boardState[newX, newY] != FieldState.Empty)
                )
            {
                if (counter > 0) _possibleCapture.Add(new Capture(counter, boardState));
                return;
            }

            var tmpBoard = (FieldState[,])boardState.Clone();
            tmpBoard[newX, newY] = tmpBoard[currentX, currentY];
            tmpBoard[currentX, currentY] = FieldState.Empty;
            tmpBoard[opponentPawnX, opponentPawnY] = FieldState.Empty;
            CapturePawns(tmpBoard, ++counter, newX, newY);
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