using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_32_M1Practice.LMS
{
    public class LibraryUtility
    {
        private List<Book> books = new List<Book>();
        private int autoId = 1;
        public void AddBook(string title, string author, string genre, int year)
        {
            Book book = new Book
            {
                Id = autoId++,
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year

            };
            books.Add(book);
        }
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupedBooks = new SortedDictionary<string, List<Book>>();
            foreach (var book in books)
            {
                if (!groupedBooks.ContainsKey(book.Genre))
                {
                    groupedBooks[book.Genre] = new List<Book>();
                }
                groupedBooks[book.Genre].Add(book);
            }
            return groupedBooks;
        }
        public List<Book> GetBookByAuthor(string author)
        {
            List<Book> result = new List<Book>();
            foreach (var x in books)
            {
                if (x.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(x);
                }
            }
            return result;
        }
        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }
}
