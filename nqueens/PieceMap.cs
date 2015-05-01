using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nqueens
{
    class PieceMap
    {
        public int size;
        public char[,] board;
        public PieceMap(int aSize)
        {
            size = aSize;
            board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = '*';
                }
            }
        }
    }
}
