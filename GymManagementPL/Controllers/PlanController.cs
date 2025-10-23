using GymManagementBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        public IActionResult Index()
        {
            var plans = _planService.GetAllPlans();
            return View(plans);
        }
        public IActionResult Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction("Index");
            }
            var plan = _planService.GetPlanById(id);
            if(plan == null)
            {
                return RedirectToAction("Index");
            }
            return View(plan);
        }
    }
}
