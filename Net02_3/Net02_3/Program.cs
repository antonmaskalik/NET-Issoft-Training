using NLog;

namespace Net02_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassForChecking myClass = new ClassForChecking("Hello World", 11, 25);

            LoggerManager logManager = new LoggerManager();

            logManager.Track(myClass);
        }
    }
}
