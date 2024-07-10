using GameTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        public class LoginRequestModel
        {
            public List<User>? Users { get; set; }
            public User? User { get; set; }
        }

        public IActionResult LoginView()
        {
            return PartialView("_LoginPartial", new PartialPage() { User = new User(), PageTitle = "Login" });
        }

        public IActionResult RegisterView()
        {
            return PartialView("_RegisterPartial", new PartialPage() { User = new User(), PageTitle = "Register" });
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            if (request == null || request.User == null)
            {
                return BadRequest("Invalid request data.");
            }

            if (request.Users.FindIndex(x => x.Username == request.User.Username) != -1 && request.Users.FindIndex(x => x.Password == request.User.Password) != -1)
            {
                request.User.IsLoggedIn = true;
            }

            return Ok(request.User);
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid request data.");
            }

            return Ok(user);
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
