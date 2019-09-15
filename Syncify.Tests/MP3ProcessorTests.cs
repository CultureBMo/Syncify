namespace Syncify.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MP3ProcessorTests
    {
        [TestMethod]
        public void RenamedAlreadyReturnsTrueForTitleWithNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("01 TitleWithNumberPrefix");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForTitleWithoutNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("TitleWithoutNumberPrefix");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForEmptyTitle()
        {
            var actual = MP3Processor.RenamedAlready(string.Empty);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RenamedAlreadyReturnsFalseForNullTitle()
        {
            var actual = MP3Processor.RenamedAlready(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetJpgFilesInDirectoryReturnsListOfJpgFiles()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\data\foo\abc.jpg", new MockFileData("") },
                { @"c:\data\foo\def.jpg", new MockFileData("") },
                { @"c:\data\foo\xyz.txt", new MockFileData("") }
            });

            var directoryService = fileSystem.DirectoryInfo.FromDirectoryName(@"c:\data");

            var actual = MP3Processor.GetJpgFilesInDirectory(directoryService);

            Assert.AreEqual(2, actual.Count());
        }

        [TestMethod]
        public void GetMP3FilesInDirectoryReturnsListOfMP3Files()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\data\foo\abc.mp3", new MockFileData("") },
                { @"c:\data\foo\def.mp3", new MockFileData("") },
                { @"c:\data\foo\xyz.txt", new MockFileData("") }
            });

            var directoryService = fileSystem.DirectoryInfo.FromDirectoryName(@"c:\data");

            var actual = MP3Processor.GetMP3FilesInDirectory(directoryService);

            Assert.AreEqual(2, actual.Count());
        }
    }
}
