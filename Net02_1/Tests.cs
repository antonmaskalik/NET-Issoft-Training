using NUnit.Framework;
using System;

namespace Net02_1
{
    [TestFixture]
    internal class Tests
    {
        [TestCase("0123456789001", "Book1")]
        [TestCase("012-3-45-678900-1", "Book1")]
        public void IsbnPositiveTest(string isbn, string name)
        {
            Book book = new Book(isbn, name);

            Assert.AreEqual(isbn, book.Isbn);
        }

        [TestCase("0123456789001", "Book1", "012-3-45-678900-1", "Book2")]
        public void EqualPositiveTest(string isbn1, string name1, string isbn2, string name2)
        {
            bool _result = false;

            Book book1 = new Book(isbn1, name1);
            Book book2 = new Book(isbn2, name2);

            _result = book1.Equals(book2);

            Assert.IsTrue(_result);
        }

        [TestCase("0120-3-45-678900-1", "Book1")]
        [TestCase("AA-3-45-678900-1", "Book1")]
        [TestCase("AA112", "Book1")]
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

        [TestCase("0123456789001", "Book1", "012-3-45-678900-2", "Book2")]
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
