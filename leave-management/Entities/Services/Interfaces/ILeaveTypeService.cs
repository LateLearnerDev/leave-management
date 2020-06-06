using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;

namespace leave_management.Entities.Services.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveType>> FindAll();
        Task<LeaveType> FindById(int id);
        Task<LeaveType> Create(string name, bool isActive);
        Task<bool> Delete(int leaveTypeId);
        Task<bool> Update(int leaveTypeId, string name, bool isActive);
    }
}