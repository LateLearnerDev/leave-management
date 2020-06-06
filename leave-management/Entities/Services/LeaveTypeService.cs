using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;
using leave_management.Entities.Repositories.Interfaces;
using leave_management.Entities.Services.Interfaces;

namespace leave_management.Entities.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _repository;

        public LeaveTypeService(ILeaveTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveType>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<LeaveType> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<LeaveType> Create(string name, bool isActive)
        {
            var entity = LeaveType.Create(name, isActive);
            return await _repository.Create(entity);
        }

        public async Task<bool> Update(int leaveTypeId, string name, bool isActive)
        {
            var entity = await _repository.FindById(leaveTypeId);
            entity.Update(name, isActive);
            return await _repository.Update(entity);
        }

        public async Task<bool> Delete(int leaveTypeId)
        {
            var entity = await _repository.FindById(leaveTypeId);
            entity.Delete();
            return await _repository.Delete(entity);
        }
    }
}