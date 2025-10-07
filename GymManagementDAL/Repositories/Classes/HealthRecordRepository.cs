using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Classes
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly GymDbContext _context;

        public HealthRecordRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(HealthRecord healthrecord)
        {
            _context.HealthRecords.Add(healthrecord);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var healthrecord = GetById(id);
            if (healthrecord != null)
            {
                _context.HealthRecords.Remove(healthrecord);
                return _context.SaveChanges();
            }
            return 0;


        }
        public IEnumerable<HealthRecord> GetAll() => _context.HealthRecords.ToList();
        public HealthRecord? GetById(int id) => _context.HealthRecords.Find(id);
        public int Update(HealthRecord healthrecord)
        {
            _context.HealthRecords.Update(healthrecord);
            return _context.SaveChanges();

        }
    }
}
