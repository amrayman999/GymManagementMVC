using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int x = 10;
            return View(x);
        }
    }
}
