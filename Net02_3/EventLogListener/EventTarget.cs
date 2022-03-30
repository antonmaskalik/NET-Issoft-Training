using System.Diagnostics;
using NLog;
using NLog.Layouts;
using NLog.Targets;

namespace EventLogListener
{
    [Target("Event")]
    internal class EventTarget : TargetWithContext
    {
        const string SOURCE = "Application";
        string _logMessage;

        protected override void Write(LogEventInfo logEvent)
        {
            _logMessage = Layout.Render(logEvent);

            WriteToEvent();
        }

        private void WriteToEvent()
        {
            using (EventLog eventLog = new EventLog())
            {
                eventLog.Source = SOURCE;
                eventLog.WriteEntry(_logMessage);
            }
        }
    }
}
