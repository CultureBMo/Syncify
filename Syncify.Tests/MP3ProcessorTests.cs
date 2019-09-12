namespace Syncify.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MP3ProcessorTests
    {
        [TestMethod]
        public void RenamedAlreadyReturnsTrueForTitleWithNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("01 TitleWithNumberPrefix");

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForTitleWithoutNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("TitleWithoutNumberPrefix");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForEmptyTitle()
        {
            var actual = MP3Processor.RenamedAlready(string.Empty);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForNullTitle()
        {
            var actual = MP3Processor.RenamedAlready(null);

            Assert.AreEqual(false, actual);
        }
    }
}
