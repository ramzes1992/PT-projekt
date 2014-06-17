using System;
using System.Collections.Generic;
using System.Linq;
using CheckersLogic.Models;

namespace CheckersLogic
{
    public class CheckCheckers
    {
        private GameState _gameState;
        public string Message;
        public bool IsError;
        private bool _playerCapture;

        public CheckCheckers()
        {
            _gameState = new GameState();
        }

        public void InitBoard(FieldState[,] boardArray)
        {
            _gameState = new GameState(boardArray);
            Console.WriteLine("Init new Board");
            Console.WriteLine("Current player: {0}", _gameState.CurrentPlayer + 1);
        }

        public bool InitAndValid(FieldState[,] boardArray)
        {
            InitBoard(boardArray);
            return InitialValid();
        }

        public string UpdateAndValidBoard(FieldState[,] boardArray)
        {
            if (!BoardIsNew(boardArray))
                return String.Empty;

            if (IsError && GetDiff(boardArray, _gameState.PreviousBoardArray).Count == 0)
            {
                IsError = false;
                _gameState.Restore();
                return "Now is OK";
            }

            if (!IsError)
                UpdateBoard(boardArray);

            return Message;
        }

        public void UpdateBoard(FieldState[,] boardArray)
        {
            _gameState.BoardArray = boardArray;
            CaptureHelper.SetPossibleCapture(_gameState.PreviousBoardArray, _gameState);
            MoveHelper.SetPossibleMoves(_gameState);
            Validete();
            if (MoveHelper.ChangePawnToDame(_gameState.BoardArray)) return;        
            if (_playerCapture)
            {
                CaptureHelper.SetPossibleCapture(_gameState.BoardArray, _gameState);
                if (_gameState.PossibleCapture.Any()) return;
            }
            if (!IsError)
                _gameState.UpdateCurrentPlayer();
            Console.WriteLine("Current player: {0}", _gameState.CurrentPlayer + 1);
        }

        public FieldState[,] GetCorrectBoard()
        {
            _gameState.Restore();
            return _gameState.BoardArray;
        }

        private void Validete()
        {
            _playerCapture = false;
            if (!MoveHelper.ChangedPawns(_gameState.BoardArray, _gameState.PreviousBoardArray))
            {
                IsError = true;
                const string message = "Failed Change pawn to dame";
                SetMessage(message);
                ConsoleHelper.ShowBoardChanges(message, GetDiff(_gameState.BoardArray, _gameState.PreviousBoardArray));
                return;
            }
            if (MoveHelper.ChangePawnToDame(_gameState.PreviousBoardArray) && MoveHelper.ChangedPawns(_gameState.BoardArray, _gameState.PreviousBoardArray))
            {
                IsError = false;
                SetMessage("Changed pawn to dame");
                return;
            }
            if (_gameState.PossibleCapture.Any(capture => GetDiff(_gameState.BoardArray, capture).Count == 0))
            {
                IsError = false;
                SetMessage("Capture success");
                _playerCapture = true;
                return;
            }
            if (_gameState.PossibleCapture.Any())
            {
                IsError = true;
                const string message = "Obligatory Capture";
                SetMessage("Obligatory Capture");
                ConsoleHelper.ShowBoardChanges(message, GetDiff(_gameState.BoardArray, _gameState.PreviousBoardArray));
                return;
            }
            if (_gameState.PossibleMoves.Any(move => GetDiff(_gameState.BoardArray, move).Count == 0))
            {
                IsError = false;
                SetMessage("Move Success");
                return;
            }
            IsError = true;
            SetMessage("Invalid move");
            ConsoleHelper.ShowBoardChanges("Invalid move", GetDiff(_gameState.BoardArray, _gameState.PreviousBoardArray));
        }

        private void SetMessage(string message)
        {
            var state = IsError ? "Error" : "OK";
            Message = string.Format("{0}: Player{1}- {2}", state, _gameState.CurrentPlayer + 1, message);
        }

        private bool InitialValid()
        {
            return (ValidRow(0, 1, FieldState.RedPawn) &&
                    ValidRow(1, 0, FieldState.RedPawn) &&
                    ValidRow(2, 1, FieldState.RedPawn) &&
                    ValidRow(3, 0, FieldState.Empty) &&
                    ValidRow(4, 1, FieldState.Empty) &&
                    ValidRow(5, 0, FieldState.YellowPawn) &&
                    ValidRow(6, 1, FieldState.YellowPawn) &&
                    ValidRow(7, 0, FieldState.YellowPawn));
        }

        private bool ValidRow(int start, int offset, FieldState pawnType)
        {
            for (var i = offset; i < 8; i += 2)
                if (_gameState.BoardArray[start, i] != pawnType)
                    return false;
            return true;
        }

        private bool BoardIsNew(FieldState[,] boardArray)
        {
            return (GetDiff(_gameState.BoardArray, boardArray).Count > 0);
        }

        public List<Pawn> GetDiff(FieldState[,] baseArray = null, FieldState[,] compareArray = null)
        {
            if (baseArray == null) baseArray = _gameState.BoardArray;
            if (compareArray == null) compareArray = _gameState.PreviousBoardArray;
            var result = new List<Pawn>();

            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                    if (baseArray[i, j] != compareArray[i, j])
                        result.Add(new Pawn(i, j, baseArray[i, j], compareArray[i, j]));
            return result;
        }
    }
}