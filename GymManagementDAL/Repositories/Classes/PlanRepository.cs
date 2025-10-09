using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class PlanRepository : GenericRepository<Plan>
    {
        public PlanRepository(GymDbContext context) : base(context)
        {
        }
    }
}
