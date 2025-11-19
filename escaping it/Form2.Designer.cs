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
            this.listinventory = new System.Windows.Forms.ListBox();
            this.linfodetail = new System.Windows.Forms.Label();
            this.lcount = new System.Windows.Forms.Label();
            this.bflashlight = new System.Windows.Forms.Button();
            this.lname = new System.Windows.Forms.Label();
            this.bcombine = new System.Windows.Forms.Button();
            this.bbattery = new System.Windows.Forms.Button();
            this.bwrench = new System.Windows.Forms.Button();
            this.bbox = new System.Windows.Forms.Button();
            this.bkey = new System.Windows.Forms.Button();
            this.blightsout = new System.Windows.Forms.Button();
            this.briddle = new System.Windows.Forms.Button();
            this.bSidedoor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bmenu
            // 
            this.bmenu.BackgroundImage = global::escaping_it.Properties.Resources.button;
            this.bmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.bmenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.bmenu.Location = new System.Drawing.Point(-9, 3);
            this.bmenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bmenu.Name = "bmenu";
            this.bmenu.Size = new System.Drawing.Size(474, 131);
            this.bmenu.TabIndex = 1;
            this.bmenu.Text = "MENU";
            this.bmenu.UseVisualStyleBackColor = true;
            this.bmenu.Click += new System.EventHandler(this.bmenu_Click);
            // 
            // listinventory
            // 
            this.listinventory.FormattingEnabled = true;
            this.listinventory.ItemHeight = 20;
            this.listinventory.Location = new System.Drawing.Point(18, 329);
            this.listinventory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listinventory.Name = "listinventory";
            this.listinventory.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listinventory.Size = new System.Drawing.Size(178, 384);
            this.listinventory.TabIndex = 2;
            this.listinventory.SelectedIndexChanged += new System.EventHandler(this.listinventory_SelectedIndexChanged);
            // 
            // linfodetail
            // 
            this.linfodetail.AutoSize = true;
            this.linfodetail.BackColor = System.Drawing.Color.Transparent;
            this.linfodetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.linfodetail.Location = new System.Drawing.Point(957, 86);
            this.linfodetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linfodetail.Name = "linfodetail";
            this.linfodetail.Size = new System.Drawing.Size(18, 25);
            this.linfodetail.TabIndex = 3;
            this.linfodetail.Text = " ";
            // 
            // lcount
            // 
            this.lcount.AutoSize = true;
            this.lcount.BackColor = System.Drawing.Color.Transparent;
            this.lcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lcount.Location = new System.Drawing.Point(14, 300);
            this.lcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lcount.Name = "lcount";
            this.lcount.Size = new System.Drawing.Size(70, 25);
            this.lcount.TabIndex = 4;
            this.lcount.Text = "label1";
            // 
            // bflashlight
            // 
            this.bflashlight.Location = new System.Drawing.Point(152, 888);
            this.bflashlight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bflashlight.Name = "bflashlight";
            this.bflashlight.Size = new System.Drawing.Size(216, 54);
            this.bflashlight.TabIndex = 5;
            this.bflashlight.Text = "flashlight placehold";
            this.bflashlight.UseVisualStyleBackColor = true;
            this.bflashlight.Click += new System.EventHandler(this.bflashlight_Click);
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.BackColor = System.Drawing.Color.Transparent;
            this.lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lname.Location = new System.Drawing.Point(957, 28);
            this.lname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(18, 25);
            this.lname.TabIndex = 6;
            this.lname.Text = " ";
            // 
            // bcombine
            // 
            this.bcombine.Location = new System.Drawing.Point(18, 742);
            this.bcombine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bcombine.Name = "bcombine";
            this.bcombine.Size = new System.Drawing.Size(112, 35);
            this.bcombine.TabIndex = 7;
            this.bcombine.Text = "combined";
            this.bcombine.UseVisualStyleBackColor = true;
            this.bcombine.Click += new System.EventHandler(this.bcombine_Click);
            // 
            // bbattery
            // 
            this.bbattery.Location = new System.Drawing.Point(962, 775);
            this.bbattery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bbattery.Name = "bbattery";
            this.bbattery.Size = new System.Drawing.Size(201, 43);
            this.bbattery.TabIndex = 8;
            this.bbattery.Text = "battery placehold";
            this.bbattery.UseVisualStyleBackColor = true;
            this.bbattery.Click += new System.EventHandler(this.bbattery_Click);
            // 
            // bwrench
            // 
            this.bwrench.Location = new System.Drawing.Point(1004, 425);
            this.bwrench.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bwrench.Name = "bwrench";
            this.bwrench.Size = new System.Drawing.Size(216, 54);
            this.bwrench.TabIndex = 9;
            this.bwrench.Text = "wrench placehold";
            this.bwrench.UseVisualStyleBackColor = true;
            this.bwrench.Click += new System.EventHandler(this.bwrench_Click);
            // 
            // bbox
            // 
            this.bbox.Location = new System.Drawing.Point(356, 375);
            this.bbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bbox.Name = "bbox";
            this.bbox.Size = new System.Drawing.Size(322, 155);
            this.bbox.TabIndex = 10;
            this.bbox.Text = "box placehold";
            this.bbox.UseVisualStyleBackColor = true;
            this.bbox.Click += new System.EventHandler(this.bbox_Click);
            // 
            // bkey
            // 
            this.bkey.Location = new System.Drawing.Point(411, 431);
            this.bkey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bkey.Name = "bkey";
            this.bkey.Size = new System.Drawing.Size(201, 43);
            this.bkey.TabIndex = 11;
            this.bkey.Text = "key placehold";
            this.bkey.UseVisualStyleBackColor = true;
            this.bkey.Click += new System.EventHandler(this.bkey_Click);
            // 
            // blightsout
            // 
            this.blightsout.Location = new System.Drawing.Point(1290, 248);
            this.blightsout.Name = "blightsout";
            this.blightsout.Size = new System.Drawing.Size(158, 145);
            this.blightsout.TabIndex = 12;
            this.blightsout.Text = "button1";
            this.blightsout.UseVisualStyleBackColor = true;
            this.blightsout.Click += new System.EventHandler(this.blightsout_Click);
            // 
            // briddle
            // 
            this.briddle.Location = new System.Drawing.Point(1059, 186);
            this.briddle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.briddle.Name = "briddle";
            this.briddle.Size = new System.Drawing.Size(112, 35);
            this.briddle.TabIndex = 13;
            this.briddle.Text = "briddle";
            this.briddle.UseVisualStyleBackColor = true;
            this.briddle.Click += new System.EventHandler(this.briddle_Click);
            // 
            // bSidedoor
            // 
            this.bSidedoor.Location = new System.Drawing.Point(694, 12);
            this.bSidedoor.Name = "bSidedoor";
            this.bSidedoor.Size = new System.Drawing.Size(145, 462);
            this.bSidedoor.TabIndex = 14;
            this.bSidedoor.Text = "button1";
            this.bSidedoor.UseVisualStyleBackColor = true;
            this.bSidedoor.Click += new System.EventHandler(this.bSidedoor_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::escaping_it.Properties.Resources.room_background;
            this.ClientSize = new System.Drawing.Size(1898, 1025);
            this.Controls.Add(this.bSidedoor);
            this.Controls.Add(this.briddle);
            this.Controls.Add(this.blightsout);
            this.Controls.Add(this.bkey);
            this.Controls.Add(this.bbox);
            this.Controls.Add(this.bwrench);
            this.Controls.Add(this.bbattery);
            this.Controls.Add(this.bcombine);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.bflashlight);
            this.Controls.Add(this.lcount);
            this.Controls.Add(this.linfodetail);
            this.Controls.Add(this.listinventory);
            this.Controls.Add(this.bmenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Game";
            this.Text = "escape room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bmenu;
        private System.Windows.Forms.ListBox listinventory;
        private System.Windows.Forms.Label linfodetail;
        private System.Windows.Forms.Label lcount;
        private System.Windows.Forms.Button bflashlight;
        private System.Windows.Forms.Label lname;
        private System.Windows.Forms.Button bcombine;
        private System.Windows.Forms.Button bbattery;
        private System.Windows.Forms.Button bwrench;
        private System.Windows.Forms.Button bbox;
        private System.Windows.Forms.Button bkey;
        private System.Windows.Forms.Button blightsout;
        private System.Windows.Forms.Button briddle;
        private System.Windows.Forms.Button bSidedoor;
    }
}