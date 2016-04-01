namespace Syncify
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
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
            this.Log("Retitling...");
            this.Log("-");

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var folder = this.folderTextBox.Text;
            var mp3Files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);

            Parallel.ForEach(mp3Files, currentFile =>
            {
                var file = TagLib.File.Create(currentFile);
                if (!this.RenamedAlready(file.Tag.Title))
                {
                    var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;

                    file.Tag.Title = newTitle;
                    file.Save();

                    this.Invoke(new Action(() =>
                    {
                        this.Log(file.Tag.Title + " renamed " + newTitle);
                        this.Log("-");
                    }));
                }
            });

            stopwatch.Stop();

            this.Log(string.Format("Time elapsed: {0}", stopwatch.Elapsed));
            this.Log("Copyright © CultureBMo 2016");
            this.Log("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
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