using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Net02_2
{
    internal class XmlReader
    {
        const string XML_FILE = "Config\\Config.XML";
        const string LOGIN_ELEMENT = "login";
        const string NAME_ATTRIBUTE = "name";
        const string WINDOW_ELEMENT = "window";
        const string TITLE_ATTRIBUTE = "title";
        const string TOP_ELEMENT = "top";
        const string LEFT_ELEMENT = "left";
        const string WIDTH_ELEMENT = "width";
        const string HEIGHT_ELEMENT = "height";
        const string MAIN_TITLE = "main";
        const string HELP_TITLE = "help";
        const string LOGIN_STRING_FORMAT = "Login: {0}";
        const string QUESTION_MARK = "?";
        const string MAIN_STRING_FORMAT = " main({0}, {1}, {2}, {3})";
        const string HELP_STRING_FORMAT = " help({0}, {1}, {2}, {3})";

        string _pathToConfigFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, XML_FILE);
        List<LoginElement> _loginElements;

        public List<LoginElement> ReadConfigFile()
        {
            if (_loginElements == null)
            {
                List<LoginElement> loginElements = new List<LoginElement>();
                List<WindowElement> windowElements;

                XDocument configFile = XDocument.Load(_pathToConfigFile);

                foreach (var login in configFile.Root.Elements(LOGIN_ELEMENT))
                {
                    windowElements = new List<WindowElement>();
                    windowElements.AddRange(ReadWindowElement(login));

                    LoginElement loginElement = new LoginElement(login.Attribute(NAME_ATTRIBUTE).Value, windowElements);

                    loginElements.Add(loginElement);
                }

                _loginElements = loginElements;
            }

            return _loginElements;
        }

        private List<WindowElement> ReadWindowElement(XElement xml)
        {
            List<WindowElement> windowElements = new List<WindowElement>();

            foreach (var window in xml.Elements(WINDOW_ELEMENT))
            {
                WindowElement windowElement = new WindowElement();

                windowElement.Title = window.Attribute(TITLE_ATTRIBUTE).Value;
                windowElement.Width = GetValueElement(WIDTH_ELEMENT, window);
                windowElement.Height = GetValueElement(HEIGHT_ELEMENT, window);
                windowElement.Left = GetValueElement(LEFT_ELEMENT, window);
                windowElement.Top = GetValueElement(TOP_ELEMENT, window);

                windowElements.Add(windowElement);
            }

            return windowElements;
        }

        private bool IsConfigCorrect(WindowElement element)
        {
            if (element.Title == MAIN_TITLE)
            {
                if (element.Top == null || element.Width == null || element.Height == null || element.Left == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private int? GetValueElement(string name, XElement element)
        {
            if (element.Element(name)?.Value != null)
            {
                return int.Parse(element.Element(name).Value);
            }
            else
            {
                return null;
            }
        }

        private List<LoginElement> GetIncorrectLogins()
        {
            List<LoginElement> loginElements = _loginElements ?? ReadConfigFile();

            return (from login in loginElements
                    from window in login.WindowElements
                    where !IsConfigCorrect(window)
                    select login).ToList();
        }

        public void PrintLogins(List<LoginElement> logins = null)
        {
            List<LoginElement> loginElements = logins ?? ReadConfigFile();

            foreach (LoginElement login in loginElements)
            {
                PrintLogin(login);
            }
        }

        private void PrintLogin(LoginElement loginElement)
        {
            string loginName, top, left, width, height, result;
            List<string> results = new List<string>();

            loginName = loginElement.Name;
            result = string.Format(LOGIN_STRING_FORMAT, loginName);

            results.Add(result);

            foreach (WindowElement windowElement in loginElement.WindowElements)
            {
                top = CheckIfNull(windowElement.Top);
                left = CheckIfNull(windowElement.Left);
                width = CheckIfNull(windowElement.Width);
                height = CheckIfNull(windowElement.Height);

                if (windowElement.Title == MAIN_TITLE)
                {
                    result = string.Format(MAIN_STRING_FORMAT, top, left, width, height);
                }
                if (windowElement.Title == HELP_TITLE)
                {
                    result = string.Format(HELP_STRING_FORMAT, top, left, width, height);
                }

                results.Add(result);
            }

            foreach (string line in results)
            {
                Console.WriteLine(line);
            }
        }

        public void PrintIncorrectLogins()
        {
            List<LoginElement> incorrectLogins = GetIncorrectLogins();
            PrintLogins(incorrectLogins);
        }

        private string CheckIfNull(int? value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return QUESTION_MARK;
            }
        }
    }
}

