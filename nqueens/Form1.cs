using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace nqueens
{
    public partial class Form1 : Form
    {
        ChessBoard cb;
        PieceMap pm;
        Image black;
        Image white;
        Image piece;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb = new ChessBoard(12);
            pm = new PieceMap(12);
            black = Image.FromFile("black.png");
            white = Image.FromFile("white.png");
            piece = Image.FromFile("piece.png");
            pm.board[0, 0] = 'q';
            pm.board[0, 1] = 'q';
            pm.board[0, 2] = 'q';
            pm.board[0, 3] = 'q';
            pm.board[0, 4] = 'q';
            pm.board[0, 5] = 'q';
            pm.board[0, 6] = 'q';
            pm.board[0, 7] = 'q';
            pm.board[0, 8] = 'q';
            pm.board[0, 9] = 'q';
            pm.board[0, 10] = 'q';
            pm.board[0, 11] = 'q';

            pm.board[11, 0] = 'q';
            pm.board[11, 1] = 'q';
            pm.board[11, 2] = 'q';
            pm.board[11, 3] = 'q';
            pm.board[11, 4] = 'q';
            pm.board[11, 5] = 'q';
            pm.board[11, 6] = 'q';
            pm.board[11, 7] = 'q';
            pm.board[11, 8] = 'q';
            pm.board[11, 9] = 'q';
            pm.board[11, 10] = 'q';
            pm.board[11, 11] = 'q';
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            for (int i = 0; i < cb.size; i++) //Drawing ChessBoard
            {
                for (int j = 0; j < cb.size; j++)
                {
                    if (cb.board[i, j] == 'w')
                        e.Graphics.DrawImage(white, i * 50, j * 50, 50, 50);
                    else
                        e.Graphics.DrawImage(black, i * 50, j * 50, 50, 50);
                }
            }

            for (int i = 0; i < pm.size; i++) //Drawing PieceMap
            {
                for (int j = 0; j < pm.size; j++)
                {
                    if (pm.board[i, j] == 'q')
                        e.Graphics.DrawImage(piece, i * 50, j * 50, 50, 50);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Solver.Check(pm, 5, 5);
            Invalidate();
        }
    }
}
