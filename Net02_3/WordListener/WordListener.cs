using System.IO;
using Listener;
using NLog;
using NLog.Config;

namespace WordListener
{
    public class WordListener : Logger, IListener
    {
        const string NLOG_CONFIG_FILE = "WordListener\\NLog.config";
        const string TARGET_NAME = "Word";
        string _pathToNLogConfig = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).Parent.FullName, NLOG_CONFIG_FILE);

        public WordListener()
        {
            LoadConfigurationFile();
        }

        public void LoadConfigurationFile()
        {
            LogManager.LoadConfiguration(_pathToNLogConfig);
            ConfigurationItemFactory.Default.Targets.RegisterDefinition(TARGET_NAME, typeof(WordTarget));
        }
    }
}
