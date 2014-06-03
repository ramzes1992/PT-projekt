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
                    //MoveDames(i, j, fieldState);
                }
            ConsoleHelper.ShowNotEmptyMovesContent(gameState.PossibleCapture);
        }

        private static void CapturePawns(FieldState[,] boardState, int x, int y, GameState gameState)
        {
            if (boardState[x, y] != gameState.CurrentPawn) return;
            CapturePawn(boardState, x, y, 1, 1, gameState);
            CapturePawn(boardState, x, y, 1, -1, gameState);
            CapturePawn(boardState, x, y, -1, -1, gameState);
            CapturePawn(boardState, x, y, -1, 1, gameState);
        }

        private static void CapturePawn(FieldState[,] boardState, int currentX, int currentY, int moveX, int moveY, GameState gameState)
        {
            var opponentPawnX = currentX + moveX;
            var opponentPawnY = currentY + moveY;
            var opponentPawn = gameState.CurrentPawn == FieldState.RedPawn ? FieldState.YellowPawn : FieldState.RedPawn;
            var newX = currentX + (2 * moveX);
            var newY = currentY + (2 * moveY);

            if ((boardState[currentX, currentY] != gameState.CurrentPawn) ||
                (opponentPawnX < 0 || opponentPawnX > 7 || opponentPawnY < 0 || opponentPawnY > 7) ||
                (newX < 0 || newX > 7 || newY < 0 || newY > 7) ||
                (boardState[opponentPawnX, opponentPawnY] != opponentPawn) ||
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