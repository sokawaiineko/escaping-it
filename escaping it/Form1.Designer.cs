namespace escaping_it
{
    partial class Menu
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
            this.bplay = new System.Windows.Forms.Button();
            this.bquit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bplay
            // 
            this.bplay.BackgroundImage = global::escaping_it.Properties.Resources.button;
            this.bplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bplay.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 20F, System.Drawing.FontStyle.Bold);
            this.bplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.bplay.Location = new System.Drawing.Point(512, 255);
            this.bplay.Name = "bplay";
            this.bplay.Size = new System.Drawing.Size(316, 85);
            this.bplay.TabIndex = 0;
            this.bplay.Text = "PLAY";
            this.bplay.UseVisualStyleBackColor = true;
            this.bplay.Click += new System.EventHandler(this.bplay_Click);
            // 
            // bquit
            // 
            this.bquit.BackgroundImage = global::escaping_it.Properties.Resources.button;
            this.bquit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bquit.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 20F, System.Drawing.FontStyle.Bold);
            this.bquit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.bquit.Location = new System.Drawing.Point(512, 459);
            this.bquit.Name = "bquit";
            this.bquit.Size = new System.Drawing.Size(316, 85);
            this.bquit.TabIndex = 1;
            this.bquit.Text = "QUIT";
            this.bquit.UseVisualStyleBackColor = true;
            this.bquit.Click += new System.EventHandler(this.bquit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::escaping_it.Properties.Resources.sailing_ship;
            this.ClientSize = new System.Drawing.Size(1332, 760);
            this.Controls.Add(this.bquit);
            this.Controls.Add(this.bplay);
            this.Name = "Menu";
            this.Text = "menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bplay;
        private System.Windows.Forms.Button bquit;
    }
}

