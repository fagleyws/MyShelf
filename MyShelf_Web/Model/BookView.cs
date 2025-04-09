namespace MyShelf_Web.Model
{
    public class BookView
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string ISBN13 { get; set; }
        public string BookCoverImage { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string LanguageName { get; set; }
        public string FormatName { get; set; }
        public List<string> GenreNames { get; set; } = new List<string>();
    }
}
