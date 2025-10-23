using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.SessionViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagementPL.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            var sessions = _sessionService.GetAllSessions();
            return View(sessions);
        }
        public IActionResult Create()
        {
            LoadCategoriesDropDown();
            LoadTrainersDropDown();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSessionViewModel input)
        {   
            if(!ModelState.IsValid)
            {
                LoadCategoriesDropDown();
                LoadTrainersDropDown();
                return View(input);
            }
            var result = _sessionService.CreateSession(input);
            if(result)
            {
                TempData["SuccessMessage"] = "Session created successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create session. Please verify trainer and category exist";
                return View(input);
            }
               

        }


        #region Helper Methods
        public void LoadCategoriesDropDown()
        {
            var categories = _sessionService.GetCategoriesDropDown();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
        public void LoadTrainersDropDown()
        {
            var trainers = _sessionService.GetTrainersDropDown();
            ViewBag.Trainers = new SelectList(trainers, "Id", "Name");
        }
        #endregion
    }
}
