namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class MP3Processor
    {
        internal static void RemoveImagesFromMP3Files(string directoryName)
        {
            RemoveImagesFromDirectory(directoryName);

            RemoveImageFromIDTag(directoryName);
        }

        internal static void RetitleMP3Files(string directoryName, ILogger logger)
        {
            var mp3FilePaths = GetMP3FilesInDirectory(directoryName);

            foreach (var currentFile in mp3FilePaths)
            {
                using (var file = TagLib.File.Create(currentFile))
                {
                    if (!RenamedAlready(file.Tag.Title))
                    {
                        var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;
                        var oldTitle = file.Tag.Title;

                        file.Tag.Title = newTitle;

                        logger.LogInfo(oldTitle + " renamed " + newTitle);
                    }

                    file.Save();
                }
            }
        }

        private static IEnumerable<string> GetJpgFilesInDirectory(string directoryName)
        {
            return Directory.EnumerateFiles(directoryName, "*.jpg", SearchOption.AllDirectories);
        }

        private static IEnumerable<string> GetMP3FilesInDirectory(string directoryName)
        {
            return Directory.EnumerateFiles(directoryName, "*.mp3", SearchOption.AllDirectories);
        }

        private static void RemoveImageFromIDTag(string directoryName)
        {
            var mp3FilePaths = GetMP3FilesInDirectory(directoryName);

            foreach (var currentFile in mp3FilePaths)
            {
                using (var file = TagLib.File.Create(currentFile))
                {
                    file.Tag.Pictures = Array.Empty<TagLib.IPicture>();

                    file.Save();
                }
            }
        }

        private static void RemoveImagesFromDirectory(string directoryName)
        {
            var jpgFiles = GetJpgFilesInDirectory(directoryName);

            if (jpgFiles.Any())
            {
                foreach (var jpg in jpgFiles)
                {
                    File.Delete(jpg);
                }
            }
        }

        private static bool RenamedAlready(string title)
        {
            if (title.Length > 1)
            {
                return int.TryParse(title.Substring(0, 2), out int returnInt);
            }

            return false;
        }
    }
}