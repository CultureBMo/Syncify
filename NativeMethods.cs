namespace Syncify
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides native methods for managing the appearance of the application.
    /// </summary>
    internal static class NativeMethods
    {
        // https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        /// <summary>
        /// Sets the application to use immersive dark mode.
        /// </summary>
        /// <param name="handle">The handle of the window to set.</param>
        /// <param name="enabled">If set to true, immersive dark mode will be enabled; otherwise, it will be disabled.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        /// <summary>
        /// Checks if the current operating system is Windows 10 or greater.
        /// </summary>
        /// <param name="build">The minimum build number of Windows 10 to check for. If not specified, any build of Windows 10 will be considered as meeting the requirement.</param>
        /// <returns>true if the current operating system is Windows 10 or greater and its build number is greater than or equal to the specified build number; otherwise, false.</returns>
        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}
