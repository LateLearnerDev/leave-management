using System;
using System.ComponentModel.DataAnnotations;
using leave_management.Data;

namespace leave_management.Models
{
    public class LeaveTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public static LeaveTypeDto CreateFrom(LeaveType leaveType)
        {
            return new LeaveTypeDto
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                IsActive = leaveType.IsActive,
                DateCreated = leaveType.DateCreated
            };
        }
    }
    
}
