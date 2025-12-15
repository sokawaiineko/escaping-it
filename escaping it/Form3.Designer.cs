namespace escaping_it
{
    partial class LightsOutForm
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
            this.b00 = new System.Windows.Forms.Button();
            this.b10 = new System.Windows.Forms.Button();
            this.b20 = new System.Windows.Forms.Button();
            this.b21 = new System.Windows.Forms.Button();
            this.b11 = new System.Windows.Forms.Button();
            this.b01 = new System.Windows.Forms.Button();
            this.b22 = new System.Windows.Forms.Button();
            this.b12 = new System.Windows.Forms.Button();
            this.b02 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b00
            // 
            this.b00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b00.Location = new System.Drawing.Point(38, 56);
            this.b00.Margin = new System.Windows.Forms.Padding(2);
            this.b00.Name = "b00";
            this.b00.Size = new System.Drawing.Size(141, 125);
            this.b00.TabIndex = 0;
            this.b00.Text = "button1";
            this.b00.UseVisualStyleBackColor = true;
            this.b00.Click += new System.EventHandler(this.b00_Click);
            // 
            // b10
            // 
            this.b10.Location = new System.Drawing.Point(205, 56);
            this.b10.Margin = new System.Windows.Forms.Padding(2);
            this.b10.Name = "b10";
            this.b10.Size = new System.Drawing.Size(141, 125);
            this.b10.TabIndex = 1;
            this.b10.Text = "button2";
            this.b10.UseVisualStyleBackColor = true;
            // 
            // b20
            // 
            this.b20.Location = new System.Drawing.Point(373, 56);
            this.b20.Margin = new System.Windows.Forms.Padding(2);
            this.b20.Name = "b20";
            this.b20.Size = new System.Drawing.Size(141, 125);
            this.b20.TabIndex = 2;
            this.b20.Text = "button3";
            this.b20.UseVisualStyleBackColor = true;
            // 
            // b21
            // 
            this.b21.Location = new System.Drawing.Point(373, 205);
            this.b21.Margin = new System.Windows.Forms.Padding(2);
            this.b21.Name = "b21";
            this.b21.Size = new System.Drawing.Size(141, 125);
            this.b21.TabIndex = 5;
            this.b21.Text = "button4";
            this.b21.UseVisualStyleBackColor = true;
            // 
            // b11
            // 
            this.b11.Location = new System.Drawing.Point(205, 205);
            this.b11.Margin = new System.Windows.Forms.Padding(2);
            this.b11.Name = "b11";
            this.b11.Size = new System.Drawing.Size(141, 125);
            this.b11.TabIndex = 4;
            this.b11.Text = "button5";
            this.b11.UseVisualStyleBackColor = true;
            // 
            // b01
            // 
            this.b01.Location = new System.Drawing.Point(38, 205);
            this.b01.Margin = new System.Windows.Forms.Padding(2);
            this.b01.Name = "b01";
            this.b01.Size = new System.Drawing.Size(141, 125);
            this.b01.TabIndex = 3;
            this.b01.Text = "button6";
            this.b01.UseVisualStyleBackColor = true;
            // 
            // b22
            // 
            this.b22.Location = new System.Drawing.Point(373, 365);
            this.b22.Margin = new System.Windows.Forms.Padding(2);
            this.b22.Name = "b22";
            this.b22.Size = new System.Drawing.Size(141, 125);
            this.b22.TabIndex = 8;
            this.b22.Text = "button7";
            this.b22.UseVisualStyleBackColor = true;
            // 
            // b12
            // 
            this.b12.Location = new System.Drawing.Point(205, 365);
            this.b12.Margin = new System.Windows.Forms.Padding(2);
            this.b12.Name = "b12";
            this.b12.Size = new System.Drawing.Size(141, 125);
            this.b12.TabIndex = 7;
            this.b12.Text = "button8";
            this.b12.UseVisualStyleBackColor = true;
            // 
            // b02
            // 
            this.b02.Location = new System.Drawing.Point(38, 365);
            this.b02.Margin = new System.Windows.Forms.Padding(2);
            this.b02.Name = "b02";
            this.b02.Size = new System.Drawing.Size(141, 125);
            this.b02.TabIndex = 6;
            this.b02.Text = "button9";
            this.b02.UseVisualStyleBackColor = true;
            // 
            // LightsOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::escaping_it.Properties.Resources.panel_backing_for_lightsout;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 546);
            this.Controls.Add(this.b22);
            this.Controls.Add(this.b12);
            this.Controls.Add(this.b02);
            this.Controls.Add(this.b21);
            this.Controls.Add(this.b11);
            this.Controls.Add(this.b01);
            this.Controls.Add(this.b20);
            this.Controls.Add(this.b10);
            this.Controls.Add(this.b00);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LightsOutForm";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b00;
        private System.Windows.Forms.Button b10;
        private System.Windows.Forms.Button b20;
        private System.Windows.Forms.Button b21;
        private System.Windows.Forms.Button b11;
        private System.Windows.Forms.Button b01;
        private System.Windows.Forms.Button b22;
        private System.Windows.Forms.Button b12;
        private System.Windows.Forms.Button b02;
    }
}