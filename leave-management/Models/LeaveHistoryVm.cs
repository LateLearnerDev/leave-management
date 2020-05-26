using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    public class LeaveHistoryVm
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
        public DateTime DateTimeRequested { get; set; }
        
        public EmployeeVm RequestingEmployee { get; set; }
        public string RequestingEmployedId { get; set; }
        
        public DetailsLeaveTypeVm LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        
        public EmployeeVm ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}