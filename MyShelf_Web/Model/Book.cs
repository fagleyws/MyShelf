using System.ComponentModel.DataAnnotations;

namespace MyShelf_Web.Model
{
    public class Book
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Book Title is required")]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "Book Summary is required")]
        [Display(Name = "Book Summary")]
        public string BookSummary { get; set; }

        public string BookCoverImage { get; set; }
        [Required(ErrorMessage = "Page Count is required")]
        [Display(Name = "Page Count")]
        [Range(1, int.MaxValue, ErrorMessage = "Page Count must be greater than 0")]
        public int PageCount { get; set; }
        public string ISBN13 { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Display(Name = "Author")]
        [Range(1, int.MaxValue, ErrorMessage = "Select an author")]
        public int AuthorID { get; set; }
        [Display(Name = "Publisher")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a publisher")]
        public int PublisherID { get; set; }
        [Display(Name = "Book Format")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a book format")]
        public int FormatID { get; set; }
        [Display(Name = "Language")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a language")]
        public int LanguageID { get; set; }

        public int AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
