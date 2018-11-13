using System;

namespace EvilGameOfLife
{
    public class GameBoard
    {
        private int[,] _board;
        private readonly int _length;
        private readonly int _width;

        public GameBoard(int length = 100, int width = 100)
        {
            _length = length;
            _width = width;

            _board = new int[length, width];
            for (int i = 0; i < _board.GetLength(0); i++)
                for (int j = 0; j < _board.GetLength(1); j++)
                    _board[i, j] = 0;
        }

        public int[,] GetBoard()
        {
            return _board;
        }

        public void AddPoint(int x, int y)
        {
            _board[x, y] = 1;
        }

        public void IncrementGeneration(int generations)
        {
            for (int generation = 0; generation < generations; generation++)
            {
                var nextGenBoard = new GameBoard(_length, _width).GetBoard();
                for (int i = 0; i < _board.GetLength(0) - 1; i++)
                    for (int j = 0; j < _board.GetLength(1) - 1; j++)
                    {
                        var liveNeighbors = 0;
                        if (i != 0)
                        {
                            if (_board[i - 1, j] == 1)
                                liveNeighbors++;
                            if (j != 0 && _board[i - 1, j - 1] == 1)
                                liveNeighbors++;
                            if (j != _width && _board[i - 1, j + 1] == 1)
                                liveNeighbors++;
                        }

                        if (j != 0)
                        {
                            if (_board[i, j - 1] == 1)
                                liveNeighbors++;
                            if (i != _length && _board[i + 1, j - 1] == 1)
                                liveNeighbors++;
                        }

                        if (i != _length)
                        {
                            if (j != _width && _board[i + 1, j + 1] == 1)
                                liveNeighbors++;
                            if (_board[i + 1, j] == 1)
                                liveNeighbors++;
                        }

                        if (j != _width && _board[i, j + 1] == 1)
                            liveNeighbors++;

                        if (liveNeighbors >= 2 && liveNeighbors <= 3)
                        {
                            if (_board[i, j] == 1)
                            {
                                nextGenBoard[i, j] = 1;
                            }
                            else
                            {
                                if (liveNeighbors == 3)
                                {
                                    nextGenBoard[i, j] = 1;
                                }
                                else
                                {
                                    nextGenBoard[i, j] = 0;
                                }
                            }
                        }
                        else
                            nextGenBoard[i, j] = 0;
                    }
                _board = nextGenBoard;
            }
        }
    }
}
