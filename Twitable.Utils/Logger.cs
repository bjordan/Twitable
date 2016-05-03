using System;
using System.IO;

namespace Twitable.Utils
{

    public class Logger
    {
        private string _path;
        public Logger()
        {
            SetDefaults();
        }
        private void SetDefaults()
        {
            _path = Path.Combine(Config.LoggingFolder,
                string.Format("TwitableLogs_logs_{0}.txt", DateTime.Now.ToString("yyyyMMdd")));
            var fi = new FileInfo(_path);
            FileManagement.EnsureDirectoryExists(fi.Directory);
            if (!fi.Exists)
            {
                // Create a file to write to.
                using (var sw = File.CreateText(_path))
                {
                    sw.WriteLine("==========================");
                    sw.WriteLine("Date: {0}", DateTime.Now.ToString("yyyy MMMM dd"));
                    sw.WriteLine("Time: {0}", DateTime.Now.ToString("HH:mm:ss"));
                    sw.WriteLine("Type: Info");
                    sw.WriteLine("Description: This is where the information is loaded");
                    sw.WriteLine("------------------------------");
                    sw.WriteLine("{0}{0}", Environment.NewLine);
                }
            }
        }
        private void AppendText(string text, string type)
        {
            using (var sw = File.AppendText(_path))
            {
                sw.WriteLine("==========================");
                sw.WriteLine("Date: {0}", DateTime.Now.ToString("yyyy MMMM dd"));
                sw.WriteLine("Time: {0}", DateTime.Now.ToString("HH:mm:ss"));
                sw.WriteLine("Type: {0}", type);
                sw.WriteLine("Description: {0}", text);
                sw.WriteLine("------------------------------");
                sw.WriteLine("{0}{0}", Environment.NewLine);
            }
        }

        public static void LogError(string message)
        {
            var fl = new Logger();
            fl.AppendText(message, "Error");
        }
        public static void LogInfo(string message)
        {
            var fl = new Logger();
            fl.AppendText(message, "Info");
        }

    }
}
