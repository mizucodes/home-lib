namespace HomeLibrary.Models
{
    // The Magazine class inherits from LibraryItem and represents a magazine in the library.
    public class Magazine : LibraryItem
    {
        public string? Publisher { get; set; }

        // Overriding the GetDescription method to return details specific to a magazine.
        public override string GetDescription()
        {
            return $"Magazine Title: {Title}, Publisher: {Publisher}";
        }

        // Additional properties specific to Magazine can be added here.
    }
}
