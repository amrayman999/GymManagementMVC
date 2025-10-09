using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class TrainerRepository : GenericRepository<Trainer>
    {
        public TrainerRepository(GymDbContext context) : base(context)
        {

        }
    }
}
