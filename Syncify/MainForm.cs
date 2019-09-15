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

            // get default values from config file
            this.folderTextBox.Text = Properties.Settings.Default.InitialPath;
            this.retitleCheckBox.Checked = Properties.Settings.Default.Retitle;
            this.removePicturesCheckBox.Checked = Properties.Settings.Default.RemovePictures;
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
            var folder = this.folderTextBox.Text;

            var logger = new Logger(this.logTextBox);
            logger.Clear();

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (this.retitleCheckBox.Checked)
            {
                logger.WriteLogHeader("Retitling...");
                MP3Processor.RetitleMP3Files(folder, logger);
            }

            if (this.removePicturesCheckBox.Checked)
            {
                logger.WriteLogHeader("Removing pictures...");
                MP3Processor.RemoveImagesFromMP3Files(folder, logger);
            }

            stopwatch.Stop();

            logger.WriteLogFooter(stopwatch.Elapsed);
        }
    }
}