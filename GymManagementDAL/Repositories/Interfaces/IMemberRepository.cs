using GymManagementDAL.Entities;


namespace GymManagementDAL.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Member? GetById(int id);
        IEnumerable<Member> GetAll();
        int Add(Member member);
        int Update(Member member);
        int Delete(int id);
    }
}
