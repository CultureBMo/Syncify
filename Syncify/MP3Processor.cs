namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class MP3Processor
    {
        public static void RemoveImagesFromMP3Files(IDirectoryInfo directoryService, ILogger logger)
        {
            RemoveImagesFromDirectory(directoryService, logger);

            RemoveImageFromIDTag(directoryService, logger);
        }

        public static void RetitleMP3Files(IDirectoryInfo directoryService, ILogger logger)
        {
            if (logger != null)
            {
                try
                {
                    if (directoryService.Exists)
                    {
                        var mp3FilePaths = GetMP3FilesInDirectory(directoryService);

                        foreach (var currentFile in mp3FilePaths)
                        {
                            using (var file = TagLib.File.Create(currentFile.FullName))
                            {
                                if (!RenamedAlready(file.Tag.Title))
                                {
                                    var newTitle = file.Tag.Track.ToString("00") + " " + file.Tag.Title;
                                    var oldTitle = file.Tag.Title;

                                    file.Tag.Title = newTitle;

                                    file.Save();

                                    logger.LogInfo(oldTitle + " retitled " + newTitle);
                                }
                                else
                                {
                                    logger.LogWarning(file.Tag.Title + " could not be retitled");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }

        public static IEnumerable<IFileInfo> GetJpgFilesInDirectory(IDirectoryInfo directoryService)
        {
            return directoryService.EnumerateFiles("*.jpg", System.IO.SearchOption.AllDirectories);
        }

        public static IEnumerable<IFileInfo> GetMP3FilesInDirectory(IDirectoryInfo directoryService)
        {
            return directoryService.EnumerateFiles("*.mp3", System.IO.SearchOption.AllDirectories);
        }

        public static void RemoveImageFromIDTag(IDirectoryInfo directoryService, ILogger logger)
        {
            if (logger != null)
            {
                try
                {
                    if (directoryService.Exists)
                    {
                        var mp3FilePaths = GetMP3FilesInDirectory(directoryService);

                        foreach (var currentFile in mp3FilePaths)
                        {
                            using (var file = TagLib.File.Create(currentFile.FullName))
                            {
                                file.Tag.Pictures = Array.Empty<TagLib.IPicture>();

                                file.Save();

                                logger.LogInfo("Image removed from " + file.Tag.Title);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }

        public static void RemoveImagesFromDirectory(IDirectoryInfo directoryService, ILogger logger)
        {
            if (logger != null)
            {
                try
                {
                    if (directoryService.Exists)
                    {
                        var jpgFiles = GetJpgFilesInDirectory(directoryService);

                        if (jpgFiles.Any())
                        {
                            foreach (var jpg in jpgFiles)
                            {
                                jpg.Delete();
                            }

                            logger.LogWarning("Images removed from " + directoryService.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }

        public static bool RenamedAlready(string title)
        {
            if (!string.IsNullOrEmpty(title) && title.Length > 1)
            {
                return int.TryParse(title.Substring(0, 2), out int returnInt);
            }

            return false;
        }
    }
}