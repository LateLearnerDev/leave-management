using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    public class LeaveHistoryDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
        public DateTime DateTimeRequested { get; set; }
        
        public EmployeeDto RequestingEmployee { get; set; }
        public string RequestingEmployedId { get; set; }
        
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        
        public EmployeeDto ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}