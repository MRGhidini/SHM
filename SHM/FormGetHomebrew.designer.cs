namespace SHM
{
    partial class FormGetHomebrew
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
            this.SELECT = new System.Windows.Forms.Button();
            this.lstTitles = new System.Windows.Forms.ListView();
            this.colTitleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.LabelNameHomebrew = new System.Windows.Forms.Label();
            this.labelAuthorFix = new System.Windows.Forms.Label();
            this.LabelNameHomebrewFix = new System.Windows.Forms.Label();
            this.linkYoutube = new System.Windows.Forms.LinkLabel();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SELECT
            // 
            this.SELECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SELECT.Location = new System.Drawing.Point(142, 216);
            this.SELECT.Name = "SELECT";
            this.SELECT.Size = new System.Drawing.Size(175, 33);
            this.SELECT.TabIndex = 36;
            this.SELECT.Text = "Download";
            this.SELECT.UseVisualStyleBackColor = true;
            this.SELECT.Click += new System.EventHandler(this.SELECT_Click);
            // 
            // lstTitles
            // 
            this.lstTitles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstTitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitleID,
            this.colName,
            this.colAuthor,
            this.colVersion});
            this.lstTitles.FullRowSelect = true;
            this.lstTitles.Location = new System.Drawing.Point(15, 2);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(599, 208);
            this.lstTitles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstTitles.TabIndex = 37;
            this.lstTitles.UseCompatibleStateImageBehavior = false;
            this.lstTitles.View = System.Windows.Forms.View.Details;
            this.lstTitles.SelectedIndexChanged += new System.EventHandler(this.lstTitles_SelectedIndexChanged);
            // 
            // colTitleID
            // 
            this.colTitleID.Text = "Title ID";
            this.colTitleID.Width = 83;
            // 
            // colName
            // 
            this.colName.Text = "Homebrew";
            this.colName.Width = 205;
            // 
            // colAuthor
            // 
            this.colAuthor.Text = "Author";
            this.colAuthor.Width = 210;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 95;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelAuthor);
            this.groupBox2.Controls.Add(this.LabelNameHomebrew);
            this.groupBox2.Controls.Add(this.labelAuthorFix);
            this.groupBox2.Controls.Add(this.LabelNameHomebrewFix);
            this.groupBox2.Controls.Add(this.linkYoutube);
            this.groupBox2.Controls.Add(this.linkGitHub);
            this.groupBox2.Location = new System.Drawing.Point(620, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 204);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More Information";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(58, 78);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 13);
            this.labelAuthor.TabIndex = 69;
            this.labelAuthor.Text = "Author";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAuthor.Visible = false;
            // 
            // LabelNameHomebrew
            // 
            this.LabelNameHomebrew.AutoSize = true;
            this.LabelNameHomebrew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameHomebrew.Location = new System.Drawing.Point(58, 36);
            this.LabelNameHomebrew.Name = "LabelNameHomebrew";
            this.LabelNameHomebrew.Size = new System.Drawing.Size(66, 13);
            this.LabelNameHomebrew.TabIndex = 68;
            this.LabelNameHomebrew.Text = "Homebrew";
            this.LabelNameHomebrew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelNameHomebrew.Visible = false;
            // 
            // labelAuthorFix
            // 
            this.labelAuthorFix.AutoSize = true;
            this.labelAuthorFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorFix.Location = new System.Drawing.Point(58, 65);
            this.labelAuthorFix.Name = "labelAuthorFix";
            this.labelAuthorFix.Size = new System.Drawing.Size(44, 13);
            this.labelAuthorFix.TabIndex = 67;
            this.labelAuthorFix.Text = "Author";
            this.labelAuthorFix.Visible = false;
            // 
            // LabelNameHomebrewFix
            // 
            this.LabelNameHomebrewFix.AutoSize = true;
            this.LabelNameHomebrewFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameHomebrewFix.Location = new System.Drawing.Point(58, 23);
            this.LabelNameHomebrewFix.Name = "LabelNameHomebrewFix";
            this.LabelNameHomebrewFix.Size = new System.Drawing.Size(66, 13);
            this.LabelNameHomebrewFix.TabIndex = 66;
            this.LabelNameHomebrewFix.Text = "Homebrew";
            this.LabelNameHomebrewFix.Visible = false;
            // 
            // linkYoutube
            // 
            this.linkYoutube.AutoSize = true;
            this.linkYoutube.Location = new System.Drawing.Point(6, 139);
            this.linkYoutube.Name = "linkYoutube";
            this.linkYoutube.Size = new System.Drawing.Size(179, 13);
            this.linkYoutube.TabIndex = 65;
            this.linkYoutube.TabStop = true;
            this.linkYoutube.Text = "Open link video Yutube for more info";
            this.linkYoutube.Visible = false;
            this.linkYoutube.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkYoutube_LinkClicked);
            // 
            // linkGitHub
            // 
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.Location = new System.Drawing.Point(32, 113);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(118, 13);
            this.linkGitHub.TabIndex = 64;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "Release page / Source";
            this.linkGitHub.Visible = false;
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(376, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 33);
            this.button1.TabIndex = 64;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGetHomebrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 256);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lstTitles);
            this.Controls.Add(this.SELECT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGetHomebrew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGetDLC";
            this.Load += new System.EventHandler(this.FormGetDLC_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SELECT;
        private System.Windows.Forms.ListView lstTitles;
        private System.Windows.Forms.ColumnHeader colTitleID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAuthor;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkYoutube;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Label LabelNameHomebrewFix;
        private System.Windows.Forms.Label labelAuthorFix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelNameHomebrew;
        private System.Windows.Forms.Label labelAuthor;
    }
}