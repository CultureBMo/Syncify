namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMP3Service
    {
        IMP3File Create(string fileName);
    }
}
