namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MP3Service : IMP3Service
    {

        public IMP3File Create(string fileName)
        {
            return new MP3File(TagLib.File.Create(fileName));
        }
    }
}
