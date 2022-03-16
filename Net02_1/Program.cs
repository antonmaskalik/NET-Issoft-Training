using System;
using System.Collections.Generic;

namespace Net02_1
{
    internal class Program
    {
        const string FIRST_NAME_1 = "Jeffrey";
        const string LAST_NAME_1 = "Richter";
        const string FIRST_NAME_2 = "Stephen ";
        const string LAST_NAME_2 = "King";
        const string ISBN_1 = "012-3-45-678900-1";
        const string ISBN_2 = "0123456789002";
        const string ISBN_3 = "0123456789001";
        const string NAME_BOOK_1 = "Book1";
        const string NAME_BOOK_2 = "Book2";
        const string NAME_BOOK_3 = "Book3";
        static DateTime _publicationDateBook1 = new DateTime(2004, 02, 23);
        static DateTime _publicationDateBook2 = new DateTime(2001, 04, 20);
        static DateTime _publicationDateBook3 = new DateTime(2010, 05, 11);
        static void Main(string[] args)
        {
            Author author1 = new Author(FIRST_NAME_1, LAST_NAME_1);           
            List<Author> authors1 = new List<Author>();
            authors1.Add(author1);

            Author author2 = new Author(FIRST_NAME_2, LAST_NAME_2);
            List<Author> authors2 = new List<Author>();
            authors2.Add(author2);
            authors2.Add(author1);

            Book book1 = new Book(ISBN_1, NAME_BOOK_1, _publicationDateBook1, authors2);
            Book book2 = new Book(ISBN_2, NAME_BOOK_2, _publicationDateBook2, authors1);
            Book book3 = new Book(ISBN_3, NAME_BOOK_3, _publicationDateBook3);
            Catalog catalog = new Catalog();
                        
            Console.WriteLine(book1.Equals(book3));

            catalog.Add(book2);                       
            catalog.Add(book3);
            catalog.Add(book1);

            foreach (var book in catalog)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("");

            foreach (var book in catalog.GetBooks(author2.FirstName, author2.LastName))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("");

            foreach (var book in catalog.SortByDate())
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("");

            foreach (var a in catalog.GetCountBooksOfAuthors())
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("");

            Console.WriteLine(catalog.GetBook(ISBN_1));
        }
    }
}
