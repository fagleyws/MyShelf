using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Books
{
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

        private void PopulateGenreList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT GenreID, GenreName FROM Genre";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var genre = new GenreInfo();
                    genre.GenreID = reader.GetInt32(0);
                    genre.GenreName = reader["GenreName"].ToString();
                    Genres.Add(genre);
                }
            }
        }

        private void PopulateLanguageList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT LanguageID, LanguageName FROM Language";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var language = new SelectListItem();
                    language.Value = reader.GetInt32(0).ToString();
                    language.Text = reader["LanguageName"].ToString();
                    Languages.Add(language);
                }
            }
        }

        private void PopulateFormatList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FormatID, FormatName FROM Format";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var format = new SelectListItem();
                    format.Value = reader.GetInt32(0).ToString();
                    format.Text = reader["FormatName"].ToString();
                    Formats.Add(format);
                }
            }
        }

        private void PopulatePublisherList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PublisherID, PublisherName FROM Publisher";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var publisher = new SelectListItem();
                    publisher.Value = reader.GetInt32(0).ToString();
                    publisher.Text = reader["PublisherName"].ToString();
                    Publishers.Add(publisher);
                }
            }
        }

        private void PopulateAuthorList()
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT AuthorID, AuthorFirstName + ' ' + AuthorLastName AS AuthorName FROM Author";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    var author = new SelectListItem();
                    author.Value = reader.GetInt32(0).ToString();
                    author.Text = reader["AuthorName"].ToString();
                    Authors.Add(author);
                }
            }
        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }

    public class GenreInfo
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public bool IsSelected { get; set; }
    }
}
