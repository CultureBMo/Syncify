namespace Syncify.Tests
{
    using System;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoggerTests
    {
        Logger logger;
        TextBox textBox = new TextBox();        
        string message = "Test";

        [TestInitialize]
        public void Init()
        {
            this.logger = new Logger(textBox);
        }

        [TestMethod]
        public void LoggerClearsTextBox()
        {
            this.logger.LogInfo(this.message);
            this.logger.Clear();

            Assert.AreEqual(string.Empty, textBox.Text);
        }

        [TestMethod]
        public void LogInfoWritesToTextBox()
        {
            this.logger.LogInfo(this.message);

            var expected = this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }

        [TestMethod]
        public void LogWarningWritesToTextBox()
        {
            this.logger.LogWarning(this.message);

            var expected = "Warning: " + this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }

        [TestMethod]
        public void LogErrorWritesToTextBox()
        {
            this.logger.LogError(this.message);

            var expected = "Error: " + this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }
    }
}