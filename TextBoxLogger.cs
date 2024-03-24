namespace Syncify
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class TextBoxLogger : ILogger
    {
        private TextBox textBox;

        internal TextBoxLogger(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public void ClearLog()
        {
            if (this.textBox.InvokeRequired)
            {
                this.textBox.Invoke((Action)this.ClearLog);
                return;
            }

            this.textBox.Clear();
        }

        public void LogError(Exception exception)
        {
            if (this.textBox.InvokeRequired)
            {
                this.textBox.Invoke((Action<Exception>)this.LogError, exception);
                return;
            }

            this.textBox.ForeColor = Color.Red;
            this.textBox.AppendText(exception.Message);
            this.textBox.AppendText(Environment.NewLine);
        }

        public void LogInfo(string message)
        {
            if (this.textBox.InvokeRequired)
            {
                this.textBox.Invoke((Action<string>)this.LogInfo, message);
                return;
            }

            this.textBox.AppendText(message);
            this.textBox.AppendText(Environment.NewLine);
        }
    }
}
