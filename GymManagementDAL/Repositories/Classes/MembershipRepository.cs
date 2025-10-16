using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;


namespace GymManagementDAL.Repositories.Classes
{
    public class MembershipRepository : GenericRepository<Membership>
    {
        public MembershipRepository(GymDbContext context) : base(context)
        {
        }
    }
    
}
