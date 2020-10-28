namespace Syncify
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.Win32;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();

            if (!UsingLightTheme())
            {
                this.SetDarkMode();
            }

            this.folderTextBox.Text = Properties.Settings.Default.InitialPath;
            this.retitle.Checked = Properties.Settings.Default.Retitle;
            this.removePictures.Checked = Properties.Settings.Default.RemovePictures;
        }

        private static bool RenamedAlready(string title)
        {
            if (title.Length > 1)
            {
                return int.TryParse(title.Substring(0, 2), out int returnInt);
            }

            return false;
        }

        private static bool UsingLightTheme()
        {
            // https://stackoverflow.com/questions/38734615/how-can-i-detect-windows-10-light-dark-mode
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            var appsUseLightTheme = registryKey?.GetValue("AppsUseLightTheme");

            if (appsUseLightTheme is null)
            {
                return true;
            }
            else
            {
                return Convert.ToBoolean(appsUseLightTheme, CultureInfo.InvariantCulture);
            }
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
            this.WriteLogHeader("Retitling...");

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var folder = this.folderTextBox.Text;
            var mp3Files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);
            var jpgFiles = Directory.EnumerateFiles(folder, "*.jpg", SearchOption.AllDirectories);

            foreach (var currentFile in mp3Files)
            {
                var file = TagLib.File.Create(currentFile);

                if (!RenamedAlready(file.Tag.Title) && this.retitle.Checked)
                {
                    var newTitle = file.Tag.Track.ToString("00", CultureInfo.InvariantCulture) + " " + file.Tag.Title;
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

        private void SetDarkMode()
        {
            // set dark title bar
            NativeMethods.UseImmersiveDarkMode(this.Handle, true);

            // styles for dark mode
            var backgroundColor = Color.FromArgb(12, 12, 12);
            var foregroundColor = Color.White;
            var panelColor = Color.FromArgb(28, 28, 28);
            var buttonColor = Color.FromArgb(44, 44, 44);
            var actionButtonColor = Color.DodgerBlue;
            var buttonBorderSize = 0;
            var buttonFlatStyle = FlatStyle.Flat;
            var textboxBorderStyle = BorderStyle.None;

            // properties taken from the form designer
            this.folderTextBox.BackColor = backgroundColor;
            this.folderTextBox.BorderStyle = textboxBorderStyle;
            this.folderTextBox.ForeColor = foregroundColor;

            this.browseButton.BackColor = buttonColor;
            this.browseButton.FlatAppearance.BorderSize = buttonBorderSize;
            this.browseButton.FlatStyle = buttonFlatStyle;

            this.goButton.BackColor = actionButtonColor;
            this.goButton.FlatAppearance.BorderSize = buttonBorderSize;
            this.goButton.FlatStyle = buttonFlatStyle;

            this.logTextBox.BackColor = backgroundColor;
            this.logTextBox.BorderStyle = textboxBorderStyle;
            this.logTextBox.ForeColor = foregroundColor;

            this.retitle.BackColor = panelColor;
            this.removePictures.BackColor = panelColor;
            this.leftPanel.BackColor = panelColor;
            this.topPanel.BackColor = panelColor;

            this.BackColor = backgroundColor;
            this.ForeColor = foregroundColor;
        }

        private void WriteLogHeader(string caption)
        {
            this.logTextBox.Text = string.Empty;
            this.Log(caption + "...");
            this.Log("-");
        }

        private void WriteLogFooter(TimeSpan elapsed)
        {
            this.Log(string.Format(CultureInfo.InvariantCulture, "Time elapsed: {0}", elapsed));
            this.Log("Copyright © CultureBMo 2020");
            this.Log("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
            this.Log("Icon copyright © Yannick Lung http://www.yanlu.de");
        }
    }
}