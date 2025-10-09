using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;


namespace GymManagementDAL.Repositories.Classes
{
    public class HealthRecordRepository : GenericRepository<HealthRecord>
    {
        public HealthRecordRepository(GymDbContext context) : base(context)
        {
        }

    }
}
