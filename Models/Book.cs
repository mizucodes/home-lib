namespace HomeLibrary.Models
{
    // The Book class now inherits from LibraryItem, gaining its properties and methods.
    public class Book : LibraryItem
    {
        public string? Author { get; set; }

        // Implement the abstract method from LibraryItem.
        // For example, return a string describing the book.
        public override string GetDescription()
        {
            return $"Title: {Title}, Author: {Author}";
        }

        // Additional properties specific to Book can be added here.
        // For example:
        // public string Genre { get; set; }
        // public DateTime PublishedDate { get; set; }
    }
}
