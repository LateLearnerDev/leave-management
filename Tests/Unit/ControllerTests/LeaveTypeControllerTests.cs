using System;
using System.Threading.Tasks;
using leave_management.Controllers;
using leave_management.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Services.Data;
using Services.Services.Services.Interfaces;

namespace Tests.Unit.ControllerTests
{
    [TestFixture]
    public class LeaveTypeControllerTests
    {
        [Test]
        public async Task Create_WhenReturnsWithNewLeaveType_ReturnsIndexView()
        {
            // Arrange
            var leaveTypeDto = new LeaveTypeDto {Name = "Name", IsActive = true};
            var service = new Mock<ILeaveTypeService>();
            service.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(LeaveType.Create(It.IsAny<string>(), It.IsAny<bool>()));

            var controller = new LeaveTypeController(service.Object);

            // Act
            var result = await controller.Create(leaveTypeDto) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Index", result.ActionName);
        }
        
        [Test]
        public async Task Create_WhenCreateServiceReturnsNull_ReturnsCreateViewWithModel()
        {
            // Arrange
            var leaveTypeDto = new LeaveTypeDto {Name = "Name", IsActive = true};
            var service = new Mock<ILeaveTypeService>();
            service.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(default(LeaveType));

            var controller = new LeaveTypeController(service.Object);

            // Act
            var result = await controller.Create(leaveTypeDto) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}