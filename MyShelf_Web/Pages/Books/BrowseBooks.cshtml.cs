using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Books
{
    public class BrowseBooksModel : PageModel
    {
        public List<BookView> Books { get; set; } = new List<BookView>();
        public void OnGet()
        {
            PopulateBookList();
        }

        private void PopulateBookList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT b.BookID, b.BookTitle, b.BookCoverImage, b.PageCount, b.Price, b.ISBN13," +
                    "a.AuthorFirstName + ' ' + a.AuthorLastName as AuthorName, p.PublisherName, f.FormatName, l.LanguageName, b.BookSummary" +
                    " FROM Book b " +
                    "JOIN Author a ON b.AuthorID = a.AuthorID " +
                    "JOIN Publisher p on b.PublisherID = p.PublisherID " +
                    "JOIN Format f on b.FormatID = f.FormatID " +
                    "JOIN Language l on b.LanguageID = l.LanguageID";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                       

                        BookView book = new BookView
                        {
                            BookID = reader.GetInt32(0),
                            BookTitle = reader.GetString(1),
                            BookCoverImage = reader.GetString(2),
                            PageCount = reader.GetInt32(3),
                            Price = reader.GetDecimal(4),
                            ISBN13 = reader.GetString(5),
                            AuthorName = reader.GetString(6),
                            PublisherName = reader.GetString(7),
                            FormatName = reader.GetString(8),
                            LanguageName = reader.GetString(9),
                            BookDescription = reader.GetString(10),
                            GenreNames = PopulateBookGenres(reader.GetInt32(0))
                        };
                        Books.Add(book);
                    }
                }
            }

        }

        private List<string> PopulateBookGenres(int bookID)
        {
            List<string> genres = new List<string>();
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT g.GenreName FROM Genre g " +
                    "JOIN BookGenre bg ON g.GenreID = bg.GenreID " +
                    "WHERE bg.BookID = @BookID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        genres.Add(reader.GetString(0));
                    }                    
                }
            }
            return genres;
        }

        public IActionResult OnPostDelete(int id)
        {
            // delete the book from the database
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Book WHERE BookID = @BookID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@BookID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            PopulateBookList();
            return Page();
        }
    }
}
