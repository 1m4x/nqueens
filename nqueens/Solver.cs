using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace nqueens
{
    public struct Frame
    {
        public int x, y;
        public Frame(int aX, int aY)
        {
            x = aX;
            y = aY;
        }
    }
    class Solver
    {
        public static void Put(PieceMap aPm, int x, int y)
        {
            aPm.board[x, y] = 'q';
        }
        public static void Take(PieceMap aPm, int x, int y)
        {
            aPm.board[x, y] = '*';
        }
        public static void Solve(PieceMap aPm)
        {
            Stack<Frame> ReturnPoints = new Stack<Frame>();
            int yToStart = 0;
            int xToStart = 0;
            for (int i = xToStart; i < aPm.size; i++)
            {
                for (int j = yToStart; j < aPm.size; j++)
                {
                    if (Check(aPm, i, j))
                    {
                        Put(aPm, i, j);
                        ReturnPoints.Push(new Frame(i, j));
                        break;
                    }
                }
                if (ReturnPoints.Count < i) // If we reached end of coloumn without puting piece
                {
                    Take(aPm, ReturnPoints.Peek().x, ReturnPoints.Peek().y);
                    j = ReturnPoints.Peek().y;
                    ReturnPoints.Pop();
                }           
            }
        }
        public static bool Check(PieceMap aPm, int x, int y)
        {
            for (int i = y; i >= 0; i--) // Check towards top
            {
                if (aPm.board[x, i] == 'q')
                {
                    //aPm.board[x, i] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = y; i < aPm.size; i++) // Check towards bottom
            {
                if (aPm.board[x, i] == 'q')
                {
                    //aPm.board[x, i] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = x; i >= 0; i--) // Check towards left side
            {
                if (aPm.board[i, y] == 'q')
                {
                    //aPm.board[i, y] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = x; i < aPm.size; i++) // Check towards right side
            {
                if (aPm.board[i, y] == 'q')
                {
                    //aPm.board[i, y] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = 0; i <= x && i <= y; i++) // Check towards top left
            {
                if (aPm.board[x-i, y-i] == 'q')
                {
                    //aPm.board[x-i, y-i] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = 0; i <= x && i <= (aPm.size - 1) - y; i++) // Check towards bottom left
            {
                if (aPm.board[x - i, y + i] == 'q')
                {
                    //aPm.board[x - i, y + i] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = 0; i <= (aPm.size - 1) - x && i <= y; i++) // Check towards top right
            {
                if (aPm.board[x + i, y - i] == 'q')
                {
                    //aPm.board[x + i, y - i] = '*'; //only for debug
                    return false;
                }
            }

            for (int i = 0; i <= (aPm.size - 1) - x && i <= (aPm.size - 1) - y; i++) // Check towards bottom right
            {
                if (aPm.board[x + i, y + i] == 'q')
                {
                    //aPm.board[x + i, y + i] = '*'; //only for debug
                    return false;
                }
            }
            return true;
        }
    }
}
