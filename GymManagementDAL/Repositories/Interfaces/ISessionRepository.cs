using GymManagementDAL.Entities;


namespace GymManagementDAL.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Session? GetById(int id);
        IEnumerable<Session> GetAll();
        int Add(Session session);
        int Update(Session session);
        int Delete(int id);
    }
}
