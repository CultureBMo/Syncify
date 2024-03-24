namespace Syncify
{
    using System;

    public interface ILogger
    {
        void ClearLog();

        void LogError(Exception exception);

        void LogInfo(string message);
    }
}
