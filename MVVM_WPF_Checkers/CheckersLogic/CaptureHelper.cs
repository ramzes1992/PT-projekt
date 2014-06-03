using System;
using CheckersLogic.Models;
using MVVM_WPF_Checkers.Models;

namespace CheckersLogic
{
    public static class CaptureHelper
    {
        public static void SetPossibleCapture(FieldState[,] boardState, GameState gameState)
        {
            gameState.PossibleCapture.Clear();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    CapturePawns(boardState, i, j, gameState);
                    CaptureDames(boardState, i, j, gameState);
                }
            ConsoleHelper.ShowNotEmptyMovesContent(gameState.PossibleCapture);
        }

        private static void CapturePawns(FieldState[,] boardState, int x, int y, GameState gameState)
        {
            if (boardState[x, y] != gameState.CurrentPawn) return;
            CapturePawn(boardState, x, y, 1, 1, gameState, gameState.CurrentPawn);
            CapturePawn(boardState, x, y, 1, -1, gameState, gameState.CurrentPawn);
            CapturePawn(boardState, x, y, -1, -1, gameState, gameState.CurrentPawn);
            CapturePawn(boardState, x, y, -1, 1, gameState, gameState.CurrentPawn);
        }

        private static void CaptureDames(FieldState[,] boardState, int x, int y, GameState gameState)
        {
            if (boardState[x, y] != gameState.CurrentDame) return;
            for (var i = 0; i < 8; i++) CapturePawn(boardState, x, y, i, i, gameState, gameState.CurrentDame);
            for (var i = 0; i < 8; i++) CapturePawn(boardState, x, y, i, -i, gameState, gameState.CurrentDame);
            for (var i = 0; i < 8; i++) CapturePawn(boardState, x, y, -i, -i, gameState, gameState.CurrentDame);
            for (var i = 0; i < 8; i++) CapturePawn(boardState, x, y, -i, i, gameState, gameState.CurrentDame);
        }

        private static void CapturePawn(FieldState[,] boardState, int currentX, int currentY, int moveX, int moveY, GameState gameState, FieldState currentPawnType)
        {
            var opponentPawnX = currentX + moveX;
            var opponentPawnY = currentY + moveY;
            var opponentPawn = gameState.CurrentPawn == FieldState.RedPawn ? FieldState.YellowPawn : FieldState.RedPawn;
            var opponentDame = gameState.CurrentDame == FieldState.BluePawn ? FieldState.GreenPawn : FieldState.BluePawn;
            var newX = currentX + (moveX > 0 ? moveX + 1 : moveX - 1);
            var newY = currentY + (moveY > 0 ? moveY + 1 : moveY - 1);

            if ((boardState[currentX, currentY] != currentPawnType) ||
                (opponentPawnX < 0 || opponentPawnX > 7 || opponentPawnY < 0 || opponentPawnY > 7) ||
                (newX < 0 || newX > 7 || newY < 0 || newY > 7) ||
                !((boardState[opponentPawnX, opponentPawnY] == opponentPawn) || (boardState[opponentPawnX, opponentPawnY] == opponentDame)) ||
                (boardState[newX, newY] != FieldState.Empty))
                return;

            var tmpBoard = (FieldState[,])boardState.Clone();
            tmpBoard[newX, newY] = tmpBoard[currentX, currentY];
            tmpBoard[currentX, currentY] = FieldState.Empty;
            tmpBoard[opponentPawnX, opponentPawnY] = FieldState.Empty;
            gameState.PossibleCapture.Add(tmpBoard);
        }
    }
}