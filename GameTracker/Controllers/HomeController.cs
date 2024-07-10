using GameTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers
{
    [Route("api/")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Home");
        }

        public IActionResult HomeView([FromBody] User userData)
        {
            User user = new User
            {
                Name = userData.Name,
                Surname = userData.Surname,
                BirthDate = userData.BirthDate,
                Username = userData.Username,
                Password = userData.Password
            };

            return View("Home", user);
        }
    }
}
