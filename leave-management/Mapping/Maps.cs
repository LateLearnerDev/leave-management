using AutoMapper;
using leave_management.Data;
using leave_management.Models;

namespace leave_management.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, DetailsLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVm>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVm>().ReverseMap();
            CreateMap<Employee, EmployeeVm>().ReverseMap();
        }
    }
}