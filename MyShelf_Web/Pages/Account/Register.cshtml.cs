using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnPost()
        {
            string firstName = NewUser.FirstName;
        }
    }
}
