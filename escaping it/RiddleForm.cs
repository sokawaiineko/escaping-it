using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace escaping_it
{
    public partial class RiddleForm : Form
    {
        List<Riddle> riddles;
        int riddleCurrently;
        Timer riddleTimer;
        int timeLeft;
        Random rand;

        public bool KeyEarned { get; private set; }

        public RiddleForm()
        {
            InitializeComponent();
            rand = new Random();
            KeyEarned = false;
            riddleCurrently = -1;
            LoadRiddlesFromFile();
            SetupTimer();
            ShowNextRiddle();
            
        }

        private void LoadRiddlesFromFile()
        {
            riddles = new List<Riddle>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "riddles.txt");

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        riddles.Add(new Riddle(parts[0], parts[1]));
                    }
                }
            }
            else
            {
                MessageBox.Show("riddles.txt not found");
            }
        }

        private void SetupTimer()
        {
            riddleTimer = new Timer();
            riddleTimer.Interval = 1000;
            riddleTimer.Tick += RiddleTimer_Tick;
        }

        private void StartRiddleTimer()
        {
            timeLeft = 15;
            labelTimer.Text = "Time left: " + timeLeft + "s";
            riddleTimer.Start();
        }

        private void RiddleTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            labelTimer.Text = "Time left: " + timeLeft + "s";

            if (timeLeft <= 0)
            {
                riddleTimer.Stop();
                ShowNextRiddle();
            }
        }

        private void ShowNextRiddle()
        {
            if (riddles == null || riddles.Count == 0)
            {
                riddleLabel.Text = "txt file missing";
                return;
            }

           
            riddleCurrently = rand.Next(riddles.Count);

            Riddle current = riddles[riddleCurrently];
            riddleLabel.Text = current.Question;
            answerBox.Text = "";
            lhint.Text = hinting(current.Answer);
            StartRiddleTimer();
        }
        private string hinting(string answer)
        {
            string[] words = answer.Trim().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = new string('_', words[i].Length);
                }
            }
            return string.Join(" ", words);
        }
        private void CheckAnswer()
        {
            if (riddles == null || riddles.Count == 0) return;
            if (riddleCurrently < 0 || riddleCurrently >= riddles.Count) return;

            Riddle current = riddles[riddleCurrently];
            string userAnswer = answerBox.Text.Trim().ToLower();

            if (userAnswer == current.Answer.ToLower())
            {
                riddleTimer.Stop();
                KeyEarned = true;
                ;
                this.Close();
            }
            else
            {
                return;
            }
        }


        private void bSubmit_Click_1(object sender, EventArgs e)
        {
            CheckAnswer();
        }
    }
}
