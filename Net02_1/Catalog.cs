using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Net02_1
{
    internal class Catalog : IEnumerable
    {
        const string PATTERN = "^[0-9]{13}$";
        const string TARGET = "";
        Regex _regex = new Regex(@"\D");
        List<Book> _books;

        public Catalog()
        {
            if (_books == null)
            {
                _books = new List<Book>();
            }
        }

        private List<Book> GetBooksWithAuthors()
        {
            return _books.Where(b => b.Authors != null).ToList();
        }

        private List<Author> GetAllAuthors()
        {
            List<Author> authors = GetBooksWithAuthors().SelectMany(b => b.Authors).Distinct().ToList();

            return authors;
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IEnumerator GetEnumerator()
        {
            _books.Sort();

            foreach (Book b in _books)
            {
                yield return b;
            }
        }

        public List<Book> GetBooks(string firstName, string lastName)
        {
            Author _author = GetBooksWithAuthors().SelectMany(b => b.Authors).ToList()
                .Find(a => a.FirstName.ToUpper()
                == firstName.ToUpper() && a.LastName.ToUpper() == lastName.ToUpper());

            return GetBooksWithAuthors().FindAll(b => b.Authors.Contains(_author));
        }

        public List<Book> SortByDate()
        {
            return _books.OrderByDescending(b => b.PublicationDate).ToList();
        }

        public List<(Author, int)> GetCountBooksOfAuthors()
        {
            int _count = 0;

            List<(Author, int)> _tuplesCountBooks = new List<(Author, int)>();

            foreach (Author author in GetAllAuthors())
            {
                _count = GetBooksWithAuthors().FindAll(b => b.Authors.Contains(author)).Count();

                _tuplesCountBooks.Add((author, _count));
            }

            return _tuplesCountBooks;
        }              

        public Book GetBook(string isbn)
        {
            Book book = null;
            string _isbn = isbn;

            if (!Regex.IsMatch(isbn, PATTERN))
            {
                _isbn = _regex.Replace(isbn, TARGET);
            }

            foreach (Book b in _books)
            {    
                if (b.Isbn.Equals(_isbn))
                {
                    book = b;
                }
            }

            return book ?? throw new ArgumentException("ISBN not found");
        }        
    }
}
