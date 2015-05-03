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
        public static Stack<Frame> returnPoints = new Stack<Frame>();
        public static Stack<char[,]> solutions = new Stack<char[,]>();
        public static Timer timerControl;
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
        public static bool isSolved(PieceMap aPm)
        {
            if (returnPoints.Count == aPm.size)
            {
                return true;
            }
            else return false;
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
                        returnPoints.Push(new Frame(i, j));
                        if (isSolved(aPm))//check if we have solution
                        {
                            
                            solutions.Push(new char[aPm.size, aPm.size]); // "Who expected" that c# creates shallow copy of array instead of deep
                            for (int k = 0; k < aPm.size; k++)
                            {
                                for (int l = 0; l < aPm.size; l++)
                                {
                                    solutions.Peek()[k, l] = aPm.board[k, l];
                                }   
                            }
                            lb.Items.Add("Solution " + solutions.Count);
                        }
                        return;
                        //break;
                    }
                    if (j == aPm.size - 1 && returnPoints.Count < i + 1)//went through and didnt find place
                    {
                        if (returnPoints.Peek().y == aPm.size-1) // IF NO PLACE TO MOVE WE BACKTRACK!1
                        {
                            if (aPm.board[0,aPm.size-1] == 'q') // if we have no place to move and queen is on last row of 0 coloumn
                            {
                                timerControl.Enabled = false;
                                MessageBox.Show("No more solutions available");
                                return;
                            }
                            Take(aPm, returnPoints.Peek().x, returnPoints.Peek().y);
                            returnPoints.Pop();
                            i = returnPoints.Peek().x;
                            j = returnPoints.Peek().y;
                        }
                        Take(aPm, returnPoints.Peek().x, returnPoints.Peek().y); 
                        i = returnPoints.Peek().x;
                        j = returnPoints.Peek().y;
                        returnPoints.Pop();
                    }
                    if (isSolved(aPm))
                    {
                        if (returnPoints.Peek().y == aPm.size - 1) // IF NO PLACE TO MOVE WE BACKTRACK!1
                        {
                            Take(aPm, returnPoints.Peek().x, returnPoints.Peek().y);
                            returnPoints.Pop();
                            i = returnPoints.Peek().x;
                            j = returnPoints.Peek().y;
                        }
                        Take(aPm, returnPoints.Peek().x, returnPoints.Peek().y);
                        i = returnPoints.Peek().x;
                        j = returnPoints.Peek().y;
                        returnPoints.Pop();
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
