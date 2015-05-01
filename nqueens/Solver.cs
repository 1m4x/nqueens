using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nqueens
{
    class Solver
    {
        public static bool Check(PieceMap aPm, int x, int y)
        {
            for (int i = y; i >= 0; i--) // Check towards top
            {
                if (aPm.board[x, i] == 'q')
                {
                    aPm.board[x, i] = '*';
                    return false;
                }
            }

            for (int i = y; i < aPm.size; i++) // Check towards bottom
            {
                if (aPm.board[x, i] == 'q')
                {
                    aPm.board[x, i] = '*';
                    return false;
                }
            }

            for (int i = x; i >= 0; i--) // Check towards left side
            {
                if (aPm.board[i, y] == 'q')
                {
                    aPm.board[i, y] = '*';
                    return false;
                }
            }

            for (int i = x; i < aPm.size; i++) // Check towards right side
            {
                if (aPm.board[i, y] == 'q')
                {
                    aPm.board[i, y] = '*';
                    return false;
                }
            }

            for (int i = x; i >= 0; i--) // Check towards top left
            {
                if (aPm.board[i, ] == 'q')
                {
                    aPm.board[i, y] = '*';
                    return false;
                }
            }
            return true;
        }
    }
}
