using System.IO;

namespace PPGManager
{
    public class Checks
    {
        /// <summary>
        /// Checks for People Playground on the current directory.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static bool PPGExists()
        {
            return Directory.Exists("People Playground_Data");
        }
    }
}