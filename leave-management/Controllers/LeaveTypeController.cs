using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using leave_management.Utils;
using Microsoft.AspNetCore.Mvc;

namespace leave_management.Controllers
{
    public class  LeaveTypeController : BaseController
    {
        private readonly ILeaveTypeRepository _repository;
        private readonly IMapper _mapper;

        public LeaveTypeController(ILeaveTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var leaveTypes = (await _repository.FindAll()).ToList();
            var model = _mapper.Map<List<LeaveType>, List<DetailsLeaveTypeVm>>(leaveTypes);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}