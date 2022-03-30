using System.IO;
using NLog;
using Listener;

namespace TextListener
{
    public class TextListener : Logger, IListener
    {
        const string NLOG_CONFIG_FILE = "TextListener\\NLog.config";
        string _pathToNLogConfig = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).Parent.FullName, NLOG_CONFIG_FILE);

        public TextListener()
        {
            LoadConfigurationFile();
        }

        public void LoadConfigurationFile()
        {
           LogManager.LoadConfiguration(_pathToNLogConfig);
        }
    }
}
