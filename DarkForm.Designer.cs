namespace Syncify
{
    partial class DarkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DarkForm));
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mp3Logo = new System.Windows.Forms.PictureBox();
            this.syncifyLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.folderLabel = new System.Windows.Forms.Label();
            this.removePictures = new System.Windows.Forms.CheckBox();
            this.retitle = new System.Windows.Forms.CheckBox();
            this.goButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mp3Logo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderTextBox
            // 
            this.folderTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.folderTextBox.ForeColor = System.Drawing.Color.White;
            this.folderTextBox.Location = new System.Drawing.Point(66, 31);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(428, 22);
            this.folderTextBox.TabIndex = 0;
            this.folderTextBox.Text = "C:\\";
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Location = new System.Drawing.Point(513, 25);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 33);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.mp3Logo);
            this.panel1.Controls.Add(this.syncifyLabel);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 448);
            this.panel1.TabIndex = 2;
            // 
            // mp3Logo
            // 
            this.mp3Logo.Image = ((System.Drawing.Image)(resources.GetObject("mp3Logo.Image")));
            this.mp3Logo.Location = new System.Drawing.Point(20, 26);
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
            this.syncifyLabel.Location = new System.Drawing.Point(81, 47);
            this.syncifyLabel.Name = "syncifyLabel";
            this.syncifyLabel.Size = new System.Drawing.Size(90, 32);
            this.syncifyLabel.TabIndex = 5;
            this.syncifyLabel.Text = "Syncify";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(58, 405);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 33);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.folderLabel);
            this.panel2.Controls.Add(this.removePictures);
            this.panel2.Controls.Add(this.retitle);
            this.panel2.Controls.Add(this.goButton);
            this.panel2.Controls.Add(this.folderTextBox);
            this.panel2.Controls.Add(this.browseButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 128);
            this.panel2.TabIndex = 3;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(6, 31);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(54, 21);
            this.folderLabel.TabIndex = 5;
            this.folderLabel.Text = "Folder";
            // 
            // removePictures
            // 
            this.removePictures.AutoSize = true;
            this.removePictures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.removePictures.Location = new System.Drawing.Point(182, 73);
            this.removePictures.Name = "removePictures";
            this.removePictures.Size = new System.Drawing.Size(140, 25);
            this.removePictures.TabIndex = 4;
            this.removePictures.Text = "Remove Images";
            this.removePictures.UseVisualStyleBackColor = false;
            // 
            // retitle
            // 
            this.retitle.AutoSize = true;
            this.retitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.retitle.Location = new System.Drawing.Point(88, 73);
            this.retitle.Name = "retitle";
            this.retitle.Size = new System.Drawing.Size(73, 25);
            this.retitle.TabIndex = 3;
            this.retitle.Text = "Retitle";
            this.retitle.UseVisualStyleBackColor = false;
            // 
            // goButton
            // 
            this.goButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.goButton.FlatAppearance.BorderSize = 0;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Location = new System.Drawing.Point(513, 68);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 33);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(210, 134);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(577, 304);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.Text = resources.GetString("logTextBox.Text");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.logTextBox);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 450);
            this.panel3.TabIndex = 5;
            // 
            // DarkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Syncify";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mp3Logo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox retitle;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.CheckBox removePictures;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label syncifyLabel;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.PictureBox mp3Logo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}