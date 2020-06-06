using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;

namespace leave_management.Entities.Repositories.Interfaces
{
    public interface ILeaveTypeRepository
    {
        Task<ICollection<LeaveType>> GetEmployeesByType(int id);
        Task<IEnumerable<LeaveType>> FindAll();
        Task<LeaveType> FindById(int id);
        Task<LeaveType> Create(LeaveType leaveType);
        Task<bool> Delete(LeaveType entity);
        Task<bool> Update(LeaveType entity);
    }
}
