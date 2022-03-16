using System;

namespace Net02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlReader xmlReader = new XmlReader();
            xmlReader.PrintLogins();
            xmlReader.PrintIncorrectLogins();

            XmlToJsonParser parser = new XmlToJsonParser();
            parser.ParseToJsonAsync(xmlReader.ReadConfigFile());
        }
    }
}
