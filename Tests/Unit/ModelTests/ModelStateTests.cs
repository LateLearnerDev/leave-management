using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using leave_management.Controllers;
using leave_management.Models;
using Moq;
using NUnit.Framework;
using Services.Services.Services.Interfaces;

namespace Tests.Unit.ControllerTests
{
    [TestFixture]
    public class ModelStateTests
    {
        [Test]
        public void LeaveType_WhenModelHasNoName_ReturnsFalse()
        {
            // Arrange
            var result = new List<ValidationResult>();
            var leaveType = new LeaveTypeDto
            {
                IsActive = true, Id = 1, DateCreated = DateTime.Now, Name = ""
            };

            // Act 
            var isValid = Validator.TryValidateObject(leaveType, new ValidationContext(leaveType), result);
            
            // Assert
            Assert.IsFalse(isValid);
        }
    }
}