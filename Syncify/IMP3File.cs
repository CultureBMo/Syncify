namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMP3File : IDisposable
    {
        string Title { get; set; }

        uint Track { get; set; }

        void ClearPictures();

        void Save();
    }
}
