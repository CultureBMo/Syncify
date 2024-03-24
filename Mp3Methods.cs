namespace Syncify
{
    using System;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Provides methods for managing MP3 files.
    /// </summary>
    internal static class Mp3Methods
    {
        /// <summary>
        /// Retitles MP3 files and/or removes images from them.
        /// </summary>
        /// <param name="parentFolder">The parent folder containing the MP3 files.</param>
        /// <param name="retitle">If set to true, the files will be retitled.</param>
        /// <param name="removeImages">If set to true, images will be removed from the files.</param>
        /// <param name="logger">The logger to use for logging operations.</param>
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
                        RetitleFile(file, logger);
                    }

                    // remove images in the mp3 file
                    if (removeImages)
                    {
                        RemoveImagesFromFile(file, logger);
                    }

                    file.Save();
                }

                logger.LogInfo("-");
            }
        }

        /// <summary>
        /// Deletes all JPG files in a folder and its subfolders.
        /// </summary>
        /// <param name="parentFolder">The parent folder.</param>
        private static void DeleteAllJpgs(string parentFolder)
        {
            var jpgFiles = Directory.EnumerateFiles(parentFolder, "*.jpg", SearchOption.AllDirectories);
            foreach (var jpg in jpgFiles)
            {
                File.Delete(jpg);
            }
        }

        /// <summary>
        /// Retitles a file by prefixing the track number to the title.
        /// </summary>
        /// <param name="file">The file to retitle.</param>
        /// <param name="logger">The logger to use for logging operations.</param>
        private static void RetitleFile(TagLib.File file, ILogger logger)
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

        /// <summary>
        /// Removes all images from a file.
        /// </summary>
        /// <param name="file">The file from which to remove images.</param>
        /// <param name="logger">The logger to use for logging operations.</param>
        private static void RemoveImagesFromFile(TagLib.File file, ILogger logger)
        {
            if (file.Tag.Pictures.Length > 0)
            {
                file.Tag.Pictures = Array.Empty<TagLib.IPicture>();
                logger.LogInfo($"Removed image from {file.Tag.Title}");
            }
        }

        /// <summary>
        /// Checks if a title has already been retitled.
        /// </summary>
        /// <param name="title">The title to check.</param>
        /// <param name="trackNumber">The track number.</param>
        /// <returns>true if the title has already been retitled; otherwise, false.</returns>
        private static bool RenamedAlready(string title, string trackNumber)
        {
            if (title.Length > 1)
            {
                bool startsWithNumber = int.TryParse(title[..2], out int titleNumber);

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
