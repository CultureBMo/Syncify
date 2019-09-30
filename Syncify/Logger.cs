namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal class Logger : ILogger
    {
        private TextBox textBox;

        internal Logger(TextBox textBoxToWriteTo)
        {
            this.textBox = textBoxToWriteTo;
        }

        public void Clear()
        {
            this.textBox.Text = string.Empty;
        }

        public void LogInfo(string infoText)
        {
            this.textBox.AppendText(infoText + Environment.NewLine);
        }

        public void LogWarning(string warningText)
        {
            this.LogInfo("Warning: " + warningText);
        }

        public void LogError(string errorText)
        {
            this.LogInfo("Error: " + errorText);
        }

        internal void WriteLogHeader(string caption)
        {
            this.LogInfo(caption + "...");
            this.LogInfo("-");
        }

        internal void WriteLogFooter(TimeSpan elapsed)
        {
            this.LogInfo("-");
            this.LogInfo(string.Format("Time elapsed: {0}", elapsed));
            this.LogInfo("Copyright © CultureBMo 2019");
            this.LogInfo("Tag-Lib Sharp: https://github.com/mono/taglib-sharp");
            this.LogInfo("Icon copyright © Yannick Lung http://www.yanlu.de");
        }
    }
}