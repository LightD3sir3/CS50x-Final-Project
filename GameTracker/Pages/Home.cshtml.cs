using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameTracker.Pages
{
    public class HomeModel : PageModel
    {
        public string? pageTitle { get; set; } = "Home Page";

        public void OnGet()
        {

        }
    }
}
