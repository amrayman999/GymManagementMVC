using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class TrainerRepository : GenericRepository<Trainer> , ITrainerRepository
    {
        public TrainerRepository(GymDbContext context) : base(context)
        {

        }

        public IEnumerable<Session> GetAllSessions(int trainerId)
        {
            throw new NotImplementedException();
        }
    }
}
