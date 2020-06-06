using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;
using leave_management.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Entities.Repositories
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<LeaveAllocation>> FindAll()
        {
            return await _db.LeaveAllocations.ToListAsync();
        }

        public async Task<LeaveAllocation> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            await Save();
            return entity;
        }

        public LeaveAllocation Delete(LeaveAllocation entity)
        {
            var entityToBeDeleted = entity;
            _db.LeaveAllocations.Remove(entity);
            return entityToBeDeleted;
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            return await _db.LeaveAllocations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }
    }
}
