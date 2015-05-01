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
            cb = new ChessBoard(6);
            pm = new PieceMap(6);
            black = Image.FromFile("black.png");
            white = Image.FromFile("white.png");
            piece = Image.FromFile("piece.png");
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
            Solver.Solve(pm);
            //Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
