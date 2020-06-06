using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Data
{
    public class LeaveType
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; private set; }
        
        private LeaveType() { }

        private LeaveType(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
            DateCreated = DateTime.Now;
        }

        internal static LeaveType Create(string name, bool isActive)
        {
            return new LeaveType(name, isActive);
        }

        internal LeaveType Update(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
            return this;
        }

        internal LeaveType Delete()
        {
            IsActive = false;
            return this;
        }
    }
}
