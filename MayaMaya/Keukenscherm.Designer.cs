namespace MayaMaya
{
    partial class Keukenscherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keukenscherm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Plaats = new System.Windows.Forms.Button();
            this.List_Gereed = new System.Windows.Forms.ListBox();
            this.List_Bestelling = new System.Windows.Forms.ListBox();
            this.Btn_Eten = new System.Windows.Forms.Button();
            this.Btn_Help = new System.Windows.Forms.Button();
            this.Btn_Tafels = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Btn_LogOut = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Bestellingen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(432, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 95;
            this.label1.Text = "Gereed";
            // 
            // Btn_Plaats
            // 
            this.Btn_Plaats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.Btn_Plaats.FlatAppearance.BorderSize = 0;
            this.Btn_Plaats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Plaats.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Plaats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(226)))));
            this.Btn_Plaats.Location = new System.Drawing.Point(475, 789);
            this.Btn_Plaats.Name = "Btn_Plaats";
            this.Btn_Plaats.Size = new System.Drawing.Size(164, 40);
            this.Btn_Plaats.TabIndex = 94;
            this.Btn_Plaats.Text = "Plaats Bestelling";
            this.Btn_Plaats.UseVisualStyleBackColor = false;
            // 
            // List_Gereed
            // 
            this.List_Gereed.FormattingEnabled = true;
            this.List_Gereed.Location = new System.Drawing.Point(436, 170);
            this.List_Gereed.Name = "List_Gereed";
            this.List_Gereed.Size = new System.Drawing.Size(243, 238);
            this.List_Gereed.TabIndex = 93;
            // 
            // List_Bestelling
            // 
            this.List_Bestelling.FormattingEnabled = true;
            this.List_Bestelling.Location = new System.Drawing.Point(33, 170);
            this.List_Bestelling.Name = "List_Bestelling";
            this.List_Bestelling.Size = new System.Drawing.Size(373, 238);
            this.List_Bestelling.TabIndex = 92;
            this.List_Bestelling.SelectedIndexChanged += new System.EventHandler(this.List_Kaart_SelectedIndexChanged);
            // 
            // Btn_Eten
            // 
            this.Btn_Eten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.Btn_Eten.FlatAppearance.BorderSize = 0;
            this.Btn_Eten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eten.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Eten.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(226)))));
            this.Btn_Eten.Location = new System.Drawing.Point(281, 414);
            this.Btn_Eten.Name = "Btn_Eten";
            this.Btn_Eten.Size = new System.Drawing.Size(125, 38);
            this.Btn_Eten.TabIndex = 90;
            this.Btn_Eten.Text = "Gereed";
            this.Btn_Eten.UseVisualStyleBackColor = false;
            this.Btn_Eten.Click += new System.EventHandler(this.Btn_Eten_Click);
            // 
            // Btn_Help
            // 
            this.Btn_Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.Btn_Help.FlatAppearance.BorderSize = 0;
            this.Btn_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Help.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(226)))));
            this.Btn_Help.Location = new System.Drawing.Point(695, 15);
            this.Btn_Help.Name = "Btn_Help";
            this.Btn_Help.Size = new System.Drawing.Size(48, 67);
            this.Btn_Help.TabIndex = 84;
            this.Btn_Help.Text = "?";
            this.Btn_Help.UseVisualStyleBackColor = false;
            // 
            // Btn_Tafels
            // 
            this.Btn_Tafels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(189)))), ((int)(((byte)(169)))));
            this.Btn_Tafels.FlatAppearance.BorderSize = 0;
            this.Btn_Tafels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Tafels.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Tafels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.Btn_Tafels.Location = new System.Drawing.Point(15, 51);
            this.Btn_Tafels.Name = "Btn_Tafels";
            this.Btn_Tafels.Size = new System.Drawing.Size(125, 38);
            this.Btn_Tafels.TabIndex = 83;
            this.Btn_Tafels.Text = "Keuken";
            this.Btn_Tafels.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(649, 906);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(94, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 82;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(226)))));
            this.label3.Location = new System.Drawing.Point(550, 953);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Powered By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(226)))));
            this.label2.Location = new System.Drawing.Point(182, 953);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 80;
            this.label2.Text = "Bestelsysteem MayaMaya";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 906);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.button2.Location = new System.Drawing.Point(0, 898);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(754, 95);
            this.button2.TabIndex = 78;
            this.button2.TabStop = false;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(754, 88);
            this.button1.TabIndex = 77;
            this.button1.TabStop = false;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(189)))), ((int)(((byte)(169)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.button4.Location = new System.Drawing.Point(156, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 38);
            this.button4.TabIndex = 97;
            this.button4.Text = "Voorraad";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Btn_LogOut
            // 
            this.Btn_LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(189)))), ((int)(((byte)(169)))));
            this.Btn_LogOut.FlatAppearance.BorderSize = 0;
            this.Btn_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.Btn_LogOut.Location = new System.Drawing.Point(554, 51);
            this.Btn_LogOut.Name = "Btn_LogOut";
            this.Btn_LogOut.Size = new System.Drawing.Size(125, 38);
            this.Btn_LogOut.TabIndex = 86;
            this.Btn_LogOut.Text = "Log Out";
            this.Btn_LogOut.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(74)))), ((int)(((byte)(54)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 517);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(754, 58);
            this.button3.TabIndex = 98;
            this.button3.TabStop = false;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseMnemonic = false;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Keukenscherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Plaats);
            this.Controls.Add(this.List_Gereed);
            this.Controls.Add(this.List_Bestelling);
            this.Controls.Add(this.Btn_Eten);
            this.Controls.Add(this.Btn_LogOut);
            this.Controls.Add(this.Btn_Help);
            this.Controls.Add(this.Btn_Tafels);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Keukenscherm";
            this.Text = "Keukenscherm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Plaats;
        private System.Windows.Forms.ListBox List_Gereed;
        public System.Windows.Forms.ListBox List_Bestelling;
        private System.Windows.Forms.Button Btn_Eten;
        private System.Windows.Forms.Button Btn_Help;
        private System.Windows.Forms.Button Btn_Tafels;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Btn_LogOut;
        private System.Windows.Forms.Button button3;

    }
}