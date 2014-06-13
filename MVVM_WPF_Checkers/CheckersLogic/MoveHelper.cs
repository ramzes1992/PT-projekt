using System;
using CheckersLogic.Models;

namespace CheckersLogic
{
    public static class MoveHelper
    {
        public static void SetPossibleMoves(GameState gameState)
        {
            gameState.PossibleMoves.Clear();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    var fieldState = gameState.PreviousBoardArray[i, j];
                    MovePawns(i, j, fieldState, gameState);
                    MoveDames(i, j, fieldState, gameState);
                }
        }

        public static bool ChangePawnToDame(FieldState[,] boardArray)
        {
            for (var i = 0; i < 8; i++)
                if (boardArray[0, i] == FieldState.YellowPawn || boardArray[7, i] == FieldState.RedPawn)
                    return true;
            return false;
        }

        public static bool ChangedPawns(FieldState[,] boardArray, FieldState[,] previousBoardArray)
        {
            for (var i = 0; i < 8; i++)
                if ((previousBoardArray[7, i] == FieldState.RedPawn && boardArray[7, i] != FieldState.BluePawn) ||
                    (previousBoardArray[0, i] == FieldState.YellowPawn && boardArray[0, i] != FieldState.GreenPawn))
                        return false;
            return true;
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