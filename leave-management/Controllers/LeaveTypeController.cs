using System;
using System.Linq;
using System.Threading.Tasks;
using leave_management.ExtensionMethods;
using leave_management.Models;
using leave_management.Utils;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Services.Interfaces;

namespace leave_management.Controllers
{
    public class LeaveTypeController : BaseController
    {
        private readonly ILeaveTypeService _service;

        public LeaveTypeController(ILeaveTypeService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var leaveTypes = (await _service.FindAll()).ToList();
            var model = leaveTypes.Select(LeaveTypeDto.CreateFrom);
            return View(model);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeDto leaveTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(leaveTypeDto);

                var leaveType = await _service.Create(leaveTypeDto.Name, leaveTypeDto.IsActive);
                if (leaveType.HasValue()) 
                    return RedirectToAction(nameof(Index));
                
                ModelState.AddModelError("", "Something went wrong...");
                return View(leaveTypeDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var leaveType = await _service.FindById(id);
            if (!leaveType.HasValue())
                return NotFound();
        
            var model = LeaveTypeDto.CreateFrom(leaveType);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LeaveTypeDto leaveTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(leaveTypeDto);

                var leaveType = await _service.Update(leaveTypeDto.Id, leaveTypeDto.Name, leaveTypeDto.IsActive);
                
                if (leaveType.HasValue()) 
                    return RedirectToAction(nameof(Index));
                
                ModelState.AddModelError("", "Something went wrong...");
                return View(leaveTypeDto);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(leaveTypeDto);
            }
        }
        
        public ActionResult Details()
        {
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.Delete(id);
            if (isDeleted)
                return RedirectToAction(nameof(Index));
            
            ModelState.AddModelError("", "Something went wrong...");
            return RedirectToAction(nameof(Index));
        }

        
    }
}