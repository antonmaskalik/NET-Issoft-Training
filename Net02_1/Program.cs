using System;
using System.Collections.Generic;

namespace Net02_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Jeffrey","Richter");           
            List<Author> authors1 = new List<Author>();
            authors1.Add(author1);

            Author author2 = new Author("Stephen", "King");
            List<Author> authors2 = new List<Author>();
            authors2.Add(author2);

            Book book1 = new Book("012-3-45-678900-1", "Book1", new DateTime(2004, 02, 23), authors2);
            Book book2 = new Book("0123456789002", "Book2", new DateTime(2001, 04, 20), authors1);
            Book book3 = new Book("0123456789003", "Book3", new DateTime(2010, 05, 11));
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
        }
    }
}
