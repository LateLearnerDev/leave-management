using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    public class LeaveAllocationDto
    {
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        
        public EmployeeDto Employee { get; set; }
        public string EmployeeId { get; set; }

        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}