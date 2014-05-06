using System;
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
                _previousBoardArray = _boardArray;
                _boardArray = value;
            }
        }

        public LogicService()
        {
            _boardArray = new FieldState[8,8];
            _previousBoardArray = new FieldState[8, 8];
        }

        public string TestMessage()
        {
            return _boardArray[0, 0] + " " + _previousBoardArray[0, 0];
        }
    }
}