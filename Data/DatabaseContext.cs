using Microsoft.EntityFrameworkCore;
using HomeLibrary.Models;

namespace HomeLibrary.Data
{
    // The DatabaseContext class extends the DbContext class from Entity Framework Core.
    // It acts as a session with the database, allowing for querying and saving data.
    public class DatabaseContext : DbContext
    {
        // DbSet<Book> represents the collection of all Books in the context.
        // It corresponds to the Books table in the database.
        public DbSet<Book>? Books { get; set; }

        // OnConfiguring is overridden to configure the database context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the context to connect to an SQLite database.
            // The database file is named 'home_library.db'.
            optionsBuilder.UseSqlite("Data Source=home_library.db");
        }
    }
}
