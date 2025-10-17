using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.AnalyticsViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnalyticsViewModel GetAnalyticsData()
        {

            return new AnalyticsViewModel
            {
                TotalMembers = _unitOfWork.GetRepository<Member>().GetAll().Count(),
                ActiveMembers = _unitOfWork.GetRepository<Membership>().GetAll(m => m.Status == "Active").Count(),
                TotalTrainers = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpcomingSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.StartDate > DateTime.Now).Count(),
                OngoingSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now).Count(),
                CompletedSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.EndDate < DateTime.Now).Count()
            };
        }
    }
}
