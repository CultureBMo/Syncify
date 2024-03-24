namespace Syncify
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Contains the main entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}