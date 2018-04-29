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

            this.folderTextBox.Text = Properties.Settings.Default.InitialPath;
            this.Genre = Properties.Settings.Default.Genre;
        }

        private enum ManipulateType
        {
            Retitling,
            SettingGenre
        }

        public string Genre
        {
            get;
            set;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.folderTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void Log(string text)
        {
            this.logTextBox.AppendText(text + Environment.NewLine);
        }

        private void ManipulateFiles(ManipulateType manipulate)
        {
            this.WriteLogHeader(manipulate.ToString());

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var folder = this.folderTextBox.Text;
            var mp3Files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);

            foreach (var currentFile in mp3Files)
            {
                var file = TagLib.File.Create(currentFile);

                switch (manipulate)
                {
                    case ManipulateType.Retitling:
                        if (!this.RenamedAlready(file.Tag.Title))
                        {
                            var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;
                            var oldTitle = file.Tag.Title;

                            file.Tag.Title = newTitle;

                            this.Log(oldTitle + " renamed " + newTitle);
                        }

                        break;

                    case ManipulateType.SettingGenre:
                        file.Tag.Genres = new string[] { this.Genre };
                        this.Log(currentFile + " fixed");
                        break;
                }

                file.Save();
                this.Log("-");
            }

            stopwatch.Stop();
            this.WriteLogFooter(stopwatch.Elapsed);
        }

        private bool RenamedAlready(string title)
        {
            if (title.Length > 1)
            {
                return int.TryParse(title.Substring(0, 2), out int returnInt);
            }

            return false;
        }

        private void RetitleButton_Click(object sender, EventArgs e)
        {
            this.ManipulateFiles(ManipulateType.Retitling);
        }

        private void SetGenresButton_Click(object sender, EventArgs e)
        {
            this.ManipulateFiles(ManipulateType.SettingGenre);
        }

        private void WriteLogHeader(string caption)
        {
            this.logTextBox.Text = string.Empty;
            this.Log(caption + "...");
            this.Log("-");
        }

        private void WriteLogFooter(TimeSpan elapsed)
        {
            this.Log(string.Format("Time elapsed: {0}", elapsed));
            this.Log("Copyright © CultureBMo 2018");
            this.Log("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
            this.Log("Icon copyright © Yannick Lung http://www.yanlu.de");
        }
    }
}