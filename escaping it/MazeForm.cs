using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace escaping_it
{
    public partial class MazeForm : Form
    {
        //how maxy across n down
        int col = 31; 
        int row = 31; 
        int eachCell = 25; 
        int[,] maze;
        Point player;
        Point goal;
        Point start;
        Random rng = new Random();
        public bool MazeCompleted { get; private set; }


        Stack<Point> undo = new Stack<Point>();
        int movesTaken = 0;
        int maxMoves = 0;
        int bestMoves = 0;

        public bool MazeSolved { get; private set; }

        public MazeForm()
        {
            InitializeComponent();
            this.KeyPreview = true; 
            this.KeyDown += Maze_KeyDown;
            MazeSolved = false;
            MazeCompleted=false;
            this.DoubleBuffered = true; 

            //make maze when it starts
            //aa
            MakeMaze(); 
        }

        private void MakeMaze()
        {
            maze = new int[col, row];
            goal = new Point(col - 1, row - 1);
            start = new Point(0, 0);
            player = new Point(start.X, start.Y);

            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    //make entire maze with walls first
                    maze[x, y] = 1;
                }
            }

            //do depth first search to carve the maze
            DFS(start.X, start.Y);

            // start and goal
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
                new Point(-1, 0),
                new Point(1, 0),
                new Point(0, -1),
                new Point(0, 1)

            };

            //change directions 
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
                if (sx >= 0 && sy >= 0 && sx < col && sy < row && maze[sx, sy] == 1)
                {
                    //break the wall between the cells
                    maze[x + d.X, y + d.Y] = 0;

                    //draws
                    Invalidate(new Rectangle(x * eachCell + 20, y * eachCell + 20, eachCell, eachCell));
                    Update();
                    

                    DFS(sx, sy);
                }
            }
        }
       
        private int Shortest()
        {
            int[,] distn = new int[col, row];

            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    distn[x, y] = -1;
                }
            }

            Queue<Point> q = new Queue<Point>();
            q.Enqueue(start);
            distn[start.X, start.Y] = 0;

            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            while (q.Count > 0)
            {
                Point p = q.Dequeue();

                if (p == goal)
                {
                    return distn[p.X, p.Y];
                }

                for (int i = 0; i < 4; i++)
                {
                    int xx = p.X + dx[i];
                    int xy = p.Y + dy[i];

                    if (xx < 0 || xy < 0 || xx >= col || xy >= row)
                    {
                        continue;
                    }

                    if (distn[xx, xy] != -1)
                    {
                        continue;
                    }
                    if (maze[xx, xy] == 1)
                    {   
                        continue;
                    }
                    distn[xx, xy] = distn[p.X, p.Y] + 1;
                    q.Enqueue(new Point(xx, xy));
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
            if (newPos.X < 0 || newPos.Y < 0 || newPos.X >= col || newPos.Y >= row)
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
                        MazeCompleted = true;
                        Close();
                    }
                    
                }
            }
        
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    Rectangle rect = new Rectangle(x * eachCell + 20, y * eachCell + 20, eachCell, eachCell);
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
