namespace escaping_it
{
    partial class Game
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
            this.bmenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bmenu
            // 
            this.bmenu.BackgroundImage = global::escaping_it.Properties.Resources.button;
            this.bmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bmenu.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 20F, System.Drawing.FontStyle.Bold);
            this.bmenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.bmenu.Location = new System.Drawing.Point(-6, 2);
            this.bmenu.Name = "bmenu";
            this.bmenu.Size = new System.Drawing.Size(316, 85);
            this.bmenu.TabIndex = 1;
            this.bmenu.Text = "MENU";
            this.bmenu.UseVisualStyleBackColor = true;
            this.bmenu.Click += new System.EventHandler(this.bmenu_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::escaping_it.Properties.Resources.room_background;
            this.ClientSize = new System.Drawing.Size(1332, 760);
            this.Controls.Add(this.bmenu);
            this.Name = "Game";
            this.Text = "escape room";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bmenu;
    }
}