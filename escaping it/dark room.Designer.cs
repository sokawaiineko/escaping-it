namespace escaping_it
{
    partial class dark_room
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
            this.lCipher = new System.Windows.Forms.Label();
            this.tAnswer = new System.Windows.Forms.TextBox();
            this.lInfo = new System.Windows.Forms.Label();
            this.bquit = new System.Windows.Forms.Button();
            this.bcheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lCipher
            // 
            this.lCipher.AutoSize = true;
            this.lCipher.Location = new System.Drawing.Point(881, 122);
            this.lCipher.Name = "lCipher";
            this.lCipher.Size = new System.Drawing.Size(51, 20);
            this.lCipher.TabIndex = 0;
            this.lCipher.Text = "label1";
            // 
            // tAnswer
            // 
            this.tAnswer.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tAnswer.Location = new System.Drawing.Point(864, 269);
            this.tAnswer.Name = "tAnswer";
            this.tAnswer.Size = new System.Drawing.Size(100, 26);
            this.tAnswer.TabIndex = 1;
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Location = new System.Drawing.Point(881, 192);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(35, 20);
            this.lInfo.TabIndex = 2;
            this.lInfo.Text = "info";
            this.lInfo.Click += new System.EventHandler(this.lInfo_Click);
            // 
            // bquit
            // 
            this.bquit.Location = new System.Drawing.Point(12, 12);
            this.bquit.Name = "bquit";
            this.bquit.Size = new System.Drawing.Size(100, 48);
            this.bquit.TabIndex = 3;
            this.bquit.Text = "quit";
            this.bquit.UseVisualStyleBackColor = true;
            this.bquit.Click += new System.EventHandler(this.bquit_Click);
            // 
            // bcheck
            // 
            this.bcheck.Location = new System.Drawing.Point(998, 262);
            this.bcheck.Name = "bcheck";
            this.bcheck.Size = new System.Drawing.Size(82, 40);
            this.bcheck.TabIndex = 4;
            this.bcheck.Text = "check";
            this.bcheck.UseVisualStyleBackColor = true;
            this.bcheck.Click += new System.EventHandler(this.bcheck_Click);
            // 
            // dark_room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1025);
            this.Controls.Add(this.bcheck);
            this.Controls.Add(this.bquit);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.tAnswer);
            this.Controls.Add(this.lCipher);
            this.Name = "dark_room";
            this.Text = "dark_room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCipher;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.TextBox tAnswer;
        private System.Windows.Forms.Button bquit;
        private System.Windows.Forms.Button bcheck;
    }
}