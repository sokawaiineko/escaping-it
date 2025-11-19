namespace escaping_it
{
    partial class RiddleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.riddleLabel = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // riddleLabel
            // 
            this.riddleLabel.AutoSize = true;
            this.riddleLabel.Location = new System.Drawing.Point(266, 36);
            this.riddleLabel.Name = "riddleLabel";
            this.riddleLabel.Size = new System.Drawing.Size(0, 13);
            this.riddleLabel.TabIndex = 0;
            // 
            // answerBox
            // 
            this.answerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.answerBox.Location = new System.Drawing.Point(310, 195);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(100, 20);
            this.answerBox.TabIndex = 1;
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(319, 221);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(91, 32);
            this.bSubmit.TabIndex = 2;
            this.bSubmit.Text = "answer!";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click_1);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(347, 314);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(35, 13);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "label1";
            // 
            // RiddleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.riddleLabel);
            this.Name = "RiddleForm";
            this.Text = "RiddleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label riddleLabel;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Label labelTimer;
    }
}