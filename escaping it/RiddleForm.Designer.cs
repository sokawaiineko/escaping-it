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
            this.lhint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // riddleLabel
            // 
            this.riddleLabel.AutoSize = true;
            this.riddleLabel.Location = new System.Drawing.Point(399, 55);
            this.riddleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.riddleLabel.Name = "riddleLabel";
            this.riddleLabel.Size = new System.Drawing.Size(0, 20);
            this.riddleLabel.TabIndex = 0;
            // 
            // answerBox
            // 
            this.answerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.answerBox.Location = new System.Drawing.Point(478, 295);
            this.answerBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(148, 26);
            this.answerBox.TabIndex = 1;
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(478, 340);
            this.bSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(148, 51);
            this.bSubmit.TabIndex = 2;
            this.bSubmit.Text = "answer!";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click_1);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(520, 483);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(51, 20);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "label1";
            // 
            // lhint
            // 
            this.lhint.AutoSize = true;
            this.lhint.Location = new System.Drawing.Point(524, 434);
            this.lhint.Name = "lhint";
            this.lhint.Size = new System.Drawing.Size(51, 20);
            this.lhint.TabIndex = 4;
            this.lhint.Text = "label1";
            // 
            // RiddleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lhint);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.riddleLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Label lhint;
    }
}