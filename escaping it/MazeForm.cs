using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace escaping_it
{
    public partial class MazeForm : Form
    {
        //how many across n down
        int cols = 31; 
        int rows = 31; 
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
            this.DoubleBuffered = true;
            this.KeyPreview = true; 
            this.KeyDown += Maze_KeyDown;
            MazeSolved = false;
            //make maze when it starts
            //aa
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
                    //fill the maze with walls first
                    maze[x, y] = 1;
                }
            }

            //do depth first search to carve the maze
            DFS(start.X, start.Y);

            // mark start and goal
            maze[start.X, start.Y] = 4;
            maze[goal.X, goal.Y] = 3;
            maze[player.X, player.Y] = 2;

            this.Refresh();
        }

        private void DFS(int x, int y)
        {
            //mark current as open path
            maze[x, y] = 0;

            List<Point> directions = new List<Point>
            {
                new Point(1, 0),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(0, -1)
            };

            //mix directions up
            for (int i = 0; i < directions.Count; i++)
            {
                int r = rng.Next(directions.Count);
                Point temp = directions[i];
                directions[i] = directions[r];
                directions[r] = temp;
            }

            foreach (Point d in directions)
            {
                int sx = x + d.X * 2;
                int sy = y + d.Y * 2;

                //check if still inside maze and not visited yet
                if (sx >= 0 && sy >= 0 && sx < cols && sy < rows && maze[sx, sy] == 1)
                {
                    //break the wall between the cells
                    maze[x + d.X, y + d.Y] = 0;

                    //draws
                    Invalidate(new Rectangle(x * cellSize + 20, y * cellSize + 20, cellSize, cellSize));
                    Update();
                    

                    DFS(sx, sy);
                }
            }
        }

        private void Maze_KeyDown(object sender, KeyEventArgs e)
        {
            Point newPos = new Point(player.X, player.Y);

            //movement keys
            if (e.KeyCode == Keys.W)
                newPos.Y--;
            else if (e.KeyCode == Keys.S)
                newPos.Y++;
            else if (e.KeyCode == Keys.A)
                newPos.X--;
            else if (e.KeyCode == Keys.D)
                newPos.X++;

            //dont go outside
            if (newPos.X < 0 || newPos.Y < 0 || newPos.X >= cols || newPos.Y >= rows)
                return;

            //move if not wall
            if (maze[newPos.X, newPos.Y] != 1)
            {
                maze[player.X, player.Y] = 0;
                player = newPos;
                maze[player.X, player.Y] = 2;
                this.Refresh();

                // check if goal
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
                    Brush colour = Brushes.SlateBlue;

                    if (maze[x, y] == 1)

                        colour = Brushes.Black;
                    else if (maze[x, y] == 2)
                        colour = Brushes.Green;
                    else if (maze[x, y] == 3)
                        colour = Brushes.Gold;
                    else if (maze[x, y] == 4)
                        colour = Brushes.SlateBlue;

                    g.FillRectangle(colour, rect);
                    g.DrawRectangle(Pens.Gray, rect);
                }
            }

            base.OnPaint(e);
        }

    }
}
