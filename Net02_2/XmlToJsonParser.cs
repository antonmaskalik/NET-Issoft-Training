using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Net02_2
{
    internal class XmlToJsonParser
    {
        const string JSON_FILE = "Config\\";
        const string STRING_FORMAT = "{0}{1}.json";
        const string DEFAULT_TOP = "0";
        const string DEFAULT_LEFT = "0";
        const string DEFAULT_WIDTH = "400";
        const string DEFAULT_HEIGHT = "150";

        string _pathToJsonFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, JSON_FILE);

        public async void ParseToJsonAsync(List<LoginElement> loginElements)
        {
            string path;
            LoginElement loginElement;

            foreach (var login in loginElements)
            {
                loginElement = UpdateWindowSettings(login);

                path = string.Format(STRING_FORMAT, _pathToJsonFile, login.Name);

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fs, loginElement);
                }
            }
        }

        private LoginElement UpdateWindowSettings(LoginElement login)
        {
            foreach (WindowElement element in login.WindowElements)
            {
                if(element.Top == null ||element.Width == null ||element.Height == null||element.Left == null)
                {
                    element.Top = DEFAULT_TOP;
                    element.Left = DEFAULT_LEFT;
                    element.Width = DEFAULT_WIDTH;
                    element.Height = DEFAULT_HEIGHT;
                }
            }

            return login;
        }
    }
}
