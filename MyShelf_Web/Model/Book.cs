namespace MyShelf_Web.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookSummary { get; set; }
        public string BookCoverImage { get; set; }
        public int PageCount { get; set; }
        public string ISBN13 { get; set; }
        public decimal Price { get; set; }

        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public int FormatID { get; set; }
        public int LanguageID { get; set; }

        public int AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
