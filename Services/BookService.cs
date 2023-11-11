using HomeLibrary.Data;
using HomeLibrary.Models;
using System.Collections.Generic;

namespace HomeLibrary.Services
{
    // The BookService class provides a layer of abstraction over the BookRepository.
    // It implements the IBookService interface, ensuring it provides specific functionalities
    // related to books, such as adding, retrieving, updating, and deleting books.
    public class BookService : IBookService
    {
        // A private field to hold the reference to the BookRepository.
        // This repository is used for direct data operations.
        private readonly BookRepository _bookRepository;

        // Constructor to initialize the BookService with a specific BookRepository instance.
        // This dependency is typically injected by a dependency injection framework.
        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Adds a new book to the library.
        // Delegates the operation to the BookRepository to handle the database interaction.
        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        // Retrieves all books from the library.
        // Returns a list of Book objects by delegating the call to the BookRepository.
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        // Retrieves a single book by its ID.
        // Uses the BookRepository to find and return the book, or null if it's not found.
        public Book GetBookById(int bookId)
        {
            return _bookRepository.GetBookById(bookId);
        }

        // Updates the details of a given book in the library.
        // Passes the updated book object to the BookRepository to handle the modification.
        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        // Deletes a book from the library based on its ID.
        // Instructs the BookRepository to remove the book from the database.
        public void DeleteBook(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
        }
    }
}
