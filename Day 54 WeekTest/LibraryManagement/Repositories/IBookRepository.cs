using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void AddBook(Book book);

        void DeleteBook(int id);
    }
}

