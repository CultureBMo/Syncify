namespace Syncify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILogger
    {
        void Clear();

        void LogInfo(string infoText);

        void LogWarning(string warningText);

        void LogError(string errorText);
    }
}