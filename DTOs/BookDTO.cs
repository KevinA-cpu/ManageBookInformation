namespace ManageBookInformation.DTOs
{
    public class BookDTO
    {
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public int NumberOfPages { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
