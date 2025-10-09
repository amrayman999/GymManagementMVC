using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;


namespace GymManagementDAL.Repositories.Classes
{
    public class BookingRepository : IBookingRepository
    {
        private readonly GymDbContext _context;

        public BookingRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                return _context.SaveChanges();
            }
            return 0;


        }
        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();
        public Booking? GetById(int id) => _context.Bookings.Find(id);
        public int Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            return _context.SaveChanges();

        }
    }
}
