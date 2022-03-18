using System;
using System.Threading.Tasks;

namespace Net02_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            XmlReader xmlReader = new XmlReader();
            xmlReader.PrintLogins();
            xmlReader.PrintIncorrectLogins();

            XmlToJsonParser parser = new XmlToJsonParser();
            await parser.ParseToJsonAsync(xmlReader.ReadConfigFile());
        }
    }
}
