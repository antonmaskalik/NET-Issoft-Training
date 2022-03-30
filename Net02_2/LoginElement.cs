using System.Collections.Generic;

namespace Net02_2
{
    internal class LoginElement
    {
        string _name;
        List<WindowElement> _windowElements = new List<WindowElement>();

        public string Name { get { return _name; } }    

        public List<WindowElement> WindowElements { get { return _windowElements; } }

        public LoginElement(string name, List<WindowElement> windowElements)
        {
            _name = name;
            _windowElements = windowElements;
        }
    }
}
