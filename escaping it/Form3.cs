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
        public bool PuzzleSolved { get; private set; }
        public LightsOutForm()
        {
            InitializeComponent();
            grid[0, 0] = b00; grid[1, 0] = b10; grid[2, 0] = b20;
            grid[0, 1] = b01; grid[1, 1] = b11; grid[2, 1] = b21;
            grid[0, 2] = b02; grid[1, 2] = b12; grid[2, 2] = b22;

            foreach (Button b in grid)
                b.Click += LightsClicked;
            

        }
        private void LightsClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int col = -1, row = -1;
            
            for (int c = 0; c < 3; c++)
                for (int r = 0; r < 3; r++)
                    if (grid[c, r] == b) { col = c; row = r; }
            
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
        private void Toggle(int c, int r)
        {
            if (c < 0 || r < 0 || c >= 3 || r >= 3) return;
            grid[c, r].BackColor = grid[c, r].BackColor == Color.Yellow ? Color.Black : Color.Yellow;
        }
        private bool WinClause()
        {
            foreach (Button b in grid)
                if (b.BackColor == Color.Yellow) return false;

            return true;
        }

    }
}
