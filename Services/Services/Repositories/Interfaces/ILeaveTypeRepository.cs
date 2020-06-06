using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Data;

namespace Services.Services.Repositories.Interfaces
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
