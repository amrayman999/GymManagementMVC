using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;


namespace GymManagementDAL.Repositories.Classes
{
    public class MemberRepository : IMemberRepository
    {
        GymDbContext _context = new GymDbContext();
        public int Add(Member member)
        {
            _context.Members.Add(member);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var member = GetById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                return _context.SaveChanges();
            }
            return 0;


        }
        public IEnumerable<Member> GetAll() => _context.Members.ToList();
        public Member? GetById(int id) => _context.Members.Find(id);
        public int Update(Member member)
        {
            _context.Members.Update(member);
            return _context.SaveChanges();

        }
    }
}
