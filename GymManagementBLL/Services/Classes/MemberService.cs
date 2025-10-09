using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly GenericRepository<Member> _memberRepository;

        public MemberService(GenericRepository<Member> memberRepository) 
        { 
            _memberRepository = memberRepository;
        }
        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _memberRepository.GetAll() ?? [];
            if (members is null || !members.Any())
                return [];

            var memberViewModels = members.Select( x=> new MemberViewModel
            {
                Id = x.Id,
                Photo = x.Photo,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.DateOfBirth.ToShortDateString(),
                Gender = x.Gender.ToString(),
            });
            return memberViewModels;
        }

        #region Helper Methods
        private string FormatAddress(Address address)
        {
            if (address is null)
                return string.Empty;
            return $"{address.BuildingNumber}, {address.Street}, {address.City}";
        }
        #endregion
    }
}
