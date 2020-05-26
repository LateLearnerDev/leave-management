using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management.Data
{
    public class LeaveHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
        public DateTime DateTimeRequested { get; set; }

        [ForeignKey("RequestingEmployeedId")]
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeedId { get; set; }
              
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        [ForeignKey("ApprovedById")]
        public Employee ApprovedBy { get; set; }
        public string ApprovedById { get; set; }

    }
}
