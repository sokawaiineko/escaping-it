using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escaping_it
{
    public partial class MazeForm : Form
    {
        int cols = 20;
        int rows = 20;
        int cellSize = 25;
        int[,] maze;
        Point player;
        Point goal;
        Point start;
        Random rng = new Random();
        public bool MazeSolved { get; private set; }

        public MazeForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Maze_KeyDown;
            MazeSolved = false;
            MakeMaze();
        }

        private void MakeMaze()
        {
            maze = new int[cols, rows];
            goal = new Point(cols - 1, rows - 1);
            start = new Point(0, 0);
            player = new Point(start.X, start.Y);

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    bool diag = (x == y);
                    bool edge = (x == 0 && y < rows - 1) || (y == rows - 1 && x < cols);
                    if (diag || edge)
                    {
                        maze[x, y] = 0;
                    }
                    else
                    {
                        int rand = rng.Next(100);
                        if (rand < 35)
                            maze[x, y] = 1;
                        else
                            maze[x, y] = 0;
                    }
                }
            }

            maze[start.X, start.Y] = 4;
            maze[goal.X, goal.Y] = 3;
            maze[player.X, player.Y] = 2;
            this.Refresh();
        }

        private void Maze_KeyDown(object sender, KeyEventArgs e)
        {
            Point newPos = new Point(player.X, player.Y);

            if (e.KeyCode == Keys.W)
                newPos.Y--;
            else if (e.KeyCode == Keys.S)
                newPos.Y++;
            else if (e.KeyCode == Keys.A)
                newPos.X--;
            else if (e.KeyCode == Keys.D)
                newPos.X++;

            if (newPos.X < 0 || newPos.Y < 0 || newPos.X >= cols || newPos.Y >= rows)
                return;

            if (maze[newPos.X, newPos.Y] != 1)
            {
                maze[player.X, player.Y] = 0;
                player = newPos;
                maze[player.X, player.Y] = 2;
                this.Refresh();

                if (player == goal)
                {
                    MazeSolved = true;
                    Close();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Rectangle rect = new Rectangle(x * cellSize + 20, y * cellSize + 20, cellSize, cellSize);
                    Brush colour = Brushes.DarkGray;

                    if (maze[x, y] == 1)
                        colour = Brushes.Black;
                    else if (maze[x, y] == 2)
                        colour = Brushes.LightGreen;
                    else if (maze[x, y] == 3)
                        colour = Brushes.Gold;
                    else if (maze[x, y] == 4)
                        colour = Brushes.DeepSkyBlue;

                    g.FillRectangle(colour, rect);
                    g.DrawRectangle(Pens.Gray, rect);
                }
            }

            base.OnPaint(e);
        }
    }
}