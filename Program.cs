using HomeLibrary.Data;
using HomeLibrary.Models;
using HomeLibrary.Services;
using System;

namespace HomeLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the database context and repositories.
            var context = new DatabaseContext();
            var bookRepository = new BookRepository(context);
            var bookService = new BookService(bookRepository);

            // Main loop for user interaction.
            while (true)
            {
                // Display menu options to the user.
                Console.WriteLine("\n1. Add Book");
                Console.WriteLine("2. List All Books");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Update Book Description");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                // Parse user input and handle invalid input.
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                // Handle user's choice.
                switch (choice)
                {
                    case 1:
                        AddBook(bookService); // Add a new book.
                        break;
                    case 2:
                        ListAllBooks(bookService); // List all books.
                        break;
                    case 3:
                        EditBook(bookService); // Edit an existing book.
                        break;
                    case 4:
                        DeleteBook(bookService); // Delete a book.
                        break;
                    case 5:
                        UpdateBookDescription(bookService); // Add book description 
                        break;
                    case 6:
                        Console.WriteLine("Exiting application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again."); // Handle unknown input.
                        break;
                }
            }
        }

        // Method to add a new book to the library.
        static void AddBook(BookService bookService)
        {
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine() ?? "";

            Console.WriteLine("Enter author name:");
            string author = Console.ReadLine() ?? "";

            // Create a new Book object and add it to the library.
            Book newBook = new Book { Title = title, Author = author };
            bookService.AddBook(newBook);
            Console.WriteLine("Book added successfully!");
        }

        // Method to list all books in the library.
        static void ListAllBooks(BookService bookService)
        {
            var books = bookService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}");
                Console.WriteLine($"Description: {book.Description}");
                Console.WriteLine(); // empty line for better readability
            }
        }

        // Method to edit details of an existing book.
        static void EditBook(BookService bookService)
        {
            Console.WriteLine("Enter the ID of the book to edit:");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            // Fetch the book and handle non-existent book scenario.
            Book book = bookService.GetBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            // Edit book details.
            Console.WriteLine("Enter new title (leave blank to keep current):");
            string? newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
            {
                book.Title = newTitle;
            }

            // Update the book in the library.
            bookService.UpdateBook(book);
            Console.WriteLine("Book updated successfully!");
        }

        // Method to delete a book from the library.
        static void DeleteBook(BookService bookService)
        {
            Console.WriteLine("Enter the ID of the book to delete:");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            // Delete the book and confirm deletion.
            bookService.DeleteBook(bookId);
            Console.WriteLine("Book deleted successfully!");
        }

        // Method to add a description to an existing book
        static void UpdateBookDescription(BookService bookService)
        {
            Console.WriteLine("Enter the ID of the book to update the description:");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Book book = bookService.GetBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            Console.WriteLine("Current Description: " + book.Description);
            Console.WriteLine("Enter new description:");
            book.Description = Console.ReadLine() ?? "";

            bookService.UpdateBook(book);
            Console.WriteLine("Book description updated successfully!");
        }
    }
}
