﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Services.Repositories.Interfaces;

namespace Services.Services.Repositories
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<LeaveHistory>> FindAll()
        {
            return await _db.LeaveHistories.ToListAsync();
        }

        public async Task<LeaveHistory> Create(LeaveHistory entity)
        {
            await _db.LeaveHistories.AddAsync(entity);
            await Save();
            return entity;
        }

        public LeaveHistory Delete(LeaveHistory entity)
        {
            var entityToBeDeleted = entity;
            _db.LeaveHistories.Remove(entity);
            return entityToBeDeleted;
        }

        public async Task<LeaveHistory> FindById(int id)
        {
            return await _db.LeaveHistories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return await Save();
        }
    }
}
