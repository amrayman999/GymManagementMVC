using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class SessionRepository : ISessionRepository
    {
        private readonly GymDbContext _context;

        public SessionRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Session session)
        {
            _context.Sessions.Add(session);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var session = GetById(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                return _context.SaveChanges();
            }
            return 0;
        }
        public IEnumerable<Session> GetAll() => _context.Sessions.ToList();
        public Session? GetById(int id) => _context.Sessions.Find(id);
        public int Update(Session session)
        {
            _context.Sessions.Update(session);
            return _context.SaveChanges();

        }
    }
}
