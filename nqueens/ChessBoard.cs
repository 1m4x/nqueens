using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nqueens
{
    class ChessBoard
    {
        public int size;
        public char[,] board;
        public ChessBoard(int aSize)
        {
            size = aSize;
            board = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            board[i, j] = 'b';
                        }
                        else board[i, j] = 'w';
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            board[i, j] = 'b';
                        }
                        else board[i, j] = 'w';
                    }
                }
            }
        }
    }
}
