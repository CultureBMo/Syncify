namespace Syncify
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.Extensions.Configuration;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();

            this.Icon = new System.Drawing.Icon(Directory.GetCurrentDirectory() + @"\1468086191_icon-71-document-file-mp3.ico");

            // get default values from config file
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            this.folderTextBox.Text = config["settings:InitialPath"];
            this.retitleCheckBox.Checked = config.GetValue<bool>("settings:Retitle");
            this.removePicturesCheckBox.Checked = config.GetValue<bool>("settings:RemovePictures");
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

            // use the System.IO.Abstraction library to pass in a Directory as an interface
            System.IO.Abstractions.DirectoryInfoBase directoryService = new System.IO.DirectoryInfo(folder);

            var mp3Service = new MP3Service();

            var logger = new Logger(this.logTextBox);
            logger.Clear();

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (this.retitleCheckBox.Checked)
            {
                logger.WriteLogHeader("Retitling...");
                MP3Processor.RetitleMP3Files(directoryService, mp3Service, logger);
            }

            if (this.removePicturesCheckBox.Checked)
            {
                logger.WriteLogHeader("Removing pictures...");
                MP3Processor.RemoveImagesFromMP3Files(directoryService, mp3Service, logger);
            }

            stopwatch.Stop();

            logger.WriteLogFooter(stopwatch.Elapsed);
        }
    }
}