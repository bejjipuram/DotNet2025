using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_32_M1Practice.LMS
{
    public class LMSMain
    {
        public static void Main(string[] args)
        {
            LibraryUtility library = new LibraryUtility();
            library.AddBook("The Alchemist", "Paulo Alto", "Fiction", 1988);
            library.AddBook("Educated", "Tara", "Non-Fiction", 2025);
            library.AddBook("Sherlock Holmes", "Arthur Weasly", "Mystery", 2005);
            library.AddBook("Inferno", "Ronald", "Mystery", 2047);
            library.AddBook("The Bride", "Paulo Alto", "Fiction", 1999);

            Console.WriteLine("Book Grouped by Genre:");
            var groupedBooks = library.GroupBooksByGenre();
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"\nGenre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine($"  {book.Title} by {book.Author} released in {book.PublicationYear}");
                }
            }

            Console.WriteLine("\nBooks by Paulo Alto");
            var authorBooks = library.GetBookByAuthor("Paulo Alto");
            foreach (var book in authorBooks)
            {
                Console.WriteLine($"  {book.Title} ({book.Genre})");
            }

            Console.WriteLine("\nLibrary Statistics:");
            Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"{genre.Key}: {genre.Value.Count} books");
            }
        }
    }
}
