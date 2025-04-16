using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages;

public class IndexModel : PageModel
{
    public List<BookCover> BookCovers { get; set; } = new List<BookCover>();

    public void OnGet()
    {
        PopulateBookCovers();
    }

    private void PopulateBookCovers()
    {
        using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
        {
            string cmdText = "SELECT b.BookID, b.BookTitle, b.BookCoverImage, " +
                             "a.AuthorFirstName + ' ' + a.AuthorLastName as AuthorName " +
                             "FROM Book b " +
                             "JOIN Author a ON b.AuthorID = a.AuthorID " +
                             "ORDER BY b.BookTitle";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BookCover bookCover = new BookCover
                    {
                        BookID = reader.GetInt32(0),
                        BookTitle = reader.GetString(1),
                        BookCoverImage = reader.GetString(2),
                        BookAuthor = reader.GetString(3)
                    };
                    BookCovers.Add(bookCover);
                }
            }

        }
    }
}
