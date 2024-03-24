namespace Syncify
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using Microsoft.Win32;

    public partial class MainForm : Form
    {
        private ILogger logger;
        private Stopwatch stopwatch = new Stopwatch();

        public MainForm()
        {
            this.InitializeComponent();

            this.logger = new TextBoxLogger(this.logTextBox);

            try
            {
                if (!UsingLightTheme())
                {
                    this.SetDarkMode();
                }

                this.folderTextBox.Text = Properties.Settings.Default.InitialPath;
                this.retitle.Checked = Properties.Settings.Default.Retitle;
                this.removeImages.Checked = Properties.Settings.Default.RemoveImages;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex);
            }
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
            try
            {
                var parentFolder = this.folderTextBox.Text;
                var retitle = this.retitle.Checked;
                var removeImages = this.removeImages.Checked;

                this.WriteLogHeader("Retitling...");
                this.stopwatch.Reset();
                this.stopwatch.Start();

                Mp3Methods.ReTitle(parentFolder, retitle, removeImages, this.logger);

                this.stopwatch.Stop();
                this.WriteLogFooter(this.stopwatch.Elapsed);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex);
            }
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
            this.removeImages.BackColor = panelColor;
            this.leftPanel.BackColor = panelColor;
            this.topPanel.BackColor = panelColor;

            this.BackColor = backgroundColor;
            this.ForeColor = foregroundColor;

            // nudge the textbox down a touch
            this.folderTextBox.Location = new Point(this.folderTextBox.Location.X, this.folderTextBox.Location.Y + 2);
        }

        private void WriteLogHeader(string caption)
        {
            this.logger.ClearLog();
            this.logger.LogInfo($"{caption}...");
            this.logger.LogInfo("-");
        }

        private void WriteLogFooter(TimeSpan elapsed)
        {
            this.logger.LogInfo($"Time elapsed: {elapsed}");
            this.logger.LogInfo("Copyright © CultureBMo 2024");
            this.logger.LogInfo("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
            this.logger.LogInfo("Icon copyright © Yannick Lung http://www.yanlu.de");
        }
    }
}