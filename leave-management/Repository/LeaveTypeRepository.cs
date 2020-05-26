using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<LeaveType>> FindAll()
        {
            return await _db.LeaveTypes.ToListAsync();
        }

        public async Task<LeaveType> Create(LeaveType entity)
        {
            await _db.LeaveTypes.AddAsync(entity);
            await Save();
            return entity;
        }

        public LeaveType Delete(LeaveType entity)
        {
            var entityToBeDeleted = entity;
            _db.LeaveTypes.Remove(entity);
            return entityToBeDeleted;
        }

        public async Task<LeaveType> FindById(int id)
        {
            return await _db.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        }        

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveType>> GetEmployeesByType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
