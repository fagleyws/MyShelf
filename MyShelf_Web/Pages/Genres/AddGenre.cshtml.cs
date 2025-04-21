using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Business;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public class AddGenreModel : PageModel
    {
        [BindProperty]
        public Genre NewGenre { get; set; } = new Genre();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Here you would typically save the new genre to the database
                try
                {
                    using(SqlConnection conn = new SqlConnection(AppHelper.GetDBConnectionString()))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Genre (GenreName) VALUES (@GenreName)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@GenreName", NewGenre.GenreName);
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
            return Page();
        }
    }
}
