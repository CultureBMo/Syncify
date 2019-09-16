namespace Syncify.Tests
{
    using System;
    using System.Windows.Forms;
    using NUnit.Framework;

    [TestFixture]
    public class LoggerTests
    {
        Logger logger;
        TextBox textBox = new TextBox();        
        string message = "Test";

        [SetUp]
        public void Init()
        {
            this.logger = new Logger(textBox);
        }

        [Test]
        public void LoggerClearsTextBox()
        {
            this.logger.LogInfo(this.message);
            this.logger.Clear();

            Assert.AreEqual(string.Empty, textBox.Text);
        }

        [Test]
        public void LogInfoWritesToTextBox()
        {
            this.logger.Clear();
            this.logger.LogInfo(this.message);

            var expected = this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }

        [Test]
        public void LogWarningWritesToTextBox()
        {
            this.logger.Clear();
            this.logger.LogWarning(this.message);

            var expected = "Warning: " + this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }

        [Test]
        public void LogErrorWritesToTextBox()
        {
            this.logger.Clear();
            this.logger.LogError(this.message);

            var expected = "Error: " + this.message + Environment.NewLine;

            Assert.AreEqual(expected, textBox.Text);
        }
    }
}