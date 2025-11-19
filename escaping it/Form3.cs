using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escaping_it
{
    public partial class LightsOutForm : Form
    {
        private Button[,] grid = new Button[3, 3];
        private bool[,] lights = new bool[3, 3];
        public bool PuzzleSolved { get; private set; }
        public LightsOutForm()
        {
            InitializeComponent(); 
            grid[0, 0] = b00; grid[1, 0] = b10; grid[2, 0] = b20;
            grid[0, 1] = b01; grid[1, 1] = b11; grid[2, 1] = b21;
            grid[0, 2] = b02; grid[1, 2] = b12; grid[2, 2] = b22;

            //random and then loops around the grid
            Random rng = new Random();
            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    Button b = grid[c, r];
                    b.Tag = new Point(c, r);

                    lights[c, r] = rng.Next(2) == 0;

                    b.FlatStyle = FlatStyle.Flat;
                    b.UseVisualStyleBackColor = false;
                    b.Click += LightsClicked;
                }
            }
            UpdateAllVisuals();
        }
        private void LightsClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            
            Point p = (Point)b.Tag;
            int col = p.X;
            int row = p.Y;
            Toggle(col, row);
            Toggle(col - 1, row);
            Toggle(col + 1, row);
            Toggle(col, row - 1);
            Toggle(col, row + 1);
            if (WinClause())
            {
                PuzzleSolved = true;
                this.Close();
            }

        }
        private void UpdateVisual(int c, int r)
        {

            if (c < 0 || r < 0 || c >= 3 || r >= 3)
            {
                return;
            }

            if (lights[c, r])
            {
                grid[c, r].BackColor = Color.Yellow;
                grid[c, r].Text = "ON";
            }
            else
            {
                grid[c, r].BackColor = Color.DarkGray;
                grid[c, r].Text = "OFF";
            }
        }
        private void UpdateAllVisuals()
        {
            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    UpdateVisual(c, r);
                }
            }
        }

        private void Toggle(int c, int r)
        {
            if (c < 0 || r < 0 || c >= 3 || r >= 3)
            {
                return;
            }

            lights[c, r] = !lights[c, r];
            UpdateVisual(c, r);

        }
        private bool WinClause()
        {
            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if (lights[c, r]) return false;
                }
            }
            return true;
        }

    }
}
