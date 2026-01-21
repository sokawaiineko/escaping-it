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

        Stack<Point> undo = new Stack<Point>();
        int movesTaken = 0;
        int maxMoves = 0;
        int bestMoves = 0;

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
            undo.Clear();
            movesTaken = 0;
            bestMoves = Shortest();
            maxMoves = bestMoves;
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
       
        private int Shortest()
        {
            int[,] dist = new int[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    dist[x, y] = -1;
                }
            }

            Queue<Point> q = new Queue<Point>();
            q.Enqueue(start);
            dist[start.X, start.Y] = 0;

            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            while (q.Count > 0)
            {
                Point p = q.Dequeue();

                if (p == goal)
                {
                    return dist[p.X, p.Y];
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = p.X + dx[i];
                    int ny = p.Y + dy[i];

                    if (nx < 0 || ny < 0 || nx >= cols || ny >= rows)
                    {
                        continue;
                    }

                    if (dist[nx, ny] != -1)
                    {
                        continue;
                    }
                    if (maze[nx, ny] == 1)
                    {   
                        continue;
                    }
                    dist[nx, ny] = dist[p.X, p.Y] + 1;
                    q.Enqueue(new Point(nx, ny));
                }
            }

            return int.MaxValue;
        }
        private void TryUndo()
        {
            if (undo.Count <= 0)
            { 
            return;
            }

            maze[player.X, player.Y] = 0;

            player = undo.Pop();
            maze[player.X, player.Y] = 2;

            if (movesTaken > 0)
            {
                movesTaken--;
            }
            this.Refresh();

        }
        private void Maze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.Back)
            {
                TryUndo();
                return;
            }

            if (movesTaken >= maxMoves)
            {
                MessageBox.Show("Out of moves.");
                return;
            }

            Point newPos = new Point(player.X, player.Y);

            //movement keys
            if (e.KeyCode == Keys.W)
            {
                newPos.Y--;
            }
            else if (e.KeyCode == Keys.S)
            {
                newPos.Y++;
            }
            else if (e.KeyCode == Keys.A)
            {
                newPos.X--;
            }
            else if (e.KeyCode == Keys.D)
            {
                newPos.X++;
            }

            //dont go outside
            if (newPos.X < 0 || newPos.Y < 0 || newPos.X >= cols || newPos.Y >= rows)
                return;

            //move if not wall
            if (maze[newPos.X, newPos.Y] != 1)
            {
                undo.Push(player);

                maze[player.X, player.Y] = 0;
                player = newPos;
                maze[player.X, player.Y] = 2;

                movesTaken++;
                this.Refresh();


                // check if goal
                if (player == goal)
                {
                    if (movesTaken == bestMoves)
                    {
                        MazeSolved = true;
                        Close();
                    }
                    
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
                    {
                        colour = Brushes.Black;
                    }
                    else if (maze[x, y] == 2)
                    {
                        colour = Brushes.Green;
                    }
                    else if (maze[x, y] == 3)
                    {
                        colour = Brushes.Gold;
                    }
                    else if (maze[x, y] == 4)
                    {
                        colour = Brushes.SlateBlue;
                    }

                    g.FillRectangle(colour, rect);
                    g.DrawRectangle(Pens.Gray, rect);
                }
            }

            base.OnPaint(e);
        }

    }
}
