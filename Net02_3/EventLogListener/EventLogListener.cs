using System.IO;
using NLog;
using Listener;
using NLog.Config;

namespace EventLogListener
{
    internal class EventLogListener : Logger, IListener
    {
        const string NLOG_CONFIG_FILE = "EventLogListener\\NLog.config";
        const string TARGET_NAME = "Event";
        string _pathToNLogConfig = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).Parent.FullName, NLOG_CONFIG_FILE);

        public EventLogListener()
        {
            LoadConfigurationFile();
        }

        public void LoadConfigurationFile()
        {
            LogManager.LoadConfiguration(_pathToNLogConfig);

            ConfigurationItemFactory.Default.Targets.RegisterDefinition(TARGET_NAME, typeof(EventTarget));
        }
    }
}
