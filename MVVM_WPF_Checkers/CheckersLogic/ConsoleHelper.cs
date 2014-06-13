using System;
using System.Collections.Generic;
using CheckersLogic.Models;

namespace CheckersLogic
{
    public static class ConsoleHelper
    {
        public static void ShowNotEmptyBoardContent(FieldState[,] board)
        {
            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                {
                    if (board[i, j] == FieldState.Empty) continue;
                    Console.WriteLine("[{0}, {1}] = {2}", i, j, board[i,j]);
                }
        }

        public static void ShowNotEmptyMovesContent(List<FieldState[,]> boardStates)
        {
            var iterator = 0;
            foreach (var board in boardStates)
            {
                Console.WriteLine("Board state - {0}", iterator++);
                ShowNotEmptyBoardContent(board);
            }
        }

        public static void ShowBoardChanges(string message, List<Pawn> pawns)
        {
            Console.WriteLine(message);
            foreach (var pawn in pawns)
                Console.WriteLine(pawn);
            Console.WriteLine("----------------------");
        }
    }
}