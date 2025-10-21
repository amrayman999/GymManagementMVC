using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            var members = _memberService.GetAllMembers();
            //ViewBag.Message = "Hello";
            //ViewData["Welcome"] = "Hello Members";
            return View(members);
        }
        public IActionResult MemberDetails(int id)
        {
            var member = _memberService.GetMemberDetails(id);
            if (member is null)
            {
                TempData["ErrorMessage"] = "Member Not Found!";
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
        public IActionResult HealthRecordDetails(int id)
        {
            var healthRecord = _memberService.GetMemberHealthRecord(id);
            if (healthRecord is null)
            {
                TempData["ErrorMessage"] = "Member Not Found!";
                return RedirectToAction(nameof(Index));
            }
            return View(healthRecord);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(CreateMemberViewModel input)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataMissed", "Check Missing Data");
                return View(nameof(Create), input);
            }
            bool result = _memberService.CreateMember(input);
            if (result)
                TempData["SuccessMessage"] = "Member Created Successfully!";
            else
                TempData["ErrorMessage"] = "Member Failed To Create, Phone or Email Already Exist";
            return RedirectToAction(nameof(Index));

        }
    }
}
