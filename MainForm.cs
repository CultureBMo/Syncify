namespace Syncify
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.folderTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            this.logTextBox.Text = string.Empty;
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            this.Log("Retitling...");
            this.Log("-");

            var folder = this.folderTextBox.Text;
            var mp3Files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);

            foreach (var mp3File in mp3Files)
            {
                var file = TagLib.File.Create(mp3File);
                if (!this.RenamedAlready(file.Tag.Title))
                {
                    var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;

                    this.Log(file.Tag.Title + " renamed " + newTitle);
                    this.Log("-");

                    file.Tag.Title = newTitle;
                    file.Save();
                }

                Application.DoEvents();
            }

            stopwatch.Stop();
            this.Log(string.Format("Time elapsed: {0}", stopwatch.Elapsed));
            this.Log("Copyright © CultureBMo 2015");
            this.Log("Icon copyright © Yannick Lung http://www.yanlu.de");
        }

        private void Log(string text)
        {
            this.logTextBox.AppendText(text + Environment.NewLine);
        }

        private bool RenamedAlready(string title)
        {
            if (title.Length > 1)
            {
                int returnInt;
                return int.TryParse(title.Substring(0, 2), out returnInt);
            }

            return false;
        }
    }
}