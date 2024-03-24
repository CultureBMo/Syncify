namespace Syncify
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal static class Mp3Methods
    {
        internal static void ReTitle(string parentFolder, bool retitle, bool removeImages, ILogger logger)
        {
            if (removeImages)
            {
                DeleteAllJpgs(parentFolder);
            }

            var mp3Files = Directory.EnumerateFiles(parentFolder, "*.mp3", SearchOption.AllDirectories);

            foreach (var currentFile in mp3Files)
            {
                using (var file = TagLib.File.Create(currentFile))
                {
                    if (retitle)
                    {
                        RetitleFile(logger, file);
                    }

                    // remove images in the mp3 file
                    if (removeImages)
                    {
                        RemoveImagesFromFile(logger, file);
                    }

                    file.Save();
                }

                logger.LogInfo("-");
            }
        }

        private static void DeleteAllJpgs(string parentFolder)
        {
            var jpgFiles = Directory.EnumerateFiles(parentFolder, "*.jpg", SearchOption.AllDirectories);
            foreach (var jpg in jpgFiles)
            {
                File.Delete(jpg);
            }
        }

        private static void RetitleFile(ILogger logger, TagLib.File file)
        {
            var titlePrefix = file.Tag.Track.ToString("00", CultureInfo.InvariantCulture);

            if (!RenamedAlready(file.Tag.Title, titlePrefix))
            {
                var newTitle = $"{titlePrefix} {file.Tag.Title}";
                var oldTitle = file.Tag.Title;

                file.Tag.Title = newTitle;

                logger.LogInfo($"{oldTitle} renamed {newTitle}");
            }
        }

        private static void RemoveImagesFromFile(ILogger logger, TagLib.File file)
        {
            file.Tag.Pictures = Array.Empty<TagLib.IPicture>();

            logger.LogInfo($"Removed image from {file.Tag.Title}");
        }

        private static bool RenamedAlready(string title, string trackNumber)
        {
            if (title.Length > 1)
            {
                bool startsWithNumber = int.TryParse(title.Substring(0, 2), out int titleNumber);

                // if a track title does start with a number, check if it matches the track number
                if (startsWithNumber)
                {
                    if (titleNumber.ToString("00", CultureInfo.InvariantCulture) == trackNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
