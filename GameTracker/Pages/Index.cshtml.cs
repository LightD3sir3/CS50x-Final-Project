using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameTracker.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return new RedirectToPageResult("/Home");
        }
    }
}
