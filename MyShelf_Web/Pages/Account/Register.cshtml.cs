using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyShelf_Web.Model;

namespace MyShelf_Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Registration NewUser { get; set; }
        public void OnGet()
        {            
            //NewUser.FirstName = "John";
        }

        public IActionResult OnPost()
        {
            // Validate User Input
            if (ModelState.IsValid)
            {
                // Save to Database
                // 1. Create a connection to the database
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyShelf;Trusted_Connection=True;";
                SqlConnection conn = new SqlConnection(connectionString);
                // 2. Create a command to insert the data
                string cmdText = "INSERT INTO [User] (UserFirstName, UserLastName, UserProfileImage, UserEmail, UserPassword, AccountTypeID) VALUES (@FirstName, @LastName, @ProfileImage, @Email, @Password, 3)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@FirstName", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", NewUser.LastName);
                cmd.Parameters.AddWithValue("@ProfileImage", "default.jpg");
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                // 3. Execute the command
                conn.Open();
                cmd.ExecuteNonQuery();
                // 4. Close the connection
                conn.Close();

                // Redirect to Login Page
                return RedirectToPage("/Account/Login");
            }
            else
            {
                return Page();
            }
        }
    }   
}
