using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace leave_management.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeRepository _repository;
        private readonly IMapper _mapper;

        public LeaveTypeController(ILeaveTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _repository.FindAll();
            var model = _mapper.Map<List<LeaveType>, List<DetailsLeaveTypeVm>>(leaveTypes.ToList());
            return View(model);
        }
    }
}