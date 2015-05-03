using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
        static Stack<Frame> ReturnPoints = new Stack<Frame>();
        static Stack<char[,]> solutions = new Stack<char[,]>();
        public static void Put(PieceMap aPm, int x, int y)
        {
            aPm.board[x, y] = 'q';
        }
        public static void Take(PieceMap aPm, int x, int y)
        {
            aPm.board[x, y] = '*';
        }
        public static void LoadPrev(PieceMap aPm)
        {
            aPm.board = solutions.Peek();
            solutions.Pop();
        }

        public static void Solve(PieceMap aPm, ListBox lb)
        {
            for (int i = 0; i < aPm.size; i++)
            {
                for (int j = 0; j < aPm.size; j++)
                {
                    if (Check(aPm, i, j))
                    {
                        Put(aPm, i, j);
                        ReturnPoints.Push(new Frame(i, j));
                        return;
                        //break;
                    }
                    if (j == aPm.size - 1 && ReturnPoints.Count < i + 1)//went through and didnt find place
                    {
                        if (ReturnPoints.Peek().y == aPm.size-1)
                        {
                            Take(aPm, ReturnPoints.Peek().x, ReturnPoints.Peek().y);
                            ReturnPoints.Pop();
                            i = ReturnPoints.Peek().x;
                            j = ReturnPoints.Peek().y;
                        }
                            Take(aPm, ReturnPoints.Peek().x, ReturnPoints.Peek().y);
                            i = ReturnPoints.Peek().x;
                            j = ReturnPoints.Peek().y;//+ 1; //if out of bounds step back again
                            ReturnPoints.Pop();
                    }
                    if (ReturnPoints.Count + 1 == aPm.size)
                    {
                        solutions.Push(aPm.board);
                        lb.Items.Add("Solution " + solutions.Count);
                    }
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
