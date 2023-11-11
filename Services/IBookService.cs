using HomeLibrary.Models;
using System.Collections.Generic;

namespace HomeLibrary.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
    }
}
