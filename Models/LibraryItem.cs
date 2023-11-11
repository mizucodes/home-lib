namespace HomeLibrary.Models
{
    // Abstract class representing a general item in the library.
    public abstract class LibraryItem
    {
        // Common properties that all library items will have.
        public int BookId { get; set; }
        public string? Title { get; set; }

        // Abstract method that must be implemented by derived classes.
        // This could represent a method to describe the item, for example.
        public abstract string GetDescription();
    }
}
