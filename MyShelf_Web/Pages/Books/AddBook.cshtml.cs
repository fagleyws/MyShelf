using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;
using System.Security.Claims;

namespace MyShelf_Web.Pages.Books
{
    [Authorize]
    [BindProperties]
    public class AddBookModel : PageModel
    {
        public Book NewBook { get; set; }
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Publishers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Formats { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Languages { get; set; } = new List<SelectListItem>();

        public List<GenreInfo> Genres { get; set; } = new List<GenreInfo>();

        public List<int> SelectedGenreIDs { get; set; } = new List<int>();

        public void OnGet()
        {
            PopulateAuthorList();
            PopulatePublisherList();
            PopulateFormatList();
            PopulateLanguageList();
            PopulateGenreList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Book (BookTitle, BookSummary, ISBN13, PageCount, Price, LanguageID, FormatID, PublisherID, AuthorID, BookCoverImage, AddedBy, DateAdded) " +
                        "VALUES (@title, @description, @isbn, @pageCount, @price, @languageID, @formatID, @publisherID, @authorID, @coverImageURL, @addedBy, @dateAdded); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@title", NewBook.BookTitle);
                    cmd.Parameters.AddWithValue("@description", NewBook.BookSummary);
                    cmd.Parameters.AddWithValue("@isbn", NewBook.ISBN13);
                    cmd.Parameters.AddWithValue("@pageCount", NewBook.PageCount);
                    cmd.Parameters.AddWithValue("@price", NewBook.Price);
                    cmd.Parameters.AddWithValue("@languageID", NewBook.LanguageID);
                    cmd.Parameters.AddWithValue("@formatID", NewBook.FormatID);
                    cmd.Parameters.AddWithValue("@publisherID", NewBook.PublisherID);
                    cmd.Parameters.AddWithValue("@authorID", NewBook.AuthorID);
                    cmd.Parameters.AddWithValue("@coverImageURL", NewBook.BookCoverImage);
                    int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    cmd.Parameters.AddWithValue("@addedBy", userId);
                    cmd.Parameters.AddWithValue("@dateAdded", System.DateTime.Now);
                    conn.Open();
                    int bookID = int.Parse(cmd.ExecuteScalar().ToString());

                    for (int i=0;i<SelectedGenreIDs.Count; i++)
                    {
                        cmdText = "INSERT INTO BookGenre (BookID, GenreID) VALUES (@bookID, @genreID)";
                        cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        cmd.Parameters.AddWithValue("@genreID", SelectedGenreIDs[i]);
                        cmd.ExecuteNonQuery();
                    }                    
                }
                return RedirectToPage("/Books/BrowseBooks");
            }
            else
            {
                PopulateAuthorList();
                PopulatePublisherList();
                PopulateFormatList();
                PopulateLanguageList();
                PopulateGenreList();
                return Page();
            }
        }

        private void PopulateGenreList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT GenreID, GenreName FROM Genre";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var genre = new GenreInfo();
                        genre.GenreID = int.Parse(reader["GenreID"].ToString());
                        genre.GenreName = reader["GenreName"].ToString();
                        genre.IsSelected = false;
                        Genres.Add(genre);
                    }
                }
            }
        }

        private void PopulateLanguageList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT LanguageID, LanguageName FROM Language";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var language = new SelectListItem();
                        language.Value = reader["LanguageID"].ToString();
                        language.Text = reader["LanguageName"].ToString();
                        Languages.Add(language);
                    }
                    var defaultLanguage = new SelectListItem();
                    defaultLanguage.Value = "0";
                    defaultLanguage.Text = "--Select Language--";
                    Languages.Insert(0, defaultLanguage);
                }
            }
        }

        private void PopulateFormatList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT FormatID, FormatName FROM Format";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var format = new SelectListItem();
                        format.Value = reader["FormatID"].ToString();
                        format.Text = reader["FormatName"].ToString();
                        Formats.Add(format);
                    }
                    var defaultFormat = new SelectListItem();
                    defaultFormat.Value = "0";
                    defaultFormat.Text = "--Select Format--";
                    Formats.Insert(0, defaultFormat);
                }
            }
        }

        private void PopulatePublisherList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT PublisherID, PublisherName FROM Publisher";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var publisher = new SelectListItem();
                        publisher.Value = reader["PublisherID"].ToString();
                        publisher.Text = reader["PublisherName"].ToString();
                        Publishers.Add(publisher);
                    }
                    var defaultPublisher = new SelectListItem();
                    defaultPublisher.Value = "0";
                    defaultPublisher.Text = "--Select Publisher--";
                    Publishers.Insert(0, defaultPublisher);

                }
            }
        }

        private void PopulateAuthorList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT AuthorID, AuthorFirstName + ' ' + AuthorLastName AS AuthorName FROM Author";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var author = new SelectListItem();
                        author.Value = reader["AuthorID"].ToString();
                        author.Text = reader["AuthorName"].ToString();
                        Authors.Add(author);
                    }
                    var defaultAuthor = new SelectListItem();
                    defaultAuthor.Value = "0";
                    defaultAuthor.Text = "--Select Author--";
                    Authors.Insert(0, defaultAuthor);
                }                
            }
        }
    }

    public class GenreInfo
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public bool IsSelected { get; set; }
    }
}
