using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        Membership? GetById(int id);
        IEnumerable<Membership> GetAll();
        int Add(Membership membership);
        int Update(Membership membership);
        int Delete(int id);
    }
}
