using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.PlanViewModels;
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
                TempData["ErrorMessage"] = "Invalid Plan Id";
                return RedirectToAction("Index");
            }
            var plan = _planService.GetPlanById(id);
            if(plan == null)
            {
                TempData["ErrorMessage"] = "Plan not found.";
                return RedirectToAction("Index");
            }
            return View(plan);
        }
        public IActionResult Edit(int id)
        {
            if(id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Plan Id";
                return RedirectToAction("Index");
            }
            var plan = _planService.GetPlanToUpdate(id);
            if(plan == null)
            {
                TempData["ErrorMessage"] = "Plan Cannot be Updated.";
                return RedirectToAction("Index");
            }
            return View(plan);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdatePlanViewModel input)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Wrong Data", "Check Data Validation");
                return View(input);
            }
            var result = _planService.UpdatePlan(id, input);
            if (result)
            {
                TempData["SuccessMessage"] = "Plan Updated Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed To Update Plan";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Activate(int id)
        {
            var result = _planService.Activate(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Plan Status Changed";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed To Change Plan Status";
            }
            return RedirectToAction("Index");
        }
    }
}
