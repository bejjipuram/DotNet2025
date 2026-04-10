using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_44_ADOdotNet
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    // Generic catalog class
    public class Catalog<T> where T : Book
    {
        private List<T> _items = new List<T>();
        private HashSet<string> _isbnSet = new HashSet<string>();
        private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();

        // Add item with genre indexing
        public bool AddItem(T item)
        {
            // 1️⃣ Check ISBN uniqueness
            if (_isbnSet.Contains(item.ISBN))
            {
                return false; // Duplicate ISBN not allowed
            }

            // 2️⃣ Add to main list
            _items.Add(item);

            // 3️⃣ Add ISBN to HashSet
            _isbnSet.Add(item.ISBN);

            // 4️⃣ Add to genre index
            if (!_genreIndex.ContainsKey(item.Genre))
            {
                _genreIndex[item.Genre] = new List<T>();
            }

            _genreIndex[item.Genre].Add(item);

            return true;
        }

        // Get books by genre using indexer
        public List<T> this[string genre]
        {
            get
            {
                if (_genreIndex.ContainsKey(genre))
                {
                    return _genreIndex[genre];
                }

                return new List<T>(); // Return empty list if genre not found
            }
        }

        // Find books using LINQ and lambda expressions
        public IEnumerable<T> FindBooks(Func<T, bool> predicate)
        {
            return _items.Where(predicate);
        }
    }
    class Program
    {
        static void Main()
        {
            Catalog<Book> library = new Catalog<Book>();

            Book book1 = new Book
            {
                ISBN = "978-3-16-148410-0",
                Title = "C# Programming",
                Author = "John Sharp",
                Genre = "Programming"
            };

            library.AddItem(book1);

            var programmingBooks = library["Programming"];
            Console.WriteLine(programmingBooks.Count); // Output: 1

            var johnsBooks = library.FindBooks(b => b.Author.Contains("John"));
            Console.WriteLine(johnsBooks.Count()); // Output: 1
        }
    }

}
