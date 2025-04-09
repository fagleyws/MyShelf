using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Books
{
    [Authorize]
    [BindProperties]
    public class EditBookModel : PageModel
    {
        public Book CurrentBook { get; set; }
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Publishers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Formats { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Languages { get; set; } = new List<SelectListItem>();

        public List<GenreInfo> Genres { get; set; } = new List<GenreInfo>();

        public List<int> SelectedGenreIDs { get; set; } = new List<int>();
        public void OnGet(int id)
        {
            PopulateBookDetails(id);
            PopulateAuthorList();
            PopulatePublisherList();
            PopulateFormatList();
            PopulateLanguageList();
            SelectedGenreIDs = PopulateSelectedGenreIDS(id);
            PopulateGenreList();
            
        }

        private List<int> PopulateSelectedGenreIDS(int id)
        {
            List<int> selectedGenreIDs = new List<int>();
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT GenreID FROM BookGenre WHERE BookID = @bookID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        selectedGenreIDs.Add(reader.GetInt32(0));
                    }
                }
            }
            return selectedGenreIDs;
        }

        private void PopulateBookDetails(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string query = "SELECT BookID, BookTitle, BookSummary, ISBN13, PageCount, Price, LanguageID, FormatID, PublisherID, AuthorID, BookCoverImage FROM Book WHERE BookID = @bookID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@bookID", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CurrentBook = new Book
                        {
                            BookID = reader.GetInt32(0),
                            BookTitle = reader.GetString(1),
                            BookSummary = reader.GetString(2),
                            ISBN13 = reader.GetString(3),
                            PageCount = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            LanguageID = reader.GetInt32(6),
                            FormatID = reader.GetInt32(7),
                            PublisherID = reader.GetInt32(8),
                            AuthorID = reader.GetInt32(9),
                            BookCoverImage = reader.GetString(10)
                        };
                    }
                }
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
                        Genres.Add(genre);
                        if (SelectedGenreIDs.Contains(genre.GenreID))
                        {
                            genre.IsSelected = true;
                        }
                        else
                        {
                            genre.IsSelected = false;
                        }
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
}
