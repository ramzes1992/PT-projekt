using System.Collections.Generic;
using System.Linq;
using CheckersLogic.Models;
using MVVM_WPF_Checkers.Models;

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
                SetMessage("Failed Change pawn to dame");
                IsError = true;
                return;
            }
            if (MoveHelper.ChangePawnToDame(_gameState.PreviousBoardArray) && MoveHelper.ChangedPawns(_gameState.BoardArray, _gameState.PreviousBoardArray))
            {
                SetMessage("Changed pawn to dame");
                IsError = false;
                return;
            }
            if (_gameState.PossibleCapture.Any(capture => GetDiff(_gameState.BoardArray, capture).Count == 0))
            {
                SetMessage("Capture success");
                IsError = false;
                _playerCapture = true;
                return;
            }
            if (_gameState.PossibleCapture.Any())
            {
                SetMessage("Obligatory Capture");
                IsError = true;
                return;
            }
            if (_gameState.PossibleMoves.Any(move => GetDiff(_gameState.BoardArray, move).Count == 0))
            {
                SetMessage("Move Success");
                IsError = false;
                return;
            }
            SetMessage("Invalid move");
            IsError = true;
        }

        private void SetMessage(string message)
        {
            Message = string.Format("Player{0}- {1}", _gameState.CurrentPlayer + 1, message);
        }

        public string InitialValid()
        {
            if (!(
                ValidRow(0, 0, FieldState.RedPawn) &&
                ValidRow(1, 1, FieldState.RedPawn) &&
                ValidRow(2, 0, FieldState.RedPawn) &&
                ValidRow(3, 1, FieldState.Empty) &&
                ValidRow(4, 0, FieldState.Empty) &&
                ValidRow(5, 1, FieldState.YellowPawn) &&
                ValidRow(6, 0, FieldState.YellowPawn) &&
                ValidRow(7, 1, FieldState.YellowPawn)))
                return "Init failed";
            return null;
        }

        private bool ValidRow(int start, int offset, FieldState pawnType)
        {
            for (var i = offset; i < 8; i += 2)
                if (_gameState.BoardArray[start, i] != pawnType)
                    return false;
            return true;
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