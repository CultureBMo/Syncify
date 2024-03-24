namespace Syncify
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Provides a logger that outputs to a TextBox control.
    /// </summary>
    public class TextBoxLogger : ILogger
    {
        private readonly TextBox textBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxLogger"/> class.
        /// </summary>
        /// <param name="textBox">The TextBox control to which the logger will output.</param>
        internal TextBoxLogger(TextBox textBox)
        {
            this.textBox = textBox;
        }

        /// <summary>
        /// Clears the log output.
        /// </summary>
        public void ClearLog()
        {
            if (this.textBox.InvokeRequired)
            {
                this.textBox.Invoke((Action)this.ClearLog);
                return;
            }

            this.textBox.Clear();
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
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

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to log.</param>
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
