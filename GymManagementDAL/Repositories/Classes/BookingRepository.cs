using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;


namespace GymManagementDAL.Repositories.Classes
{
    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(GymDbContext context) : base(context)
        {

        }
    }
}
