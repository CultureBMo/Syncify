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
            this.retitleButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.fixGenresButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(12, 15);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(36, 13);
            this.folderLabel.TabIndex = 0;
            this.folderLabel.Text = "Folder";
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(54, 12);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(319, 20);
            this.folderTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(379, 10);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // retitleButton
            // 
            this.retitleButton.Location = new System.Drawing.Point(379, 42);
            this.retitleButton.Name = "retitleButton";
            this.retitleButton.Size = new System.Drawing.Size(75, 23);
            this.retitleButton.TabIndex = 3;
            this.retitleButton.Text = "Retitle";
            this.retitleButton.UseVisualStyleBackColor = true;
            this.retitleButton.Click += new System.EventHandler(this.RetitleButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 71);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(442, 229);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.Text = resources.GetString("logTextBox.Text");
            // 
            // fixGenresButton
            // 
            this.fixGenresButton.Location = new System.Drawing.Point(298, 42);
            this.fixGenresButton.Name = "fixGenresButton";
            this.fixGenresButton.Size = new System.Drawing.Size(75, 23);
            this.fixGenresButton.TabIndex = 5;
            this.fixGenresButton.Text = "Set Genre";
            this.fixGenresButton.UseVisualStyleBackColor = true;
            this.fixGenresButton.Click += new System.EventHandler(this.SetGenresButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 312);
            this.Controls.Add(this.fixGenresButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.retitleButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.folderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Syncify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button retitleButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button fixGenresButton;
    }
}

