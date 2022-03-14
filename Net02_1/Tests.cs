using NUnit.Framework;
using System;

namespace Net02_1
{
    [TestFixture]
    internal class Tests
    {
        const string ISBN_FORMAT_1 = "0123456789002";
        const string ISBN_POSITIVE_FORMAT_1 = "0123456789001";
        const string ISBN_POSITIVE_FORMAT_2 = "012-3-45-678900-1";
        const string ISBN_NEGATIVE_FORMAT_1 = "0120-3-45-678900-1";
        const string ISBN_NEGATIVE_FORMAT_2 = "AA-3-45-678900-1";
        const string ISBN_NEGATIVE_FORMAT_3 = "AA112";
        const string NAME_BOOK_1 = "Book1";
        const string NAME_BOOK_2 = "Book2";

        [TestCase(ISBN_POSITIVE_FORMAT_1, NAME_BOOK_1)]
        [TestCase(ISBN_POSITIVE_FORMAT_2, NAME_BOOK_2)]
        public void IsbnPositiveTest(string isbn, string name)
        {
            Book book = new Book(isbn, name);

            Assert.AreEqual(isbn, book.Isbn);
        }

        [TestCase(ISBN_POSITIVE_FORMAT_1, NAME_BOOK_1, ISBN_POSITIVE_FORMAT_2, NAME_BOOK_2)]
        public void EqualPositiveTest(string isbn1, string name1, string isbn2, string name2)
        {
            bool _result = false;

            Book book1 = new Book(isbn1, name1);
            Book book2 = new Book(isbn2, name2);

            _result = book1.Equals(book2);

            Assert.IsTrue(_result);
        }

        [TestCase(ISBN_NEGATIVE_FORMAT_1, NAME_BOOK_1)]
        [TestCase(ISBN_NEGATIVE_FORMAT_2, NAME_BOOK_1)]
        [TestCase(ISBN_NEGATIVE_FORMAT_3, NAME_BOOK_1)]
        public void IsbnNegativeTest(string isbn, string name)
        {
            bool _result = false;

            try
            {
                Book book = new Book(isbn, name);
            }
            catch(ArgumentException)
            {
                _result = true;
            }

            Assert.IsTrue(_result);
        }

        [TestCase(ISBN_POSITIVE_FORMAT_1, NAME_BOOK_1, ISBN_FORMAT_1, NAME_BOOK_2)]
        public void EqualNegativeTest(string isbn1, string name1, string isbn2, string name2)
        {
            bool _result = false;

            Book book1 = new Book(isbn1, name1);
            Book book2 = new Book(isbn2, name2);

            _result = book1.Equals(book2);

            Assert.IsFalse(_result);
        }
    }
}
