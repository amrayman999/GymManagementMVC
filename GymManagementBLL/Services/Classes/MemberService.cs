using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Classes;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;
        private readonly IGenericRepository<Membership> _membershipRepository;
        private readonly IGenericRepository<Plan> _planRepository;
        private readonly IGenericRepository<HealthRecord> _healthRecordRepository;

        public MemberService(
            IGenericRepository<Member> memberRepository,
            IGenericRepository<Membership> membershipRepository,
            IGenericRepository<Plan> planRepository,
            IGenericRepository<HealthRecord> healthRecordRepository) 
        { 
            _memberRepository = memberRepository;
            _membershipRepository = membershipRepository;
            _planRepository = planRepository;
            _healthRecordRepository = healthRecordRepository;
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
        public bool CreateMember(CreateMemberViewModel model)
        {
           try
            {
                if (IsEmailExists(model.Email))
                    return false;
                if (IsPhoneExists(model.Phone))
                    return false;

                var member = new Member
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Address = new Address
                    {
                        BuildingNumber = model.BuildingNumber,
                        City = model.City,
                        Street = model.Street
                    },
                    HealthRecord = new HealthRecord
                    {
                        Height = model.HealthRecordViewModel.Height,
                        Weight = model.HealthRecordViewModel.Weight,
                        BloodType = model.HealthRecordViewModel.BloodType,
                        Note = model.HealthRecordViewModel.Note
                    }
                };
                _memberRepository.Add(member);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public MemberViewModel? GetMemberDetails(int memberId)
        {
            var member = _memberRepository.GetById(memberId);
            if (member is null)
                return null;

            var memberViewModel = new MemberViewModel
            {
                Id = member.Id,
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Gender = member.Gender.ToString(),
                Address = FormatAddress(member.Address),
            };

            var activeMembership = _membershipRepository
                                    .GetAll(x => x.MemberId == member.Id && x.Status == "Active")
                                    .FirstOrDefault();
            if (activeMembership is not null)
            {
                var activePlan = _planRepository.GetById(activeMembership.PlanId);
                memberViewModel.PlanName = activePlan?.Name;
                memberViewModel.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                memberViewModel.MembershipEndDate = activeMembership.EndDate.ToShortDateString();
            }
            return memberViewModel;

        }
        public HealthRecordViewModel? GetMemberHealthRecord(int memberId)
        {
            var memberHealthRecord = _healthRecordRepository.GetById(memberId);
            if (memberHealthRecord is null)
                return null;

            return new HealthRecordViewModel
            {
                Height = memberHealthRecord.Height,
                Weight = memberHealthRecord.Weight,
                BloodType = memberHealthRecord.BloodType,
                Note = memberHealthRecord.Note

            };
            
        }

        #region Helper Methods
        private string FormatAddress(Address address)
        {
            if (address is null)
                return string.Empty;
            return $"{address.BuildingNumber}, {address.Street}, {address.City}";
        }
        private bool IsEmailExists(string email)
        {
            var existingMember = _memberRepository.GetAll(x => x.Email.ToLower() == email.ToLower());
            return existingMember is not null && existingMember.Any();
        }
        private bool IsPhoneExists(string phone)
        {
            var existingMember = _memberRepository.GetAll(x => x.Phone == phone);
            return existingMember is not null && existingMember.Any();
        }
        #endregion
    }
}
