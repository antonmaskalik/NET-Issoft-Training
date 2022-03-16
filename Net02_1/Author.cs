using System;

namespace Net02_1
{
    internal class Author
    {
        const int MAX_LENGTH = 200;
        string _firstName;
        string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length <= MAX_LENGTH)
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
                if (value.Length <= MAX_LENGTH)
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

        public override bool Equals(object obj)
        {
            Author author = obj as Author;

            if (author != null)
            {
                return author.FirstName.Equals(FirstName) && author.LastName.Equals(LastName);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _firstName.GetHashCode();
        }
    }
}
