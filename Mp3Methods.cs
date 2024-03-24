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
            var mp3Files = Directory.EnumerateFiles(parentFolder, "*.mp3", SearchOption.AllDirectories).ToList();

            if (removeImages)
            {
                var jpgFiles = Directory.EnumerateFiles(parentFolder, "*.jpg", SearchOption.AllDirectories).ToList();
                foreach (var jpg in jpgFiles)
                {
                    File.Delete(jpg);
                }
            }

            foreach (var currentFile in mp3Files)
            {
                var file = TagLib.File.Create(currentFile);
                var titlePrefix = file.Tag.Track.ToString("00", CultureInfo.InvariantCulture);

                if (!RenamedAlready(file.Tag.Title, titlePrefix) && retitle)
                {
                    var newTitle = $"{titlePrefix} {file.Tag.Title}";
                    var oldTitle = file.Tag.Title;

                    file.Tag.Title = newTitle;

                    logger.LogInfo($"{oldTitle} renamed {newTitle}");
                }

                // remove images in the mp3 file
                if (removeImages)
                {
                    file.Tag.Pictures = Array.Empty<TagLib.IPicture>();
                    logger.LogInfo($"Removed image from {file.Tag.Title}");
                }

                file.Save();
                file.Dispose();

                logger.LogInfo("-");
            }
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
