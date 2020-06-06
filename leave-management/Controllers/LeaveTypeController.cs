using System;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Entities.Services.Interfaces;
using leave_management.Models;
using leave_management.Utils;
using Microsoft.AspNetCore.Mvc;

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

        public ActionResult Edit()
        {
            return View();
        }
        
        public ActionResult Details()
        {
            return View();
        }
        
        public ActionResult Delete()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeDto leaveTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(leaveTypeDto);

                var leaveType = await _service.Create(leaveTypeDto.Name, leaveTypeDto.IsActive);
                if (leaveType != null) 
                    return RedirectToAction(nameof(Index));
                
                ModelState.AddModelError("", "Something went wrong...");
                return View(leaveTypeDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}