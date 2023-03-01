using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManagementSystemBackend.Dto;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin,trainee")]
    public class AssignTask : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AssignTask(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult get()
        {
            var userswithtasks = _unitOfWork.AssignTask.GetAll(IncludeProperties: "registeredUsers,tasks");
            return Ok(userswithtasks);
        }
        [HttpPost]
        public IActionResult addtasktouser([FromBody] AssignTaskDto assignTaskDto)
        {
            var usertask = _mapper.Map<AssignTaskDto, AssignTasks>(assignTaskDto);
            if (usertask != null)
            {
                _unitOfWork.AssignTask.Add(usertask);
                _unitOfWork.AssignTask.Save();
                return Ok(usertask);
            }
            return BadRequest();
        }
    
        [HttpDelete("{id:int}")]
        public IActionResult deleteStauts(int id)
        {
            var taskfromdb = _unitOfWork.AssignTask.GetById(id);
            if(taskfromdb != null)
            {
                _unitOfWork.AssignTask.Remove(taskfromdb);
                _unitOfWork.AssignTask.Save();
                return Ok();
            }
            return BadRequest();
        }


       //status updatation method
       [HttpPost("updatetask")]
        public IActionResult updateStatus([FromBody] StatusVm statusVm)
        {
            var user = _unitOfWork.Tasks.statusVm(statusVm.registeredUsers,statusVm.tasks);
            _unitOfWork.Tasks.Save();
            return Ok();
        }
    }
}
