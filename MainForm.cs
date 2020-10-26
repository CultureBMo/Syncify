namespace Syncify
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();

            //https://stackoverflow.com/questions/38734615/how-can-i-detect-windows-10-light-dark-mode
            ////var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            ////var appsUseLightTheme = registryKey?.GetValue("AppsUseLightTheme");

            if (Properties.Settings.Default.DarkMode)
            {
                NativeMethods.UseImmersiveDarkMode(this.Handle, true);
            }

            this.folderTextBox.Text = Properties.Settings.Default.InitialPath;
            this.retitle.Checked = Properties.Settings.Default.Retitle;
            this.removePictures.Checked = Properties.Settings.Default.RemovePictures;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.folderTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            this.WriteLogHeader("Retitling...");

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var folder = this.folderTextBox.Text;
            var mp3Files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);

            var jpgFiles = Directory.EnumerateFiles(folder, "*.jpg", SearchOption.AllDirectories);


            foreach (var currentFile in mp3Files)
            {
                var file = TagLib.File.Create(currentFile);

                if (!this.RenamedAlready(file.Tag.Title) && this.retitle.Checked)
                {
                    var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;
                    var oldTitle = file.Tag.Title;

                    file.Tag.Title = newTitle;

                    this.Log(oldTitle + " renamed " + newTitle);
                }

                // remove pictures in the folder that may be associated
                if (this.removePictures.Checked)
                {
                    if (jpgFiles.Any())
                    {
                        foreach (var jpg in jpgFiles)
                        {
                            File.Delete(jpg);
                        }
                    }

                    file.Tag.Pictures = Array.Empty<TagLib.IPicture>();

                    this.Log("Removed image from " + file.Tag.Title);
                }

                file.Save();
                file.Dispose();

                this.Log("-");
            }

            stopwatch.Stop();
            this.WriteLogFooter(stopwatch.Elapsed);
        }

        private void Log(string text)
        {
            this.logTextBox.AppendText(text + Environment.NewLine);
        }

        private bool RenamedAlready(string title)
        {
            if (title.Length > 1)
            {
                return int.TryParse(title.Substring(0, 2), out int returnInt);
            }

            return false;
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
            this.Log("Copyright © CultureBMo 2020");
            this.Log("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
            this.Log("Icon copyright © Yannick Lung http://www.yanlu.de");
        }
    }
}