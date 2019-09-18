namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MP3File : IMP3File
    {
        TagLib.File file;

        public MP3File(TagLib.File file)
        {
            this.file = file;
        }

        public string Title
        {
            get
            {
                return this.file.Tag.Title;
            }

            set
            {
                this.file.Tag.Title = value;
            }
        }

        public uint Track
        {
            get
            {
                return this.file.Tag.Track;
            }

            set
            {
                this.file.Tag.Track = value;
            }
        }

        public void ClearPictures()
        {
            this.file.Tag.Pictures = Array.Empty<TagLib.IPicture>();
        }

        public void Save()
        {
            this.file.Save();
        }

        public void Dispose()
        {
            this.file.Dispose();
        }
    }
}
