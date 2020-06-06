using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Data;

namespace Services.Services.Services.Interfaces
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