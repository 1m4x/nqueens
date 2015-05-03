using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nqueens
{
    public partial class Form1 : Form
    {
        ChessBoard cb;
        PieceMap pm;
        Image black;
        Image white;
        Image piece;
        int size=4;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb = new ChessBoard(size);
            pm = new PieceMap(size);
            black = Image.FromFile("black.png");
            white = Image.FromFile("white.png");
            piece = Image.FromFile("piece.png");
            this.ClientSize = new Size(50 * size + 160, 50 * size);
            Solver.timerControl = timer1;
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Solver.Solve(pm, listBox1);
            System.Threading.Thread.Sleep(trackBar1.Value);
            Invalidate();
            //if (Solver.returnPoints.Count == pm.size)
            //{
            //    timer1.Enabled = false;
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pm.board = Solver.solutions.ElementAt(listBox1.SelectedIndex);
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)numericUpDown1.Value;
            cb = new ChessBoard(size);
            pm = new PieceMap(size);
            this.ClientSize = new Size(50 * size + 160, 50 * size);
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }
            else timer1.Enabled = false;
        }
    }
}
