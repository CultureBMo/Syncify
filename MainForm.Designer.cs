namespace Syncify
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderLabel = new System.Windows.Forms.Label();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.retitle = new System.Windows.Forms.CheckBox();
            this.removeImages = new System.Windows.Forms.CheckBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.mp3Logo = new System.Windows.Forms.PictureBox();
            this.syncifyLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mp3Logo)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(6, 27);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(54, 21);
            this.folderLabel.TabIndex = 0;
            this.folderLabel.Text = "Folder";
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Location = new System.Drawing.Point(80, 26);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(435, 29);
            this.folderTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(544, 25);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(91, 33);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(544, 68);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(91, 33);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.Location = new System.Drawing.Point(210, 134);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(624, 301);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.Text = resources.GetString("logTextBox.Text");
            // 
            // retitle
            // 
            this.retitle.AutoSize = true;
            this.retitle.Checked = true;
            this.retitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.retitle.Location = new System.Drawing.Point(80, 68);
            this.retitle.Name = "retitle";
            this.retitle.Size = new System.Drawing.Size(73, 25);
            this.retitle.TabIndex = 5;
            this.retitle.Text = "Retitle";
            this.retitle.UseVisualStyleBackColor = true;
            // 
            // removeImages
            // 
            this.removeImages.AutoSize = true;
            this.removeImages.Checked = true;
            this.removeImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removeImages.Location = new System.Drawing.Point(175, 68);
            this.removeImages.Name = "removeImages";
            this.removeImages.Size = new System.Drawing.Size(140, 25);
            this.removeImages.TabIndex = 3;
            this.removeImages.Text = "Remove Images";
            this.removeImages.UseVisualStyleBackColor = true;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.leftPanel.Controls.Add(this.mp3Logo);
            this.leftPanel.Controls.Add(this.syncifyLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 447);
            this.leftPanel.TabIndex = 2;
            // 
            // mp3Logo
            // 
            this.mp3Logo.Image = ((System.Drawing.Image)(resources.GetObject("mp3Logo.Image")));
            this.mp3Logo.Location = new System.Drawing.Point(14, 12);
            this.mp3Logo.Name = "mp3Logo";
            this.mp3Logo.Size = new System.Drawing.Size(64, 64);
            this.mp3Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mp3Logo.TabIndex = 6;
            this.mp3Logo.TabStop = false;
            // 
            // syncifyLabel
            // 
            this.syncifyLabel.AutoSize = true;
            this.syncifyLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncifyLabel.Location = new System.Drawing.Point(84, 27);
            this.syncifyLabel.Name = "syncifyLabel";
            this.syncifyLabel.Size = new System.Drawing.Size(90, 32);
            this.syncifyLabel.TabIndex = 7;
            this.syncifyLabel.Text = "Syncify";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topPanel.Controls.Add(this.folderLabel);
            this.topPanel.Controls.Add(this.removeImages);
            this.topPanel.Controls.Add(this.retitle);
            this.topPanel.Controls.Add(this.goButton);
            this.topPanel.Controls.Add(this.folderTextBox);
            this.topPanel.Controls.Add(this.browseButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(200, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(647, 128);
            this.topPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(847, 447);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Syncify";
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mp3Logo)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.CheckBox retitle;
        private System.Windows.Forms.CheckBox removeImages;
        private System.Windows.Forms.Label syncifyLabel;
        private System.Windows.Forms.PictureBox mp3Logo;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel topPanel;
    }
}

