using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Net02_1
{
    internal class Book : IComparable<Book>
    {
        const string PATTERN = "^[0-9]{13}$|^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$";
        string _isbn;
        string _target = "";
        Regex _regex = new Regex(@"\D");
        string _name;
        DateTime? _publicationDate;
        List<Author> _authors;

        public string Isbn
        {
            get { return _isbn; }
            set
            {
                if (Regex.IsMatch(value, PATTERN))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException("This ISBN haven't got correct format!");
                }
            }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                if (value.Length <= 1000)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid number of characters.");
                }
            }
        }

        public List<Author> Authors { get { return _authors; } }

        public DateTime? PublicationDate { get { return _publicationDate; } }

        public Book(string isbn, string name, DateTime? publicationDate = null, List<Author> authors = null)
        {
            Isbn = isbn;
            Name = name;
            _publicationDate = publicationDate;

            if (authors != null)
            {
                _authors = new List<Author>();
                _authors.AddRange(authors);
            }
        }

        public override bool Equals(object obj)
        {
            Book book = obj as Book;

            if (book != null)
            {
                return book._regex.Replace(_isbn, _target).Equals(_regex.Replace(book.Isbn, _target));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _isbn.GetHashCode();
        }

        public int CompareTo(Book book)
        {
            if (book is null)
            {
                throw new ArgumentException("Incorrect parameter value.");
            }

            return Name.CompareTo(book.Name);
        }

        public override string ToString()
        {
            Author author1 = null;

            if (_authors != null)
            {
                foreach (Author author in _authors)
                {
                    author1 = author;
                }
            }

            return "ISBN:" + Isbn + " Name:" + Isbn + " Date of publication:" + PublicationDate + " Authors:" + author1;
        }
    }
}
