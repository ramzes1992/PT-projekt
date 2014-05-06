using System;
using System.Collections.Generic;
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

        public List<Coordinate> GetDiff()
        {
            var result = new List<Coordinate>();
            for(var i=0; i<8; i++)
                for (var j = 0; j < 8; j++)
                    if (_previousBoardArray[i, j].ToString() != _boardArray[i, j].ToString())
                        result.Add(new Coordinate(i, j));

            return result;
        }

        public bool ShowMovedPawn()
        {

            return false;
        }

        public string TestMessage()
        {
            return _boardArray[0, 0] + " " + _previousBoardArray[0, 0];
        }

        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return String.Format("[{0}][{1}]", X, Y);
            }
        }
    }
}