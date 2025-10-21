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
    public partial class Menu : Form
    {
        private Game game;
        public Menu()
        {
            InitializeComponent();
            borderless(bplay);
            borderless(bquit);
            
        }
        //comment
        private void borderless(Button btn)
        {
           
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.BackColor = Color.Transparent;
        }


        private void bplay_Click(object sender, EventArgs e)
        {

            if (game == null)
                game = new Game(this); 

            this.Hide();
            game.Show();

        }

        private void bquit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
