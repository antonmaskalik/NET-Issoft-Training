using System;

namespace Net02_1
{
    internal class Author
    {
        string _firstName;
        string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length <= 200)
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid number of characters.");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length <= 200)
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid number of characters.");
                }
            }
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
}
