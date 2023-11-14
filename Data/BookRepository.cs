using HomeLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary.Data
{
    // The BookRepository class is responsible for interacting directly with the data source,
    // in this case, the DatabaseContext, to perform CRUD operations on books.
    public class BookRepository
    {
        // A private field to hold the reference to the DatabaseContext.
        private readonly DatabaseContext _context;

        // Constructor to initialize the BookRepository with a specific DatabaseContext instance.
        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Adds a new book to the database.
        public void AddBook(Book book)
        {
            _context?.Books?.Add(book); // Adds the book to the DbSet<Book>.
            _context?.SaveChanges();    // Saves changes to the database.
        }

        // Retrieves all books from the database.
        public List<Book> GetAllBooks()
        {
            return _context?.Books?.ToList()!; // Retrieves all books as a List.
        }

        // Updates a book's details in the database.
        public void UpdateBook(Book book)
        {
            _context?.Books?.Update(book); // Updates the book in the DbSet<Book>.
            _context?.SaveChanges();       // Saves changes to the database.
        }

        // Deletes a book from the database by its ID.
        public void DeleteBook(int bookId)
        {
            var book = _context?.Books?.Find(bookId); // Finds the book by its ID.
            if (book != null)
            {
                _context?.Books?.Remove(book); // Removes the book from the DbSet<Book>.
                _context?.SaveChanges();       // Saves changes to the database.
            }
        }

        // Retrieves a single book by its ID.
        public Book GetBookById(int bookId)
        {
            return _context?.Books?.Find(bookId)!; // Finds the book by its ID.
        }

        // Ability to search for a book by Title
        public List<Book> SearchBooks(string searchTerm)
        {
            // Check if the context or the Books set is null before proceeding
            if (_context == null || _context.Books == null)
            {
                return new List<Book>();
            }

            // Perform the search on non-null DbSet
            return _context.Books
                .Where(book => book.Title != null && book.Title.Contains(searchTerm) ||
                               book.Author != null && book.Author.Contains(searchTerm))
                .ToList();
        }
    }
}
