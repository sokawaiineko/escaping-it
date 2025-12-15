using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace escaping_it
{
    public partial class dark_room : Form
    {
        private string plainText;
        private string cipherText;
        private int shift;
        public bool CipherSolved { get; private set; }
        public dark_room()
        {
            InitializeComponent();
            CipherSolved = false;
            Ciphering();
        }

        // ceaser shift the word rafting to a random degree
        private void Ciphering()
        {
            plainText = "rafting";
            Random rnd = new Random();
            shift = rnd.Next(1, 25);
            cipherText = Ceasaring(plainText, shift);
            lCipher.Text = cipherText;
            lInfo.Text = "Decode the message.";
            tAnswer.Text = "";
        }
        //will ceaser cipher encrypt any string
        private string Ceasaring(string text, int s)
        {
            text = text.ToLower();
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (ch < 'a' || ch > 'z')
                {
                    result[i] = ch;
                }
                else
                {
                    // change letters to 0-25 and wraps around 
                    int pos = ch - 'a';
                    pos = (pos + s) % 26;
                    result[i] = (char)('a' + pos);
                }
            }
            return new string(result);
        }
        //normalises input
        private string lowering(string s)
        {
            s=s.ToLower();
            string lowered = "";
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                    return lowered += c;
            }
            return lowered;
        }
        // runs the check
        private void bcheck_Click(object sender, EventArgs e)
        {
            string user = lowering(tAnswer.Text);
            string correct = lowering(plainText);
            if (user == correct)
            {
                CipherSolved = true;
                Close();
            }
            else
            {
                MessageBox.Show("incorrect");
            }
        }
        //closes when quit
        private void bquit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void lInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
