namespace SHM
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Psvita = new System.Windows.Forms.RadioButton();
            this.PS4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PS3 = new System.Windows.Forms.RadioButton();
            this.Donate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Psvita
            // 
            this.Psvita.AutoSize = true;
            this.Psvita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Psvita.Location = new System.Drawing.Point(25, 56);
            this.Psvita.Name = "Psvita";
            this.Psvita.Size = new System.Drawing.Size(60, 17);
            this.Psvita.TabIndex = 49;
            this.Psvita.Text = "Psvita";
            this.Psvita.UseVisualStyleBackColor = true;
            this.Psvita.CheckedChanged += new System.EventHandler(this.Psvita_CheckedChanged);
            // 
            // PS4
            // 
            this.PS4.AutoSize = true;
            this.PS4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PS4.Location = new System.Drawing.Point(217, 56);
            this.PS4.Name = "PS4";
            this.PS4.Size = new System.Drawing.Size(48, 17);
            this.PS4.TabIndex = 50;
            this.PS4.Text = "PS4";
            this.PS4.UseVisualStyleBackColor = true;
            this.PS4.CheckedChanged += new System.EventHandler(this.PS4_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Sony Homebrew Manager 1.0";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(9, 45);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(125, 13);
            this.linkLabel2.TabIndex = 54;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = ">> Credits and thanks <<";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Download is in progress";
            this.label6.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 22);
            this.progressBar1.TabIndex = 56;
            this.progressBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 57;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.rootToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = global::SHM.Properties.Resources.menu_options;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // rootToolStripMenuItem
            // 
            this.rootToolStripMenuItem.Image = global::SHM.Properties.Resources.menu_download;
            this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
            this.rootToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.rootToolStripMenuItem.Text = "Download Path";
            this.rootToolStripMenuItem.Click += new System.EventHandler(this.rootToolStripMenuItem_Click);
            // 
            // PS3
            // 
            this.PS3.AutoSize = true;
            this.PS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PS3.Location = new System.Drawing.Point(124, 56);
            this.PS3.Name = "PS3";
            this.PS3.Size = new System.Drawing.Size(48, 17);
            this.PS3.TabIndex = 58;
            this.PS3.Text = "PS3";
            this.PS3.UseVisualStyleBackColor = true;
            this.PS3.CheckedChanged += new System.EventHandler(this.PS3_CheckedChanged);
            // 
            // Donate
            // 
            this.Donate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Donate.FlatAppearance.BorderSize = 0;
            this.Donate.Image = ((System.Drawing.Image)(resources.GetObject("Donate.Image")));
            this.Donate.Location = new System.Drawing.Point(175, 30);
            this.Donate.Margin = new System.Windows.Forms.Padding(0);
            this.Donate.Name = "Donate";
            this.Donate.Size = new System.Drawing.Size(105, 28);
            this.Donate.TabIndex = 59;
            this.Donate.UseVisualStyleBackColor = true;
            this.Donate.Click += new System.EventHandler(this.Donate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Psvita);
            this.groupBox3.Controls.Add(this.PS3);
            this.groupBox3.Controls.Add(this.PS4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 97);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Homebrew";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(6, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 77);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download Area";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.Donate);
            this.groupBox2.Location = new System.Drawing.Point(6, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 77);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credits";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(101, 13);
            this.linkLabel1.TabIndex = 60;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = ">> By MRGhidini <<";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sony Homebrew Manager ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton Psvita;
        private System.Windows.Forms.RadioButton PS4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.RadioButton PS3;
        private System.Windows.Forms.Button Donate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

