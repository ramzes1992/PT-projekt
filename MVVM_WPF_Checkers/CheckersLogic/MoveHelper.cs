using System;
using CheckersLogic.Models;
using MVVM_WPF_Checkers.Models;

namespace CheckersLogic
{
    public static class MoveHelper
    {
        public static void SetPossibleMoves(GameState gameState)
        {
            Console.WriteLine("SetPossibleMoves");
            Console.WriteLine("Current player: {0}", gameState.CurrentPlayer);

            gameState.PossibleMoves.Clear();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    var fieldState = gameState.PreviousBoardArray[i, j];
                    MovePawns(i, j, fieldState, gameState);
                    MoveDames(i, j, fieldState, gameState);
                }
        }

        private static void MovePawns(int x, int y, FieldState fieldState, GameState gameState)
        {
            if (fieldState != gameState.CurrentPawn) return;
            var direction = 0;
            if (fieldState == FieldState.RedPawn) direction = 1;
            if (fieldState == FieldState.YellowPawn) direction = -1;
            MovePawn(x, y, x + direction, y + 1, gameState);
            MovePawn(x, y, x + direction, y - 1, gameState);
        }

        private static void MoveDames(int x, int y, FieldState fieldState, GameState gameState)
        {
            if (fieldState != gameState.CurrentDame) return;
            for (var i = 0; i < 8; i++) MovePawn(x, y, x + i, y + i, gameState);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x + i, y - i, gameState);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x - i, y - i, gameState);
            for (var i = 0; i < 8; i++) MovePawn(x, y, x - i, y + i, gameState);
        }

        private static void MovePawn(int currentX, int currentY, int newX, int newY, GameState gameState)
        {
            if (newX < 0 || newX > 7 || newY < 0 || newY > 7) return;
            if (gameState.PreviousBoardArray[newX, newY] != FieldState.Empty) return;
            var tmpBoard = (FieldState[,])gameState.PreviousBoardArray.Clone();
            tmpBoard[newX, newY] = tmpBoard[currentX, currentY];
            tmpBoard[currentX, currentY] = FieldState.Empty;
            gameState.PossibleMoves.Add(tmpBoard);
        } 
    }
}