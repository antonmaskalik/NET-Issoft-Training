using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Net02_1
{
    internal class Catalog : IEnumerable
    {
        List<Book> _books;
        List<string> _isbns;

        public Catalog()
        {
            _books = new List<Book>();
            _isbns = new List<string>();
        }

        public void Add(Book book, string isbn)
        {
            _books.Add(book);
            _isbns.Add(isbn);
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
            Author _aothor = GetBooksWithAuthors().SelectMany(b => b.Authors).ToList()
                .Find(a => a.FirstName.ToUpper()
                == firstName.ToUpper() && a.LastName.ToUpper() == lastName.ToUpper());

            return GetBooksWithAuthors().FindAll(b => b.Authors.Contains(_aothor));
        }

        public List<Book> SortByDate()
        {
            return _books.OrderByDescending(b => b.PublicationDate).ToList();
        }

        public Dictionary<Author, int> GetCountBooksOfAuthors()
        {
            int _count = 0;

            Dictionary<Author, int> _result = new Dictionary<Author, int>();
            List<Author> _authors = GetBooksWithAuthors().SelectMany(b => b.Authors).Distinct().ToList();

            foreach (Author author in _authors)
            {
                _count = GetBooksWithAuthors().FindAll(b => b.Authors.Contains(author)).Count();

                _result.Add(author, _count);
            }

            return _result;
        }

        private List<Book> GetBooksWithAuthors()
        {
            return _books.Where(b => b.Authors != null).ToList();
        }
    }
}
