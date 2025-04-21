using System.ComponentModel.DataAnnotations;

namespace MyShelf_Web.Model
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Genre name cannot exceed 50 characters.")]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; } = string.Empty;
    }
}
