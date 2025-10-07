using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _context;

        public PlanRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Plan plan)
        {
            _context.Plans.Add(plan);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var plan = GetById(id);
            if (plan != null)
            {
                _context.Plans.Remove(plan);
                return _context.SaveChanges();
            }
            return 0;
        }
        public IEnumerable<Plan> GetAll() => _context.Plans.ToList();
        public Plan? GetById(int id) => _context.Plans.Find(id);
        public int Update(Plan plan)
        {
            _context.Plans.Update(plan);
            return _context.SaveChanges();

        }
    }
}
