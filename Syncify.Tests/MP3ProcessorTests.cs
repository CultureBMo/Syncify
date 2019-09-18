namespace Syncify.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Linq;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MP3ProcessorTests
    {
        [Test]
        public void RenamedAlreadyReturnsTrueForTitleWithNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("01 TitleWithNumberPrefix");

            Assert.IsTrue(actual);
        }

        [Test]
        public void RenamedAlreadyReturnsFalseForTitleWithoutNumberPrefix()
        {
            var actual = MP3Processor.RenamedAlready("TitleWithoutNumberPrefix");

            Assert.IsFalse(actual);
        }

        [Test]
        public void RenamedAlreadyReturnsFalseForEmptyTitle()
        {
            var actual = MP3Processor.RenamedAlready(string.Empty);

            Assert.IsFalse(actual);
        }

        [Test]
        public void RenamedAlreadyReturnsFalseForNullTitle()
        {
            var actual = MP3Processor.RenamedAlready(null);

            Assert.IsFalse(actual);
        }

        [Test]
        public void GetJpgFilesInDirectoryReturnsListOfJpgFiles()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\data\abc.jpg", new MockFileData("") },
                { @"c:\data\def.jpg", new MockFileData("") },
                { @"c:\data\foo\ghi.jpg", new MockFileData("") },
                { @"c:\data\xyz.txt", new MockFileData("") }
            });

            var directoryService = fileSystem.DirectoryInfo.FromDirectoryName(@"c:\data");

            var actual = MP3Processor.GetJpgFilesInDirectory(directoryService);

            Assert.AreEqual(3, actual.Count());
        }

        [Test]
        public void GetMP3FilesInDirectoryReturnsListOfMP3Files()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\data\abc.mp3", new MockFileData("") },
                { @"c:\data\def.mp3", new MockFileData("") },
                { @"c:\data\foo\ghi.mp3", new MockFileData("") },
                { @"c:\data\foo\xyz.txt", new MockFileData("") }
            });

            var directoryService = fileSystem.DirectoryInfo.FromDirectoryName(@"c:\data");

            var actual = MP3Processor.GetMP3FilesInDirectory(directoryService);

            Assert.AreEqual(3, actual.Count());
        }

        [Test]
        public void RemoveImagesFromDirectoryRemovesImages()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\data\abc.jpg", new MockFileData("") },
                { @"c:\data\def.jpg", new MockFileData("") },
                { @"c:\data\foo\ghi.jpg", new MockFileData("") },
                { @"c:\data\xyz.txt", new MockFileData("") }
            });

            var directoryService = fileSystem.DirectoryInfo.FromDirectoryName(@"c:\data");

            var mockLogger = new Mock<ILogger>();

            MP3Processor.RemoveImagesFromDirectory(directoryService, mockLogger.Object);

            var jpgFiles = directoryService.EnumerateFiles("*.jpg", System.IO.SearchOption.AllDirectories);

            Assert.AreEqual(0, jpgFiles.Count());
        }

        ////[Test]
        ////public void Retitle_Retitles()
        ////{
        ////    var mockMP3File = new Mock<IMP3File>();
        ////    mockMP3File.Setup(_ => _.Title).Returns("Title");
        ////    mockMP3File.Setup(_ => _.Track).Returns(8);

        ////    var mockLogger = new Mock<ILogger>();

        ////    MP3Processor.Retitle(mockMP3File.Object, mockLogger.Object);

        ////    Assert.AreEqual("08 Title", mockMP3File.Object.Title);
        ////}
    }
}
