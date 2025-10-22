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
    public partial class LightsOutForm : Form
    {
        public LightsOutForm()
        {
            InitializeComponent();

        }
        private void LightsClicked(object sender, EventArgs e)
        {

        }
        private int[,] lights = { { 00, 10, 20 }, { 01, 11, 02 }, { 02, 12, 22 } };
    }
}
