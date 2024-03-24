namespace Syncify
{
    using System;

    /// <summary>
    /// Defines methods for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Clears the log output.
        /// </summary>
        void ClearLog();

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void LogError(Exception exception);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogInfo(string message);
    }
}
