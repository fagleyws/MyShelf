using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public class EditGenreModel : PageModel
    {
        [BindProperty]
        public Genre CurrentGenre { get; set; } = new Genre();
        public void OnGet(int id)
        {
            PopulateGenreInfo(id);
        }

        public IActionResult OnPost(int id)
        {
            using (SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                conn.Open();
                string sql = "UPDATE Genre SET GenreName = @GenreName WHERE GenreID = @GenreID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@GenreName", CurrentGenre.GenreName);
                    cmd.Parameters.AddWithValue("@GenreID", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToPage("GenreList");
        }

        private void PopulateGenreInfo(int id)
        {
            using(SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
            {
                conn.Open();
                string sql = "SELECT GenreID, GenreName FROM Genre WHERE GenreID = @GenreID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@GenreID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentGenre.GenreID = reader.GetInt32(0);
                            CurrentGenre.GenreName = reader.GetString(1);
                        }
                    }
                }
            }
        }
    }
}
