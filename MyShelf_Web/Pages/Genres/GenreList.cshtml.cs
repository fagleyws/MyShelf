using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Genres
{
    public class GenreListModel : PageModel
    {
        public List<Genre> GenreList { get; set; } = new List<Genre>();
        public void OnGet()
        {
            PopulateGenreList();
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                if (User.IsInRole("Admin") == false)
                {
                    return RedirectToPage("/Account/AccessDenied");
                }
                using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    string sql = "DELETE FROM Genre WHERE GenreID = @GenreID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GenreID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToPage("GenreList");
            }
            catch
            {
                throw;
            }
        }

        private void PopulateGenreList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT GenreID, GenreName FROM Genre ORDER BY GenreName";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Genre genre = new Genre
                                {
                                    GenreID = reader.GetInt32(0),
                                    GenreName = reader.GetString(1)
                                };
                                GenreList.Add(genre);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
